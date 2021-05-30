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

namespace SofiaSpack.Forms
{
    public partial class RulesWindow : Form
    {
        Point lastPoint; // координати для переміщення вікна

        public RulesWindow()
        {
            InitializeComponent();
        }
        public RulesWindow(TextContainer textContainers) // Інціалізація вікна правил зно, та завантаження самих правил
        {
            InitializeComponent();

            for (int i = 0; i < textContainers.Header.Length; i++)
            {
                if (textContainers.Header[i].Substring(0, 1) == "h")
                {
                    Label Text = new Label { Text = textContainers.Header[i].Substring(1, textContainers.Header[i].Length - 1) };
                    Text.MinimumSize = new Size { Width = 620 };
                    Text.AutoSize = true;
                    Text.TextAlign = ContentAlignment.MiddleCenter;
                    Text.Font = new Font("Consolas", 20, FontStyle.Bold);

                    RulesFlowPanel.Controls.Add(Text);
                }
                else if (textContainers.Header[i].Substring(0, 1) == "i")
                {

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile("DB\\Image\\" + textContainers.Header[i].Substring(1, textContainers.Header[i].Length - 1));
                    pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                    RulesFlowPanel.Controls.Add(pictureBox);
                }
                else
                {
                    Label Text = new Label { Text = textContainers.Header[i].Substring(1, textContainers.Header[i].Length - 1) + "\n\n" };
                    Text.MaximumSize = new Size { Width = 620 };
                    Text.AutoSize = true;
                    Text.Font = new Font("Consolas", 12);
                    RulesFlowPanel.Controls.Add(Text);
                }
            }
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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
