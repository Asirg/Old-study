using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SofiaSpack.Code;



namespace SofiaSpack
{
    public partial class WindowLogin : Form
    {
        Point lastPoint; // координати для переміщення вікна

        // булеві вирази для перевірки при аутентифікації та регестрації
        bool CorrectPassword;
        bool CorrectNewUsersPassword;
        bool CorrectNewUsersLogin;

        private List<Users> users; // Список можливих юзерів
        private Users LoginCurrentUser { get; set; } // Авторизований користувач

        public WindowLogin() // Констркутор Форми
        {
            InitializeComponent();
            ChooserMode.SelectedItem = "Регестрація";
            ChooseModeFill();
        }

        private void WindowLogin_Load(object sender, EventArgs e) { } // Щось для ініціалізації

        private void CloseButton_Click(object sender, EventArgs e) { Application.Exit(); } // Івент кліку на кнопку закриття прогрми

        private async void ChooseModeFill() // Завантаження користувачів та заповнення комбо боксу (списку розділів)
        {
                users = await JsonConverter.ReadListClassFile<Users>("DB\\Users.json");
                for (int i = 0; i < users.Count; i++)
                    ChooserMode.Items.Add(users[i].name);
        }

        private void LoginClick(object sender, EventArgs e) // Івент кліку на кнопку увійти або регестрація
        {
            if (!ChooserMode.Text.Contains("Регестрація") && CorrectPassword)
            {
                MainWindow mainWindow = new MainWindow(this, LoginCurrentUser);
                mainWindow.Show();
                this.Hide();
            }
            else if (ChooserMode.Text.Contains("Регестрація") && CorrectNewUsersLogin && CorrectNewUsersPassword)
            {
                LoginCurrentUser = new Users { name = LoginField.Text, password = PasswordField.Text };
                users.Add(LoginCurrentUser);
                JsonConverter.SaveListClassFile("DB\\Users.json", users);
                MainWindow mainWindow = new MainWindow(this, LoginCurrentUser);
                mainWindow.Show();
                this.Hide();
            }

        }

        private void LoginField_TextChange(object sender, EventArgs e) // Івент зміни вмісту поля логіну
        {
            if (ChooserMode.Text.Contains("Регестрація"))
            {
                if ((users.Find(x => (x.name == LoginField.Text)) != null) || LoginField.Text == "")
                {
                    CorrectNewUsersLogin = false;
                    LoginField.BackColor = Color.Red;
                    LoginButtonEnabled();
                }
                else
                {
                    CorrectNewUsersLogin = true;
                    LoginField.BackColor = Color.White;
                    LoginButtonEnabled();
                }
            }
        }

        private void PasswordField_TextChange(object sender, EventArgs e) // Івент зміни вмісту поля поролю 
        {
            if (!ChooserMode.Text.Contains("Регестрація"))
            {
                if (PasswordField.Text == users.Find(x => (x.name == ChooserMode.Text)).password)
                {
                    CorrectPassword = true;
                    PasswordField.BackColor = Color.White;
                    LoginButtonEnabled();
                }
                else
                {
                    CorrectPassword = false;
                    PasswordField.BackColor = Color.Red;
                    LoginButtonEnabled();
                }
            }
            else
            {
                if (PasswordField.Text == "")
                {
                    PasswordField.BackColor = Color.Red;
                    CorrectNewUsersPassword = false;
                    LoginButtonEnabled();
                }
                else
                {
                    PasswordField.BackColor = Color.White;
                    CorrectNewUsersPassword = true;
                    LoginButtonEnabled();
                }
            }
        }

        private void ChangeModeLogin(object sender, EventArgs e) // Івент зміни користувача або вибір регестрації (зміна ітему у комбо боксі)
        {
            if (!ChooserMode.Text.Contains("Регестрація"))
            {
                CorrectPassword = false;
                CorrectNewUsersLogin = true;
                CorrectNewUsersPassword = true;


                LoginField.Enabled = false;
                LoginField.Text = ChooserMode.Text;
                LoginCurrentUser = users.Find(x => (x.name == ChooserMode.Text));
                LoginField.BackColor = Color.White;
                PasswordField.Text = "";

                LoginButton.Text = "Увійти";
            }
            else
            {
                CorrectPassword = true;
                CorrectNewUsersLogin = false;
                CorrectNewUsersPassword = false;


                LoginField.Enabled = true;
                LoginField.Text = "";
                LoginField.BackColor = Color.Red;
                PasswordField.Text = "";
                PasswordField.BackColor = Color.Red;
   
                LoginButton.Text = "Регестрація";
            }
            LoginButtonEnabled();
        }

        /*
         * Візуальні ефекти
        */
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Red;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }
        private void LoginButton_MouseEnter(object sender, EventArgs e)
        {
            if (CorrectPassword && CorrectNewUsersLogin && CorrectNewUsersPassword)
            {
                LoginButton.ForeColor = Color.White;
                LoginButton.BackColor = Color.Green;
            }
        }
        private void LoginButton_MouseLeave(object sender, EventArgs e)
        {
            if (CorrectPassword && CorrectNewUsersLogin && CorrectNewUsersPassword)
            {
                LoginButton.ForeColor = Color.Black;
                LoginButton.BackColor = Color.White;
            }
        }
        private void LoginButtonEnabled() {
            if (CorrectPassword && CorrectNewUsersLogin && CorrectNewUsersPassword)
                LoginButton.BackColor = Color.White;
            else
                LoginButton.BackColor = Color.Gray;
        }


        /*
         * Можлливість переміщення вікна у просторі
        */
        private void HeaderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void HeaderPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
