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
using SofiaSpack.Forms;
using System.IO;

namespace SofiaSpack
{
    public partial class MainWindow : Form
    {
        Point lastPoint; // координати для переміщення вікна

        DiaryWindow diaryWindow; //Форма щоденника
        RulesWindow rulesWindow; //форма правил для ЗНО
        Spor spor; //Форма для шпаргалки


        Users CurrentUsers { get; set; } // Поточний користувач

        String[][] SectionTheme = new string[2][]; // Теми розділів
        List<TextContainer> textContainers { get; set; } // Клас який містить основну інформацію про кожний розділ

        bool Testing = false; // Перевірка на тестування
        int indexPage = 0;    // Поточний номер сторіник

        List<List<RadioButton>> UserAnswer = new List<List<RadioButton>> { }; //Стовренні при тестування кнопки для надання відповідей на тестування
        int[] Answer = new int[] { }; // Правильні відповіді на поточне тестування

        List<TrialTest> trialTests; // Клас пробних ЗНО
        List<TextBox> trialUserAnswer = new List<TextBox> { }; // Створенні при пробному ЗНО текст бокси для надання відповідей
        String[] TrialWritingAnswer = new string[] { };  // Правильны відповіді на письмові завдання 
        bool part1 = true; // Відслідковування поточної частини пробного ЗНО

        public MainWindow() { InitializeComponent(); } // Ініціалізація вікна
        public MainWindow(WindowLogin windowLogin, Users users) // Ініціалізація з параметрами вікна 
        {
            InitializeComponent();
            CurrentUsers = users;

            SectionTheme[0] = new string[] { "Числа і вирази", "Рівняння і нерівності", "Функції", "Комбінаторика і теорія ймовірності" };
            SectionTheme[1] = new string[] { "Планіметрія", "Стеріометрія" };

            Part1.BackColor = Color.CornflowerBlue;

            FillSection();
        }

