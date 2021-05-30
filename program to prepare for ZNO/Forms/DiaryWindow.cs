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

namespace SofiaSpack.Forms
{
    public partial class DiaryWindow : Form
    {
        Point lastPoint; // координати для переміщення вікна

        public DiaryWindow(Users users)
        {
            InitializeComponent();
            RefreshRaiting(users);
        }

        // Оновлення оцінок в щоденнику
        public void RefreshRaiting(Users users) {

            this.scores1_1.Text = users.AlgebraScores[0].ToString();
            this.scores1_2.Text = users.AlgebraScores[1].ToString();
            this.scores1_3.Text = users.AlgebraScores[2].ToString();
            this.scores1_4.Text = users.AlgebraScores[3].ToString();

            this.rating1_1.Text = users.AlgebraRating[0].ToString();
            this.rating1_2.Text = users.AlgebraRating[1].ToString();
            this.rating1_3.Text = users.AlgebraRating[2].ToString();
            this.rating1_4.Text = users.AlgebraRating[3].ToString();

            this.scores2_1.Text = users.GeometryScores[0].ToString();
            this.scores2_2.Text = users.GeometryScores[1].ToString();

            this.rating2_1.Text = users.GeometryRating[0].ToString();
            this.rating2_2.Text = users.GeometryRating[1].ToString();

            this.Rescores1_1.Text = users.ReAlgebraScores[0].ToString();
            this.Rescores1_2.Text = users.ReAlgebraScores[1].ToString();
            this.Rescores1_3.Text = users.ReAlgebraScores[2].ToString();
            this.Rescores1_4.Text = users.ReAlgebraScores[3].ToString();

            this.Rerating1_1.Text = users.ReAlgebraRating[0].ToString();
            this.Rerating1_2.Text = users.ReAlgebraRating[1].ToString();
            this.Rerating1_3.Text = users.ReAlgebraRating[2].ToString();
            this.Rerating1_4.Text = users.ReAlgebraRating[3].ToString();

            this.Rescores2_1.Text = users.ReGeometryScores[0].ToString();
            this.Rescores2_2.Text = users.ReGeometryScores[1].ToString();

            this.Rerating2_1.Text = users.ReGeometryRating[0].ToString();
            this.Rerating2_2.Text = users.ReGeometryRating[1].ToString();

            this.Trialscores1.Text = "Бали = " +  users.Trial1Scores[0].ToString();
            this.Trialrating1.Text = "Оцінка = " + users.Trial1Scores[1].ToString();

            this.Trialscores2.Text = "Бали = " + users.Trial2Scores[0].ToString();
            this.Trialrating2.Text = "Оцінка = " + users.Trial2Scores[1].ToString();

            this.Trialscores3.Text = "Бали = " + users.Trial3Scores[0].ToString();
            this.Trialrating3.Text = "Оцінка= " + users.Trial3Scores[1].ToString();
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
