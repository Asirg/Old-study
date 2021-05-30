
namespace SofiaSpack
{
    partial class MainWindow
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.alg = new System.Windows.Forms.TabPage();
            this.TestingAlgebraPanel = new System.Windows.Forms.Panel();
            this.EndAlgebraTesting = new System.Windows.Forms.Button();
            this.AttemptsAlgebraLabel = new System.Windows.Forms.Label();
            this.StartAlgebraTesting = new System.Windows.Forms.Button();
            this.StartAlgebraTest = new System.Windows.Forms.Button();
            this.AlgebraFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AlgebraSection = new System.Windows.Forms.ComboBox();
            this.geo = new System.Windows.Forms.TabPage();
            this.TestingGeometryPanel = new System.Windows.Forms.Panel();
            this.EndGeometryTesting = new System.Windows.Forms.Button();
            this.AttemptsGeometryLabel = new System.Windows.Forms.Label();
            this.StartGeometryTesting = new System.Windows.Forms.Button();
            this.GeometryFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GeometrySection = new System.Windows.Forms.ComboBox();
            this.trea = new System.Windows.Forms.TabPage();
            this.DebtsPanel = new System.Windows.Forms.Panel();
            this.DebtsLabel = new System.Windows.Forms.Label();
            this.debtsHeader = new System.Windows.Forms.Label();
            this.TrialWritingFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Part2 = new System.Windows.Forms.Button();
            this.Part1 = new System.Windows.Forms.Button();
            this.AttemptsTrialLabel = new System.Windows.Forms.Label();
            this.StartTrialTesting = new System.Windows.Forms.Button();
            this.TrialFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.alg.SuspendLayout();
            this.TestingAlgebraPanel.SuspendLayout();
            this.geo.SuspendLayout();
            this.TestingGeometryPanel.SuspendLayout();
            this.trea.SuspendLayout();
            this.DebtsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 45);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HeaderPanel_MouseMove);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(439, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Правила ЗНО";
            this.label4.Click += new System.EventHandler(this.ZNORulesClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(285, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 32);
            this.label3.TabIndex = 8;
            this.label3.Text = "Щоденник";
            this.label3.Click += new System.EventHandler(this.DiaryClick);
            // 
            // CloseButton
            // 
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CloseButton.Font = new System.Drawing.Font("Anime Ace v05", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(657, 9);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(217, 280);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 40);
            this.label10.TabIndex = 13;
            // 
            // TabControl
            // 
            this.TabControl.AllowDrop = true;
            this.TabControl.Controls.Add(this.alg);
            this.TabControl.Controls.Add(this.geo);
            this.TabControl.Controls.Add(this.trea);
            this.TabControl.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TabControl.HotTrack = true;
            this.TabControl.ItemSize = new System.Drawing.Size(250, 50);
            this.TabControl.Location = new System.Drawing.Point(-10, 43);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.Padding = new System.Drawing.Point(49, 0);
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(723, 557);
            this.TabControl.TabIndex = 17;
            this.TabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // alg
            // 
            this.alg.BackColor = System.Drawing.Color.White;
            this.alg.Controls.Add(this.TestingAlgebraPanel);
            this.alg.Controls.Add(this.AttemptsAlgebraLabel);
            this.alg.Controls.Add(this.StartAlgebraTesting);
            this.alg.Controls.Add(this.StartAlgebraTest);
            this.alg.Controls.Add(this.AlgebraFlowPanel);
            this.alg.Controls.Add(this.AlgebraSection);
            this.alg.Location = new System.Drawing.Point(4, 54);
            this.alg.Name = "alg";
            this.alg.Padding = new System.Windows.Forms.Padding(3);
            this.alg.Size = new System.Drawing.Size(715, 499);
            this.alg.TabIndex = 0;
            this.alg.Text = "Алгебра";
            // 
            // TestingAlgebraPanel
            // 
            this.TestingAlgebraPanel.Controls.Add(this.EndAlgebraTesting);
            this.TestingAlgebraPanel.Location = new System.Drawing.Point(32, 452);
            this.TestingAlgebraPanel.Name = "TestingAlgebraPanel";
            this.TestingAlgebraPanel.Size = new System.Drawing.Size(650, 35);
            this.TestingAlgebraPanel.TabIndex = 34;
            this.TestingAlgebraPanel.Visible = false;
            // 
            // EndAlgebraTesting
            // 
            this.EndAlgebraTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EndAlgebraTesting.BackColor = System.Drawing.Color.Silver;
            this.EndAlgebraTesting.FlatAppearance.BorderSize = 0;
            this.EndAlgebraTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndAlgebraTesting.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndAlgebraTesting.ForeColor = System.Drawing.Color.Black;
            this.EndAlgebraTesting.Location = new System.Drawing.Point(225, 0);
            this.EndAlgebraTesting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndAlgebraTesting.Name = "EndAlgebraTesting";
            this.EndAlgebraTesting.Size = new System.Drawing.Size(200, 35);
            this.EndAlgebraTesting.TabIndex = 34;
            this.EndAlgebraTesting.Text = "Закінчити";
            this.EndAlgebraTesting.UseVisualStyleBackColor = false;
            this.EndAlgebraTesting.Click += new System.EventHandler(this.EndAlgebraTesting_Click);
            // 
            // AttemptsAlgebraLabel
            // 
            this.AttemptsAlgebraLabel.AutoSize = true;
            this.AttemptsAlgebraLabel.Location = new System.Drawing.Point(30, 456);
            this.AttemptsAlgebraLabel.Name = "AttemptsAlgebraLabel";
            this.AttemptsAlgebraLabel.Size = new System.Drawing.Size(111, 34);
            this.AttemptsAlgebraLabel.TabIndex = 34;
            this.AttemptsAlgebraLabel.Text = "Cпроб:";
            // 
            // StartAlgebraTesting
            // 
            this.StartAlgebraTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartAlgebraTesting.BackColor = System.Drawing.Color.Silver;
            this.StartAlgebraTesting.FlatAppearance.BorderSize = 0;
            this.StartAlgebraTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartAlgebraTesting.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartAlgebraTesting.ForeColor = System.Drawing.Color.Black;
            this.StartAlgebraTesting.Location = new System.Drawing.Point(257, 452);
            this.StartAlgebraTesting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartAlgebraTesting.Name = "StartAlgebraTesting";
            this.StartAlgebraTesting.Size = new System.Drawing.Size(200, 35);
            this.StartAlgebraTesting.TabIndex = 37;
            this.StartAlgebraTesting.Text = "Тестування";
            this.StartAlgebraTesting.UseVisualStyleBackColor = false;
            this.StartAlgebraTesting.Click += new System.EventHandler(this.StartAlgebraTest_Click);
            // 
            // StartAlgebraTest
            // 
            this.StartAlgebraTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartAlgebraTest.BackColor = System.Drawing.Color.White;
            this.StartAlgebraTest.FlatAppearance.BorderSize = 0;
            this.StartAlgebraTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartAlgebraTest.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartAlgebraTest.ForeColor = System.Drawing.Color.Black;
            this.StartAlgebraTest.Location = new System.Drawing.Point(4, 5);
            this.StartAlgebraTest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartAlgebraTest.Name = "StartAlgebraTest";
            this.StartAlgebraTest.Size = new System.Drawing.Size(0, 35);
            this.StartAlgebraTest.TabIndex = 33;
            this.StartAlgebraTest.Text = "Тестування";
            this.StartAlgebraTest.UseVisualStyleBackColor = false;
            this.StartAlgebraTest.Click += new System.EventHandler(this.StartAlgebraTest_Click);
            // 
            // AlgebraFlowPanel
            // 
            this.AlgebraFlowPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AlgebraFlowPanel.AutoScroll = true;
            this.AlgebraFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.AlgebraFlowPanel.Location = new System.Drawing.Point(32, 54);
            this.AlgebraFlowPanel.MaximumSize = new System.Drawing.Size(650, 390);
            this.AlgebraFlowPanel.Name = "AlgebraFlowPanel";
            this.AlgebraFlowPanel.Size = new System.Drawing.Size(650, 390);
            this.AlgebraFlowPanel.TabIndex = 26;
            this.AlgebraFlowPanel.WrapContents = false;
            // 
            // AlgebraSection
            // 
            this.AlgebraSection.BackColor = System.Drawing.Color.White;
            this.AlgebraSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgebraSection.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AlgebraSection.ForeColor = System.Drawing.Color.Black;
            this.AlgebraSection.FormattingEnabled = true;
            this.AlgebraSection.Location = new System.Drawing.Point(120, 10);
            this.AlgebraSection.Name = "AlgebraSection";
            this.AlgebraSection.Size = new System.Drawing.Size(450, 32);
            this.AlgebraSection.TabIndex = 30;
            this.AlgebraSection.SelectedIndexChanged += new System.EventHandler(this.AlgebraSection_SelectedIndexChanged);
            // 
            // geo
            // 
            this.geo.BackColor = System.Drawing.Color.White;
            this.geo.Controls.Add(this.TestingGeometryPanel);
            this.geo.Controls.Add(this.AttemptsGeometryLabel);
            this.geo.Controls.Add(this.StartGeometryTesting);
            this.geo.Controls.Add(this.GeometryFlowPanel);
            this.geo.Controls.Add(this.GeometrySection);
            this.geo.Location = new System.Drawing.Point(4, 54);
            this.geo.Name = "geo";
            this.geo.Padding = new System.Windows.Forms.Padding(3);
            this.geo.Size = new System.Drawing.Size(715, 499);
            this.geo.TabIndex = 1;
            this.geo.Text = "Геометрія";
            // 
            // TestingGeometryPanel
            // 
            this.TestingGeometryPanel.Controls.Add(this.EndGeometryTesting);
            this.TestingGeometryPanel.Location = new System.Drawing.Point(32, 452);
            this.TestingGeometryPanel.Name = "TestingGeometryPanel";
            this.TestingGeometryPanel.Size = new System.Drawing.Size(650, 35);
            this.TestingGeometryPanel.TabIndex = 37;
            this.TestingGeometryPanel.Visible = false;
            // 
            // EndGeometryTesting
            // 
            this.EndGeometryTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EndGeometryTesting.BackColor = System.Drawing.Color.Silver;
            this.EndGeometryTesting.FlatAppearance.BorderSize = 0;
            this.EndGeometryTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EndGeometryTesting.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EndGeometryTesting.ForeColor = System.Drawing.Color.Black;
            this.EndGeometryTesting.Location = new System.Drawing.Point(225, 0);
            this.EndGeometryTesting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndGeometryTesting.Name = "EndGeometryTesting";
            this.EndGeometryTesting.Size = new System.Drawing.Size(200, 35);
            this.EndGeometryTesting.TabIndex = 34;
            this.EndGeometryTesting.Text = "Закінчити";
            this.EndGeometryTesting.UseVisualStyleBackColor = false;
            this.EndGeometryTesting.Click += new System.EventHandler(this.EndGeometryTesting_Click);
            // 
            // AttemptsGeometryLabel
            // 
            this.AttemptsGeometryLabel.AutoSize = true;
            this.AttemptsGeometryLabel.Location = new System.Drawing.Point(30, 456);
            this.AttemptsGeometryLabel.Name = "AttemptsGeometryLabel";
            this.AttemptsGeometryLabel.Size = new System.Drawing.Size(111, 34);
            this.AttemptsGeometryLabel.TabIndex = 1;
            this.AttemptsGeometryLabel.Text = "Cпроб:";
            // 
            // StartGeometryTesting
            // 
            this.StartGeometryTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartGeometryTesting.BackColor = System.Drawing.Color.Silver;
            this.StartGeometryTesting.FlatAppearance.BorderSize = 0;
            this.StartGeometryTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGeometryTesting.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartGeometryTesting.ForeColor = System.Drawing.Color.Black;
            this.StartGeometryTesting.Location = new System.Drawing.Point(257, 452);
            this.StartGeometryTesting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartGeometryTesting.Name = "StartGeometryTesting";
            this.StartGeometryTesting.Size = new System.Drawing.Size(200, 35);
            this.StartGeometryTesting.TabIndex = 36;
            this.StartGeometryTesting.Text = "Тестування";
            this.StartGeometryTesting.UseVisualStyleBackColor = false;
            this.StartGeometryTesting.Click += new System.EventHandler(this.StartGeometryTesting_Click);
            // 
            // GeometryFlowPanel
            // 
            this.GeometryFlowPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GeometryFlowPanel.AutoScroll = true;
            this.GeometryFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.GeometryFlowPanel.Location = new System.Drawing.Point(32, 54);
            this.GeometryFlowPanel.MaximumSize = new System.Drawing.Size(650, 390);
            this.GeometryFlowPanel.Name = "GeometryFlowPanel";
            this.GeometryFlowPanel.Size = new System.Drawing.Size(650, 390);
            this.GeometryFlowPanel.TabIndex = 27;
            this.GeometryFlowPanel.WrapContents = false;
            // 
            // GeometrySection
            // 
            this.GeometrySection.BackColor = System.Drawing.Color.White;
            this.GeometrySection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GeometrySection.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GeometrySection.ForeColor = System.Drawing.Color.Black;
            this.GeometrySection.FormattingEnabled = true;
            this.GeometrySection.Location = new System.Drawing.Point(120, 10);
            this.GeometrySection.Name = "GeometrySection";
            this.GeometrySection.Size = new System.Drawing.Size(450, 32);
            this.GeometrySection.TabIndex = 26;
            this.GeometrySection.SelectedIndexChanged += new System.EventHandler(this.GeometrySection_SelectedIndexChanged);
            // 
            // trea
            // 
            this.trea.BackColor = System.Drawing.Color.White;
            this.trea.Controls.Add(this.DebtsPanel);
            this.trea.Controls.Add(this.TrialWritingFlowPanel);
            this.trea.Controls.Add(this.Part2);
            this.trea.Controls.Add(this.Part1);
            this.trea.Controls.Add(this.AttemptsTrialLabel);
            this.trea.Controls.Add(this.StartTrialTesting);
            this.trea.Controls.Add(this.TrialFlowPanel);
            this.trea.Location = new System.Drawing.Point(4, 54);
            this.trea.Name = "trea";
            this.trea.Size = new System.Drawing.Size(715, 499);
            this.trea.TabIndex = 2;
            this.trea.Text = "Пробне ЗНО";
            // 
            // DebtsPanel
            // 
            this.DebtsPanel.BackColor = System.Drawing.Color.White;
            this.DebtsPanel.Controls.Add(this.DebtsLabel);
            this.DebtsPanel.Controls.Add(this.debtsHeader);
            this.DebtsPanel.Location = new System.Drawing.Point(15, 3);
            this.DebtsPanel.Name = "DebtsPanel";
            this.DebtsPanel.Size = new System.Drawing.Size(680, 480);
            this.DebtsPanel.TabIndex = 39;
            // 
            // DebtsLabel
            // 
            this.DebtsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DebtsLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DebtsLabel.Location = new System.Drawing.Point(100, 172);
            this.DebtsLabel.MinimumSize = new System.Drawing.Size(100, 0);
            this.DebtsLabel.Name = "DebtsLabel";
            this.DebtsLabel.Size = new System.Drawing.Size(500, 263);
            this.DebtsLabel.TabIndex = 2;
            this.DebtsLabel.Text = "Вам залишилося пройти:";
            // 
            // debtsHeader
            // 
            this.debtsHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.debtsHeader.ForeColor = System.Drawing.Color.Red;
            this.debtsHeader.Location = new System.Drawing.Point(150, 54);
            this.debtsHeader.MinimumSize = new System.Drawing.Size(100, 0);
            this.debtsHeader.Name = "debtsHeader";
            this.debtsHeader.Size = new System.Drawing.Size(400, 118);
            this.debtsHeader.TabIndex = 1;
            this.debtsHeader.Text = "Для проходження потрібно пройти всі тести !!!";
            this.debtsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TrialWritingFlowPanel
            // 
            this.TrialWritingFlowPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TrialWritingFlowPanel.AutoScroll = true;
            this.TrialWritingFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TrialWritingFlowPanel.Location = new System.Drawing.Point(32, 63);
            this.TrialWritingFlowPanel.MaximumSize = new System.Drawing.Size(650, 410);
            this.TrialWritingFlowPanel.Name = "TrialWritingFlowPanel";
            this.TrialWritingFlowPanel.Size = new System.Drawing.Size(650, 400);
            this.TrialWritingFlowPanel.TabIndex = 38;
            this.TrialWritingFlowPanel.Visible = false;
            this.TrialWritingFlowPanel.WrapContents = false;
            // 
            // Part2
            // 
            this.Part2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Part2.BackColor = System.Drawing.Color.White;
            this.Part2.FlatAppearance.BorderSize = 0;
            this.Part2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Part2.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Part2.ForeColor = System.Drawing.Color.Black;
            this.Part2.Location = new System.Drawing.Point(326, 17);
            this.Part2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Part2.Name = "Part2";
            this.Part2.Size = new System.Drawing.Size(126, 35);
            this.Part2.TabIndex = 41;
            this.Part2.Text = "розділ 2";
            this.Part2.UseVisualStyleBackColor = false;
            this.Part2.Visible = false;
            this.Part2.Click += new System.EventHandler(this.Part1_Click);
            // 
            // Part1
            // 
            this.Part1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Part1.BackColor = System.Drawing.Color.White;
            this.Part1.Enabled = false;
            this.Part1.FlatAppearance.BorderSize = 0;
            this.Part1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Part1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Part1.ForeColor = System.Drawing.Color.Black;
            this.Part1.Location = new System.Drawing.Point(192, 17);
            this.Part1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Part1.Name = "Part1";
            this.Part1.Size = new System.Drawing.Size(126, 35);
            this.Part1.TabIndex = 40;
            this.Part1.Text = "розділ 1";
            this.Part1.UseVisualStyleBackColor = false;
            this.Part1.Visible = false;
            this.Part1.Click += new System.EventHandler(this.Part1_Click);
            // 
            // AttemptsTrialLabel
            // 
            this.AttemptsTrialLabel.AutoSize = true;
            this.AttemptsTrialLabel.Location = new System.Drawing.Point(26, 18);
            this.AttemptsTrialLabel.Name = "AttemptsTrialLabel";
            this.AttemptsTrialLabel.Size = new System.Drawing.Size(143, 34);
            this.AttemptsTrialLabel.TabIndex = 0;
            this.AttemptsTrialLabel.Text = "Cпроб: 3";
            // 
            // StartTrialTesting
            // 
            this.StartTrialTesting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTrialTesting.BackColor = System.Drawing.Color.Silver;
            this.StartTrialTesting.FlatAppearance.BorderSize = 0;
            this.StartTrialTesting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartTrialTesting.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartTrialTesting.ForeColor = System.Drawing.Color.Black;
            this.StartTrialTesting.Location = new System.Drawing.Point(482, 17);
            this.StartTrialTesting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartTrialTesting.Name = "StartTrialTesting";
            this.StartTrialTesting.Size = new System.Drawing.Size(200, 35);
            this.StartTrialTesting.TabIndex = 38;
            this.StartTrialTesting.Text = "Тестування";
            this.StartTrialTesting.UseVisualStyleBackColor = false;
            this.StartTrialTesting.Click += new System.EventHandler(this.StartTrialTesting_Click);
            // 
            // TrialFlowPanel
            // 
            this.TrialFlowPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TrialFlowPanel.AutoScroll = true;
            this.TrialFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TrialFlowPanel.Location = new System.Drawing.Point(32, 63);
            this.TrialFlowPanel.MaximumSize = new System.Drawing.Size(650, 410);
            this.TrialFlowPanel.Name = "TrialFlowPanel";
            this.TrialFlowPanel.Size = new System.Drawing.Size(650, 400);
            this.TrialFlowPanel.TabIndex = 37;
            this.TrialFlowPanel.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 600);
            this.panel2.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Шпаргалка";
            this.label1.Click += new System.EventHandler(this.SporClick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(700, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.alg.ResumeLayout(false);
            this.alg.PerformLayout();
            this.TestingAlgebraPanel.ResumeLayout(false);
            this.geo.ResumeLayout(false);
            this.geo.PerformLayout();
            this.TestingGeometryPanel.ResumeLayout(false);
            this.trea.ResumeLayout(false);
            this.trea.PerformLayout();
            this.DebtsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label CloseButton;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage alg;
        private System.Windows.Forms.TabPage geo;
        private System.Windows.Forms.TabPage trea;
        private System.Windows.Forms.ComboBox GeometrySection;
        private System.Windows.Forms.FlowLayoutPanel AlgebraFlowPanel;
        private System.Windows.Forms.ComboBox AlgebraSection;
        private System.Windows.Forms.FlowLayoutPanel GeometryFlowPanel;
        private System.Windows.Forms.Button StartAlgebraTest;
        private System.Windows.Forms.Button StartGeometryTesting;
        private System.Windows.Forms.Panel TestingAlgebraPanel;
        private System.Windows.Forms.Button EndAlgebraTesting;
        private System.Windows.Forms.Panel TestingGeometryPanel;
        private System.Windows.Forms.Button EndGeometryTesting;
        private System.Windows.Forms.Button StartTrialTesting;
        private System.Windows.Forms.FlowLayoutPanel TrialFlowPanel;
        private System.Windows.Forms.Panel DebtsPanel;
        private System.Windows.Forms.Label DebtsLabel;
        private System.Windows.Forms.Label debtsHeader;
        private System.Windows.Forms.Label AttemptsTrialLabel;
        private System.Windows.Forms.Label AttemptsAlgebraLabel;
        private System.Windows.Forms.Label AttemptsGeometryLabel;
        private System.Windows.Forms.Button Part2;
        private System.Windows.Forms.Button Part1;
        private System.Windows.Forms.FlowLayoutPanel TrialWritingFlowPanel;
        private System.Windows.Forms.Button StartAlgebraTesting;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label label1;
    }
}