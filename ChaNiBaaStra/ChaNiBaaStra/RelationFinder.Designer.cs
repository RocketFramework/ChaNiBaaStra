namespace ChaNiBaaStra
{
    partial class RelationFinder
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
            this.listViewEventDate = new System.Windows.Forms.ListView();
            this.dateTimePickerEvent = new System.Windows.Forms.DateTimePicker();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridViewMain = new System.Windows.Forms.DataGridView();
            this.dataGridViewRelation = new System.Windows.Forms.DataGridView();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonRelate = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxCity2 = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxLat2 = new System.Windows.Forms.TextBox();
            this.textBoxLong2 = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.dataGridViewFutureMapping = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxIncrement = new System.Windows.Forms.ComboBox();
            this.dateTimePickerStartingDate = new System.Windows.Forms.DateTimePicker();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFixed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabelNextDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonFuture = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.panelBottomLeft = new System.Windows.Forms.Panel();
            this.textBoxLongitute = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxIdentity = new System.Windows.Forms.TextBox();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLatitude = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelation)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFutureMapping)).BeginInit();
            this.statusStripMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewEventDate
            // 
            this.listViewEventDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewEventDate.GridLines = true;
            this.listViewEventDate.HideSelection = false;
            this.listViewEventDate.Location = new System.Drawing.Point(0, 0);
            this.listViewEventDate.Name = "listViewEventDate";
            this.listViewEventDate.Size = new System.Drawing.Size(646, 99);
            this.listViewEventDate.TabIndex = 0;
            this.listViewEventDate.UseCompatibleStateImageBehavior = false;
            this.listViewEventDate.View = System.Windows.Forms.View.List;
            this.listViewEventDate.SelectedIndexChanged += new System.EventHandler(this.listViewEventDate_SelectedIndexChanged);
            // 
            // dateTimePickerEvent
            // 
            this.dateTimePickerEvent.CustomFormat = "yyyy/MM/dd HH:mm";
            this.dateTimePickerEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEvent.Location = new System.Drawing.Point(150, 76);
            this.dateTimePickerEvent.Name = "dateTimePickerEvent";
            this.dateTimePickerEvent.Size = new System.Drawing.Size(187, 26);
            this.dateTimePickerEvent.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(510, 8);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(100, 40);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridViewMain
            // 
            this.dataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMain.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMain.Name = "dataGridViewMain";
            this.dataGridViewMain.RowHeadersWidth = 62;
            this.dataGridViewMain.RowTemplate.Height = 28;
            this.dataGridViewMain.Size = new System.Drawing.Size(777, 99);
            this.dataGridViewMain.TabIndex = 3;
            // 
            // dataGridViewRelation
            // 
            this.dataGridViewRelation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRelation.Location = new System.Drawing.Point(645, 0);
            this.dataGridViewRelation.Name = "dataGridViewRelation";
            this.dataGridViewRelation.RowHeadersWidth = 62;
            this.dataGridViewRelation.RowTemplate.Height = 28;
            this.dataGridViewRelation.Size = new System.Drawing.Size(776, 191);
            this.dataGridViewRelation.TabIndex = 4;
            this.dataGridViewRelation.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewRelation_CellFormatting);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(510, 54);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(100, 40);
            this.buttonRemove.TabIndex = 5;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonRelate
            // 
            this.buttonRelate.Location = new System.Drawing.Point(510, 146);
            this.buttonRelate.Name = "buttonRelate";
            this.buttonRelate.Size = new System.Drawing.Size(100, 40);
            this.buttonRelate.TabIndex = 6;
            this.buttonRelate.Text = "Relate";
            this.buttonRelate.UseVisualStyleBackColor = true;
            this.buttonRelate.Click += new System.EventHandler(this.buttonRelate_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(510, 100);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(100, 40);
            this.buttonGenerate.TabIndex = 7;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBottom.Controls.Add(this.dataGridViewFutureMapping);
            this.panelBottom.Controls.Add(this.panel1);
            this.panelBottom.Controls.Add(this.statusStripMain);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 355);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1423, 268);
            this.panelBottom.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(534, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "Lat";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(404, 116);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 20);
            this.label12.TabIndex = 29;
            this.label12.Text = "Long";
            // 
            // comboBoxCity2
            // 
            this.comboBoxCity2.FormattingEnabled = true;
            this.comboBoxCity2.Location = new System.Drawing.Point(408, 175);
            this.comboBoxCity2.Name = "comboBoxCity2";
            this.comboBoxCity2.Size = new System.Drawing.Size(200, 28);
            this.comboBoxCity2.TabIndex = 28;
            // 
            // comboBoxCountry2
            // 
            this.comboBoxCountry2.FormattingEnabled = true;
            this.comboBoxCountry2.Location = new System.Drawing.Point(208, 175);
            this.comboBoxCountry2.Name = "comboBoxCountry2";
            this.comboBoxCountry2.Size = new System.Drawing.Size(153, 28);
            this.comboBoxCountry2.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(367, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 26;
            this.label9.Text = "City";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Country";
            // 
            // textBoxLat2
            // 
            this.textBoxLat2.Location = new System.Drawing.Point(538, 139);
            this.textBoxLat2.Name = "textBoxLat2";
            this.textBoxLat2.Size = new System.Drawing.Size(70, 26);
            this.textBoxLat2.TabIndex = 24;
            // 
            // textBoxLong2
            // 
            this.textBoxLong2.Location = new System.Drawing.Point(408, 139);
            this.textBoxLong2.Name = "textBoxLong2";
            this.textBoxLong2.Size = new System.Drawing.Size(58, 26);
            this.textBoxLong2.TabIndex = 23;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(19, 71);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(184, 40);
            this.buttonStop.TabIndex = 22;
            this.buttonStop.Text = "Stop!!";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // dataGridViewFutureMapping
            // 
            this.dataGridViewFutureMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFutureMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFutureMapping.Location = new System.Drawing.Point(645, 0);
            this.dataGridViewFutureMapping.Name = "dataGridViewFutureMapping";
            this.dataGridViewFutureMapping.RowHeadersWidth = 62;
            this.dataGridViewFutureMapping.RowTemplate.Height = 28;
            this.dataGridViewFutureMapping.Size = new System.Drawing.Size(776, 230);
            this.dataGridViewFutureMapping.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Increment:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(317, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Start Date:";
            // 
            // comboBoxIncrement
            // 
            this.comboBoxIncrement.FormattingEnabled = true;
            this.comboBoxIncrement.Items.AddRange(new object[] {
            "0.0416667",
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "20",
            "30",
            "100"});
            this.comboBoxIncrement.Location = new System.Drawing.Point(408, 78);
            this.comboBoxIncrement.Name = "comboBoxIncrement";
            this.comboBoxIncrement.Size = new System.Drawing.Size(200, 28);
            this.comboBoxIncrement.TabIndex = 11;
            // 
            // dateTimePickerStartingDate
            // 
            this.dateTimePickerStartingDate.CustomFormat = "yyyy/mm/dd HH:MM";
            this.dateTimePickerStartingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartingDate.Location = new System.Drawing.Point(408, 30);
            this.dateTimePickerStartingDate.Name = "dateTimePickerStartingDate";
            this.dateTimePickerStartingDate.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerStartingDate.TabIndex = 10;
            // 
            // statusStripMain
            // 
            this.statusStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFixed,
            this.toolStripProgressBarStatus,
            this.toolStripStatusLabelNextDate});
            this.statusStripMain.Location = new System.Drawing.Point(0, 230);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(1421, 36);
            this.statusStripMain.TabIndex = 9;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelFixed
            // 
            this.toolStripStatusLabelFixed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelFixed.Name = "toolStripStatusLabelFixed";
            this.toolStripStatusLabelFixed.Size = new System.Drawing.Size(127, 29);
            this.toolStripStatusLabelFixed.Text = "Status Update";
            // 
            // toolStripProgressBarStatus
            // 
            this.toolStripProgressBarStatus.Name = "toolStripProgressBarStatus";
            this.toolStripProgressBarStatus.Size = new System.Drawing.Size(200, 28);
            // 
            // toolStripStatusLabelNextDate
            // 
            this.toolStripStatusLabelNextDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelNextDate.Name = "toolStripStatusLabelNextDate";
            this.toolStripStatusLabelNextDate.Size = new System.Drawing.Size(4, 29);
            // 
            // buttonFuture
            // 
            this.buttonFuture.Location = new System.Drawing.Point(19, 25);
            this.buttonFuture.Name = "buttonFuture";
            this.buttonFuture.Size = new System.Drawing.Size(184, 40);
            this.buttonFuture.TabIndex = 8;
            this.buttonFuture.Text = "Generate Future";
            this.buttonFuture.UseVisualStyleBackColor = true;
            this.buttonFuture.Click += new System.EventHandler(this.buttonFuture_Click);
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.listViewEventDate);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 63);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(646, 99);
            this.panelLeft.TabIndex = 9;
            // 
            // panelButton
            // 
            this.panelButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButton.Controls.Add(this.dataGridViewRelation);
            this.panelButton.Controls.Add(this.panelBottomLeft);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 162);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1423, 193);
            this.panelButton.TabIndex = 10;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.Controls.Add(this.textBoxLongitute);
            this.panelBottomLeft.Controls.Add(this.label6);
            this.panelBottomLeft.Controls.Add(this.buttonRelate);
            this.panelBottomLeft.Controls.Add(this.buttonRemove);
            this.panelBottomLeft.Controls.Add(this.textBoxIdentity);
            this.panelBottomLeft.Controls.Add(this.buttonAdd);
            this.panelBottomLeft.Controls.Add(this.comboBoxCity);
            this.panelBottomLeft.Controls.Add(this.buttonGenerate);
            this.panelBottomLeft.Controls.Add(this.comboBoxCountry);
            this.panelBottomLeft.Controls.Add(this.dateTimePickerEvent);
            this.panelBottomLeft.Controls.Add(this.label5);
            this.panelBottomLeft.Controls.Add(this.textBoxLatitude);
            this.panelBottomLeft.Controls.Add(this.label4);
            this.panelBottomLeft.Controls.Add(this.label1);
            this.panelBottomLeft.Controls.Add(this.label3);
            this.panelBottomLeft.Controls.Add(this.label2);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBottomLeft.Location = new System.Drawing.Point(0, 0);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.Size = new System.Drawing.Size(645, 191);
            this.panelBottomLeft.TabIndex = 19;
            // 
            // textBoxLongitute
            // 
            this.textBoxLongitute.Location = new System.Drawing.Point(350, 76);
            this.textBoxLongitute.Name = "textBoxLongitute";
            this.textBoxLongitute.Size = new System.Drawing.Size(58, 26);
            this.textBoxLongitute.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(83, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Identity";
            // 
            // textBoxIdentity
            // 
            this.textBoxIdentity.Location = new System.Drawing.Point(150, 15);
            this.textBoxIdentity.Name = "textBoxIdentity";
            this.textBoxIdentity.Size = new System.Drawing.Size(338, 26);
            this.textBoxIdentity.TabIndex = 17;
            // 
            // comboBoxCity
            // 
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Location = new System.Drawing.Point(350, 112);
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.Size = new System.Drawing.Size(138, 28);
            this.comboBoxCity.TabIndex = 16;
            this.comboBoxCity.SelectedIndexChanged += new System.EventHandler(this.comboBoxCity_SelectedIndexChanged);
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(150, 112);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(153, 28);
            this.comboBoxCountry.TabIndex = 15;
            this.comboBoxCountry.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountry_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "City";
            // 
            // textBoxLatitude
            // 
            this.textBoxLatitude.Location = new System.Drawing.Point(418, 76);
            this.textBoxLatitude.Name = "textBoxLatitude";
            this.textBoxLatitude.Size = new System.Drawing.Size(70, 26);
            this.textBoxLatitude.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Country";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Effective Date Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(414, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Long";
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.labelFilePath);
            this.panelTop.Controls.Add(this.menuStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1423, 63);
            this.panelTop.TabIndex = 10;
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(12, 40);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(136, 20);
            this.labelFilePath.TabIndex = 1;
            this.labelFilePath.Text = "Empty File Path....";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1423, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(188, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridViewMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(646, 63);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(777, 99);
            this.panelMain.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePickerStartingDate);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.buttonFuture);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.comboBoxIncrement);
            this.panel1.Controls.Add(this.comboBoxCity2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBoxCountry2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxLong2);
            this.panel1.Controls.Add(this.textBoxLat2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(645, 230);
            this.panel1.TabIndex = 31;
            // 
            // RelationFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 623);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RelationFinder";
            this.Text = "RelationFinder";
            this.Load += new System.EventHandler(this.RelationFinder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelation)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFutureMapping)).EndInit();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelBottomLeft.ResumeLayout(false);
            this.panelBottomLeft.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewEventDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEvent;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridViewMain;
        private System.Windows.Forms.DataGridView dataGridViewRelation;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonRelate;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button buttonFuture;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFixed;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNextDate;
        private System.Windows.Forms.ComboBox comboBoxCity;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLatitude;
        private System.Windows.Forms.TextBox textBoxLongitute;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxIdentity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxIncrement;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartingDate;
        private System.Windows.Forms.DataGridView dataGridViewFutureMapping;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxCity2;
        private System.Windows.Forms.ComboBox comboBoxCountry2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxLat2;
        private System.Windows.Forms.TextBox textBoxLong2;
        private System.Windows.Forms.Panel panelBottomLeft;
        private System.Windows.Forms.Panel panel1;
    }
}