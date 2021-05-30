
namespace SofiaSpack.Forms
{
    partial class Spor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CloseButton = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Download = new System.Windows.Forms.Button();
            this.SporSection = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CloseButton.Font = new System.Drawing.Font("Anime Ace v05", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(296, 2);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(29, 31);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "X";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseEnter);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 35);
            this.panel1.TabIndex = 19;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(91, 1);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Шпаргалка";
            // 
            // Download
            // 
            this.Download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Download.BackColor = System.Drawing.Color.Silver;
            this.Download.FlatAppearance.BorderSize = 0;
            this.Download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Download.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Download.ForeColor = System.Drawing.Color.Black;
            this.Download.Location = new System.Drawing.Point(82, 104);
            this.Download.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(176, 35);
            this.Download.TabIndex = 35;
            this.Download.Text = "Завантажити";
            this.Download.UseVisualStyleBackColor = false;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // SporSection
            // 
            this.SporSection.BackColor = System.Drawing.Color.White;
            this.SporSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SporSection.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SporSection.ForeColor = System.Drawing.Color.Black;
            this.SporSection.FormattingEnabled = true;
            this.SporSection.Items.AddRange(new object[] {
            "Числа і вирази",
            "Рівняння і нерівності",
            "Функції",
            "Комбінаторика і теорія ймовірності",
            "Планіметрія",
            "Стеріометрія"});
            this.SporSection.Location = new System.Drawing.Point(23, 52);
            this.SporSection.Name = "SporSection";
            this.SporSection.Size = new System.Drawing.Size(292, 32);
            this.SporSection.TabIndex = 36;
            // 
            // Spor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 153);
            this.Controls.Add(this.SporSection);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Spor";
            this.Text = "Spor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.ComboBox SporSection;
    }
}