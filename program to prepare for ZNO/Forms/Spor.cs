using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SofiaSpack.Code;
using SofiaSpack.Forms;

namespace SofiaSpack.Forms
{
    public partial class Spor : Form
    {
        Point lastPoint; // координати для переміщення вікна
        Users CurrentUser;

        public Spor()
        {
            InitializeComponent();
            SporSection.SelectedIndex = 0;
        }
        public Spor(Users users)
        {
            InitializeComponent();
            SporSection.SelectedIndex = 0;
            CurrentUser = users;
        }
        private void Download_Click(object sender, EventArgs e) // Натискання на кнопку завантаження
        {
            if (SporSection.SelectedIndex < 4 && CurrentUser.TestingAlgebra[SporSection.SelectedIndex] != 0 || (SporSection.SelectedIndex > 3 && CurrentUser.TestingGeometry[SporSection.SelectedIndex - 4] != 0))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    String filePath = "";
                    saveFileDialog.InitialDirectory = "c:\\";
                    saveFileDialog.Filter = "docx files (*.docx)|*.docx";
                    saveFileDialog.RestoreDirectory = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = saveFileDialog.FileName;
                        String donloadFile = @"DB\DopInf\SA" + (SporSection.SelectedIndex + 1).ToString() + ".docx";
                        File.Copy(donloadFile, @filePath);
                    }
                }
            }
            else
                MessageBox.Show("Спочатку пройдіть відповідний розділ!", "Не можливо зберегти", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void SetUser(Users users) // Задання користувача
        {
            CurrentUser = users;
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