        private async void FillSection() // Заповнення відкритими темами розділів (вивід поточного розділу, і заповнення випадаючого списку)
        {
            textContainers = await JsonConverter.ReadListClassFile<TextContainer>("DB\\SectionText.json");
            trialTests = await JsonConverter.ReadListClassFile<TrialTest>("DB\\TrialZNOText.json");
            for (int i = 0; i <= CurrentUsers.CurrentSection[0]; i++)
            {
                AlgebraSection.Items.Add(SectionTheme[0][i]);
                if (i == CurrentUsers.CurrentSection[0])
                    AlgebraSection.SelectedIndex = i;
            }
            for (int i = 0; i <= CurrentUsers.CurrentSection[1]; i++)
            {
                GeometrySection.Items.Add(SectionTheme[1][i]);
                if (i == CurrentUsers.CurrentSection[1])
                    GeometrySection.SelectedIndex = i;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e) // Івент закриття програми
        {
            Application.Exit();
        }

        private void DiaryClick(object sender, EventArgs e) // Запуск Щоденника
        {
            if (diaryWindow == null)
            {
                diaryWindow = new DiaryWindow(CurrentUsers);
                diaryWindow.FormClosed += DiaryClosed;
                diaryWindow.Show();
            }
        }

        private void SporClick(object sender, EventArgs e) // Запуск шпаргалки 
        {
            if (spor == null)
            {
                spor = new Spor(CurrentUsers);
                spor.FormClosed += SporClosed;
                spor.Show();
            }
        }
        private void ZNORulesClick(object sender, EventArgs e) // Запуск правил ЗНО
        {
            if (rulesWindow == null)
            {
                rulesWindow = new RulesWindow(textContainers[6]);
                rulesWindow.FormClosed += RulesClosed;
                rulesWindow.Show();
            }
        }
        /*
         * Івенти закриття вікон і очищення классів
         */
        public void SporClosed(object sender, EventArgs e) { spor = null; } 
        public void DiaryClosed(object sender, EventArgs e) { diaryWindow = null; }
        public void RulesClosed(object sender, EventArgs e) { rulesWindow = null; }


        private void TabControl_Selecting(object sender, TabControlCancelEventArgs e) // Зміна поточної сторінки
        {
            if (Testing && e.TabPageIndex != indexPage)
                e.Cancel = true;
            else
            {
                indexPage = e.TabPageIndex;
                if (indexPage == 2)
                {
                    if (CurrentUsers.CurrentSection[0] == 3 && CurrentUsers.CurrentSection[1] == 1)
                    {
                        if (CurrentUsers.NumberTrialZNO < 3)
                            DebtsPanel.Visible = false;
                        else
                        {
                            DebtsPanel.Visible = true;
                            debtsHeader.Text = "Спроби здати пробне ЗНО скінчилися!";
                            DebtsLabel.Text = "";
                        }
                    }
                    else
                    {
                        DebtsLabel.Text = "Вам необхідно пройти теми:\n";
                        if (CurrentUsers.CurrentSection[0] < 3)
                            for (int i = 0; i < SectionTheme[0].Length; i++)
                                if (i >= CurrentUsers.CurrentSection[0])
                                    DebtsLabel.Text += SectionTheme[0][i] + ";\n";

                        if (CurrentUsers.CurrentSection[1] < 1)
                            for (int i = 0; i < SectionTheme[1].Length; i++)
                                if (i >= CurrentUsers.CurrentSection[1])
                                    DebtsLabel.Text += SectionTheme[1][i] + ";\n";
                    }
                }
            }
        }
        /**
         *  Сторінка Алгебри
         */
        private void StartAlgebraTest_Click(object sender, EventArgs e) // Початок тестування алгебри 
        {
            Testing = true;
            AlgebraSection.Enabled = false;
            TestingAlgebraPanel.Visible = true;
            if (CurrentUsers.TestingAlgebra[AlgebraSection.SelectedIndex] < 2)
                StartTest(textContainers[AlgebraSection.SelectedIndex], AlgebraFlowPanel);
            else
                StartAnswer(textContainers[AlgebraSection.SelectedIndex], AlgebraFlowPanel);
        }

        private void AlgebraSection_SelectedIndexChanged(object sender, EventArgs e) // Зміна теми алгебри 
        {
            int index = AlgebraSection.SelectedIndex;
            Section_SelectedIndexChange(index, AlgebraFlowPanel);
            LabelButtonStartTest(StartAlgebraTesting, AttemptsAlgebraLabel, CurrentUsers.TestingAlgebra[index]);
        }
        private void EndAlgebraTesting_Click(object sender, EventArgs e) // Закінчення тестування з алгебри
        {
            Testing = false;
            AlgebraSection.Enabled = true;
            TestingAlgebraPanel.Visible = false;

            int EndThemeIndex = AlgebraSection.SelectedIndex;
            CurrentUsers.TestingAlgebra[EndThemeIndex] += 1;
            if (CurrentUsers.TestingAlgebra[EndThemeIndex] < 3)
            {
                int[] Srores = CalcSroresTest(UserAnswer, Answer);
                DialogResult res = MessageBox.Show("Ваші бали становлять: " + Srores[0] + "/" + Srores[1], "Вітаємо, ви пройшли тест!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CurrentUsers.TestingAlgebra[EndThemeIndex] == 1)
                {
                    CurrentUsers.AlgebraScores[AlgebraSection.SelectedIndex] = Srores[0];
                    CurrentUsers.AlgebraRating[AlgebraSection.SelectedIndex] = ConvertScoresRating(Srores[0], Srores[1]);
                }
                else
                {
                    CurrentUsers.ReAlgebraScores[AlgebraSection.SelectedIndex] = Srores[0];
                    CurrentUsers.ReAlgebraRating[AlgebraSection.SelectedIndex] = ConvertScoresRating(Srores[0], Srores[1]);
                }
                if (diaryWindow != null)
                {
                    diaryWindow.RefreshRaiting(CurrentUsers);
                    spor.SetUser(CurrentUsers);
                    UpdateStatusUser();
                }
            }
            if (CurrentUsers.CurrentSection[TabControl.SelectedIndex] == EndThemeIndex && EndThemeIndex != 3)
            {
                CurrentUsers.CurrentSection[TabControl.SelectedIndex] += 1;
                AlgebraSection.Items.Add(SectionTheme[TabControl.SelectedIndex][EndThemeIndex + 1]);
                AlgebraSection.SelectedIndex = EndThemeIndex + 1;
            }
            else
            {

                LabelButtonStartTest(StartAlgebraTesting, AttemptsAlgebraLabel, CurrentUsers.TestingAlgebra[EndThemeIndex]);
                Section_SelectedIndexChange(AlgebraSection.SelectedIndex, AlgebraFlowPanel);
            }
            UpdateStatusUser();
        }
        /**
         *  Сторінка Геометрії
         */
        private void StartGeometryTesting_Click(object sender, EventArgs e) // Початок тестування з геометрії 
        {
            Testing = true;
            GeometrySection.Enabled = false;
            TestingGeometryPanel.Visible = true;
            if (CurrentUsers.TestingGeometry[GeometrySection.SelectedIndex] < 2)
                StartTest(textContainers[GeometrySection.SelectedIndex+4], GeometryFlowPanel);
            else
                StartAnswer(textContainers[GeometrySection.SelectedIndex+4], GeometryFlowPanel);
        }

        private void GeometrySection_SelectedIndexChanged(object sender, EventArgs e) // Змінна теми геометрії
        {
            int index = GeometrySection.SelectedIndex;
            Section_SelectedIndexChange(index + 4, GeometryFlowPanel);
            LabelButtonStartTest(StartGeometryTesting, AttemptsGeometryLabel, CurrentUsers.TestingGeometry[index]);
        }
        private void EndGeometryTesting_Click(object sender, EventArgs e) // Заканчення тестування з геометрії 
        {

            Testing = false;
            GeometrySection.Enabled = true;
            TestingGeometryPanel.Visible = false;

            int EndThemeIndex = GeometrySection.SelectedIndex;
            CurrentUsers.TestingGeometry[EndThemeIndex] += 1;
            if (CurrentUsers.TestingGeometry[EndThemeIndex] < 3)
            {
                int[] Srores = CalcSroresTest(UserAnswer, Answer);
                DialogResult res = MessageBox.Show("Ваші бали становлять: " + Srores[0] + "/" + Srores[1], "Вітаємо, ви пройшли тест!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (CurrentUsers.TestingGeometry[EndThemeIndex] == 1)
                {
                    CurrentUsers.GeometryScores[GeometrySection.SelectedIndex] = Srores[0];
                    CurrentUsers.GeometryRating[GeometrySection.SelectedIndex] = ConvertScoresRating(Srores[0], Srores[1]);
                }
                else
                {
                    CurrentUsers.ReGeometryScores[GeometrySection.SelectedIndex] = Srores[0];
                    CurrentUsers.ReGeometryRating[GeometrySection.SelectedIndex] = ConvertScoresRating(Srores[0], Srores[1]);
                }
                if (diaryWindow != null)
                {
                    diaryWindow.RefreshRaiting(CurrentUsers);
                    spor.SetUser(CurrentUsers);
                    UpdateStatusUser();
                }
            }
            if (CurrentUsers.CurrentSection[TabControl.SelectedIndex] == EndThemeIndex && EndThemeIndex != 1)
            {
                CurrentUsers.CurrentSection[TabControl.SelectedIndex] += 1;
                GeometrySection.Items.Add(SectionTheme[TabControl.SelectedIndex][EndThemeIndex + 1]);
                GeometrySection.SelectedIndex = EndThemeIndex + 1;
            }
            else
            {
                LabelButtonStartTest(StartGeometryTesting, AttemptsGeometryLabel, CurrentUsers.TestingGeometry[EndThemeIndex]);
                Section_SelectedIndexChange(GeometrySection.SelectedIndex + 4, GeometryFlowPanel);
            }
            UpdateStatusUser();
        }
        /**
        *  Для обох сторінок
        */
        private void StartTest(TextContainer test, FlowLayoutPanel panel) // Початок тестування, завантаження тестових питань
        {
            panel.Controls.Clear();
            UserAnswer.Clear();
            Answer = test.QuestionsAnswer;
            int counter = 0;
            for (int i = 0; i < test.QuestionSize.Length; i++)
            {

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile("DB\\ImageQuest\\" + test.QuestionsText[counter] + ".png");
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                panel.Controls.Add(pictureBox);


                UserAnswer.Add(new List<RadioButton> { });
                GroupBox groupBox = new GroupBox { };
                
                groupBox.AutoSize = true;

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.AutoSize = true;
                flowLayoutPanel.Location = new Point { X = 10, Y = 30 };
                flowLayoutPanel.Size = new Size { Height = 5 };
                groupBox.Controls.Add(flowLayoutPanel);
                
                for (int j = 1; j < test.QuestionSize[i]; j++)
                {
                    RadioButton radioButton = new RadioButton { Text = "" };
                    radioButton.AutoSize = true;
                    UserAnswer[i].Add(radioButton);
                    flowLayoutPanel.Controls.Add(radioButton);

                    PictureBox picture = new PictureBox();
                    picture.Image = Image.FromFile("DB\\ImageQuest\\" + test.QuestionsText[counter + j] + ".png");
                    picture.SizeMode = PictureBoxSizeMode.AutoSize;
                    flowLayoutPanel.Controls.Add(picture);
                }
                panel.Controls.Add(groupBox);
                counter += test.QuestionSize[i];
            }
        }
        private void StartWritingTest(String[] question, String[] answer, FlowLayoutPanel panel) // Завантаження питань з письмовою відповідю
        {
            panel.Controls.Clear();
            trialUserAnswer.Clear();
            TrialWritingAnswer = answer;
            for (int i = 0; i < question.Length; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile("DB\\ImageQuest\\" + question[i] + ".png");
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                panel.Controls.Add(pictureBox);

                TextBox textBox = new TextBox { };
                textBox.Size = new Size { Width = 300 };
                textBox.Font = new Font("Consolas", 18);

                trialUserAnswer.Add(textBox);
                panel.Controls.Add(textBox);
            }
        }
        private void StartAnswer(TextContainer test, FlowLayoutPanel panel) // Завантаженн питань з відповідю
        {
            panel.Controls.Clear();
            int counter = 0;
            for (int i = 0; i < test.QuestionSize.Length; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile("DB\\ImageQuest\\" + test.QuestionsText[counter] + ".png");
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                panel.Controls.Add(pictureBox);


                UserAnswer.Add(new List<RadioButton> { });
                GroupBox groupBox = new GroupBox { };

                groupBox.AutoSize = true;
                groupBox.Enabled = false;

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.AutoSize = true;
                flowLayoutPanel.Location = new Point { X = 10, Y = 30 };
                flowLayoutPanel.Size = new Size { Height = 5 };
                groupBox.Controls.Add(flowLayoutPanel);

                for (int j = 1; j < test.QuestionSize[i]; j++)
                {
                    RadioButton radioButton = new RadioButton { Text = "" };
                    radioButton.AutoSize = true;
                    UserAnswer[i].Add(radioButton);
                    if (test.QuestionsAnswer[i] == j - 1)
                        radioButton.Checked = true;
                    flowLayoutPanel.Controls.Add(radioButton);

                    PictureBox picture = new PictureBox();
                    picture.Image = Image.FromFile("DB\\ImageQuest\\" + test.QuestionsText[counter + j] + ".png");
                    picture.SizeMode = PictureBoxSizeMode.AutoSize;
                    flowLayoutPanel.Controls.Add(picture);
                }
                panel.Controls.Add(groupBox);
                counter += test.QuestionSize[i];
            }
        }
        private void Section_SelectedIndexChange(int index, FlowLayoutPanel flowLayoutPanel) // Вибір теми розділу, і завантаження всього контенту даної теми для ознайомлення
        {
            flowLayoutPanel.Controls.Clear();
            for (int i = 0; i < textContainers[index].Header.Length; i++)
            {
                if (textContainers[index].Header[i].Substring(0, 1) == "h")
                {
                    Label Text = new Label { Text = textContainers[index].Header[i].Substring(1, textContainers[index].Header[i].Length - 1) };
                    Text.MinimumSize = new Size { Width = 620 };
                    Text.AutoSize = true;
                    Text.TextAlign = ContentAlignment.MiddleCenter;
                    Text.Font = new Font("Consolas", 20, FontStyle.Bold);

                    flowLayoutPanel.Controls.Add(Text);
                }
                else if (textContainers[index].Header[i].Substring(0, 1) == "i")
                {

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile("DB\\Image\\" + textContainers[index].Header[i].Substring(1, textContainers[index].Header[i].Length - 1));
                    pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    flowLayoutPanel.Controls.Add(pictureBox);
                }
                else
                {
                    Label Text = new Label { Text = textContainers[index].Header[i].Substring(1, textContainers[index].Header[i].Length - 1) + "\n\n" };
                    Text.MaximumSize = new Size { Width = 620 };
                    Text.AutoSize = true;
                    Text.Font = new Font("Consolas", 12);
                    flowLayoutPanel.Controls.Add(Text);
                }
            }
        }
        

        private void StartTrialTesting_Click(object sender, EventArgs e) // Початок пробного ЗНО
        {
            Testing = !Testing;
            if (Testing)
            {
                StartTrialTesting.Text = "Закінчити";
                Part1.Visible = true;
                Part2.Visible = true;
                AttemptsTrialLabel.Visible = false;
                StartTest(new TextContainer
                {
                    QuestionsAnswer = trialTests[CurrentUsers.NumberTrialZNO].QuestionsAnswer,
                    QuestionSize = trialTests[CurrentUsers.NumberTrialZNO].QuestionSize,
                    QuestionsText = trialTests[CurrentUsers.NumberTrialZNO].QuestionsText
                }, TrialFlowPanel);
                StartWritingTest(trialTests[CurrentUsers.NumberTrialZNO].WritingQuestionsText,
                    trialTests[CurrentUsers.NumberTrialZNO].WritingQuestionsAnswer, TrialWritingFlowPanel);
            }
            else
            {
                TrialFlowPanel.Controls.Clear();
                TrialWritingFlowPanel.Controls.Clear();
                part1 = true;
                Part1.Enabled = false;
                Part2.Enabled = true;
                TrialFlowPanel.Visible = true;
                TrialWritingFlowPanel.Visible = false;
                Part1.BackColor = Color.CornflowerBlue;
                Part2.BackColor = Color.White;

                StartTrialTesting.Text = "Тестування";
                CurrentUsers.NumberTrialZNO += 1;
                AttemptsTrialLabel.Text = "Спроб: " + (3 - CurrentUsers.NumberTrialZNO).ToString();
                AttemptsTrialLabel.Visible = true;
                Part1.Visible = false;
                Part2.Visible = false;

                int[] SroresTest = CalcSroresTest(UserAnswer, Answer);
                int[] SroresWritingTest = CalcSroresWrintingTest(trialUserAnswer, TrialWritingAnswer);
                DialogResult res = MessageBox.Show("Ваші бали становлять: 1-розділ = " + SroresTest[0] + "/" + SroresTest[1] + ", 2-розділ = " + SroresWritingTest[0] + "/" + SroresWritingTest[1],
                    "Вітаємо, ви пройшли пробне ЗНО!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (CurrentUsers.NumberTrialZNO - 1 == 0)
                {
                    CurrentUsers.Trial1Scores[0] = SroresTest[0] + SroresWritingTest[0];
                    CurrentUsers.Trial1Scores[1] = ConvertScoresRating((SroresTest[0] + SroresWritingTest[0]), SroresTest[1] + SroresWritingTest[1]);
                }
                else if (CurrentUsers.NumberTrialZNO - 1 == 1)
                {
                    CurrentUsers.Trial2Scores[0] = SroresTest[0] + SroresWritingTest[0];
                    CurrentUsers.Trial2Scores[1] = ConvertScoresRating((SroresTest[0] + SroresWritingTest[0]), SroresTest[1] + SroresWritingTest[1]);
                }
                else
                {
                    CurrentUsers.Trial3Scores[0] = SroresTest[0] + SroresWritingTest[0];
                    CurrentUsers.Trial3Scores[1] = ConvertScoresRating((SroresTest[0] + SroresWritingTest[0]), SroresTest[1] + SroresWritingTest[1]);
                    StartTrialTesting.Enabled = false;
                }
                UpdateStatusUser();

                if (diaryWindow != null)
                    diaryWindow.RefreshRaiting(CurrentUsers);
            }
        }
        private int[] CalcSroresTest(List<List<RadioButton>> UserAnswer, int [] Answer) // Розрахунок балів за тестові завдання
        {
            int scores = 0;
            for (int i = 0; i < UserAnswer.Count; i++)
                for (int j = 0; j < UserAnswer[i].Count; j++)
                    if (UserAnswer[i][j].Checked && Answer[i] == j)
                        scores++;
            return new int[] { scores, UserAnswer.Count };
        }
        private int[] CalcSroresWrintingTest(List<TextBox> UserAnswer, String [] answer)  // Розрахунок балів за письмові завдання 
        {
            int scores = 0;
            for (int i = 0; i < UserAnswer.Count; i++)
                    if (UserAnswer[i].Text == answer[i])
                        scores+=2;
            return new int[] { scores, UserAnswer.Count*2 };
        }
        private int ConvertScoresRating(int scores, int max) // Конвертування балів у оцінку 
        {
            return (int)(scores / ((float)max / 5));
        }

        private void Part1_Click(object sender, EventArgs e) // Зміна частини на пробном ЗНО
        {
            part1 = !part1;
            Part1.Enabled = !Part1.Enabled;
            Part2.Enabled = !Part2.Enabled;
            TrialFlowPanel.Visible = !TrialFlowPanel.Visible;
            TrialWritingFlowPanel.Visible = !TrialWritingFlowPanel.Visible;

            if (part1)
            {
                Part1.BackColor = Color.CornflowerBlue;
                Part2.BackColor = Color.White;
            }
            else 
            {
                Part2.BackColor = Color.CornflowerBlue;
                Part1.BackColor = Color.White;
            }
        }
        public async void UpdateStatusUser() // Збереження результатів користувача
        {
            List<Users> users = await JsonConverter.ReadListClassFile<Users>("DB\\Users.json");
            for (int i = 0; i < users.Count; i++)
                if (users[i].name == CurrentUsers.name)
                {
                    users[i] = CurrentUsers;
                }
            JsonConverter.SaveListClassFile("DB\\Users.json", users);
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
        private void LabelButtonStartTest(Button button, Label label, int number) // Оновлення надпису на кнопці тестування
        {
            if (number == 0)
            {
                button.Text = "Тестування";
                label.Text = "Спроб: 2";
            }
            else if (number == 1)
            {
                button.Text = "Перездача";
                label.Text = "Спроб: 1";
            }
            else
            {
                button.Text = "Відповіді";
                label.Text = "Спроб: 0";
            }
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
