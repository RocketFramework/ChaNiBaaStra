using System.Windows.Controls;

namespace ChaNiBaaStra.Configuration
{
    partial class YogaController
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxYogaName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewYogaItem = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.comboBoxPlanetNames = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxHouseNumbers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.dataGridViewYogaListing = new System.Windows.Forms.DataGridView();
            this.panelSeperator = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddToMaster = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxLagnaRashies = new System.Windows.Forms.ComboBox();
            this.comboBoxRashies = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxPlanetRashiRelations = new System.Windows.Forms.ComboBox();
            this.comboBoxEmptyHouseNumbers = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxFilledHouseNumbers = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYogaItem)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYogaListing)).BeginInit();
            this.panelSeperator.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yoga Name";
            // 
            // textBoxYogaName
            // 
            this.textBoxYogaName.Location = new System.Drawing.Point(173, 18);
            this.textBoxYogaName.Name = "textBoxYogaName";
            this.textBoxYogaName.Size = new System.Drawing.Size(369, 26);
            this.textBoxYogaName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Yoga List with Configuration";
            // 
            // dataGridViewYogaItem
            // 
            this.dataGridViewYogaItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYogaItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewYogaItem.Location = new System.Drawing.Point(0, 449);
            this.dataGridViewYogaItem.Name = "dataGridViewYogaItem";
            this.dataGridViewYogaItem.RowHeadersWidth = 62;
            this.dataGridViewYogaItem.RowTemplate.Height = 28;
            this.dataGridViewYogaItem.Size = new System.Drawing.Size(1344, 140);
            this.dataGridViewYogaItem.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1344, 94);
            this.panelTop.TabIndex = 4;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.comboBoxFilledHouseNumbers);
            this.panelBottom.Controls.Add(this.label9);
            this.panelBottom.Controls.Add(this.comboBoxEmptyHouseNumbers);
            this.panelBottom.Controls.Add(this.label8);
            this.panelBottom.Controls.Add(this.comboBoxPlanetRashiRelations);
            this.panelBottom.Controls.Add(this.label7);
            this.panelBottom.Controls.Add(this.comboBoxRashies);
            this.panelBottom.Controls.Add(this.label6);
            this.panelBottom.Controls.Add(this.comboBoxLagnaRashies);
            this.panelBottom.Controls.Add(this.label5);
            this.panelBottom.Controls.Add(this.buttonExit);
            this.panelBottom.Controls.Add(this.buttonAdd);
            this.panelBottom.Controls.Add(this.buttonReset);
            this.panelBottom.Controls.Add(this.comboBoxPlanetNames);
            this.panelBottom.Controls.Add(this.label4);
            this.panelBottom.Controls.Add(this.comboBoxHouseNumbers);
            this.panelBottom.Controls.Add(this.label3);
            this.panelBottom.Controls.Add(this.label1);
            this.panelBottom.Controls.Add(this.textBoxYogaName);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 683);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1344, 246);
            this.panelBottom.TabIndex = 5;
            this.panelBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottom_Paint);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(1219, 199);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(111, 34);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(956, 199);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(111, 34);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(9, 10);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(111, 34);
            this.buttonSelect.TabIndex = 7;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(1073, 199);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(111, 34);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // comboBoxPlanetNames
            // 
            this.comboBoxPlanetNames.AutoCompleteCustomSource.AddRange(new string[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxPlanetNames.FormattingEnabled = true;
            this.comboBoxPlanetNames.Location = new System.Drawing.Point(669, 59);
            this.comboBoxPlanetNames.Name = "comboBoxPlanetNames";
            this.comboBoxPlanetNames.Size = new System.Drawing.Size(210, 28);
            this.comboBoxPlanetNames.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(556, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Planet Name";
            // 
            // comboBoxHouseNumbers
            // 
            this.comboBoxHouseNumbers.FormattingEnabled = true;
            this.comboBoxHouseNumbers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxHouseNumbers.Location = new System.Drawing.Point(174, 59);
            this.comboBoxHouseNumbers.Name = "comboBoxHouseNumbers";
            this.comboBoxHouseNumbers.Size = new System.Drawing.Size(169, 28);
            this.comboBoxHouseNumbers.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "House Number";
            // 
            // panelMiddle
            // 
            this.panelMiddle.AutoScroll = true;
            this.panelMiddle.Controls.Add(this.dataGridViewYogaListing);
            this.panelMiddle.Controls.Add(this.panelSeperator);
            this.panelMiddle.Controls.Add(this.dataGridViewYogaItem);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMiddle.Location = new System.Drawing.Point(0, 94);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(1344, 589);
            this.panelMiddle.TabIndex = 6;
            // 
            // dataGridViewYogaListing
            // 
            this.dataGridViewYogaListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYogaListing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewYogaListing.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewYogaListing.Name = "dataGridViewYogaListing";
            this.dataGridViewYogaListing.RowHeadersWidth = 62;
            this.dataGridViewYogaListing.RowTemplate.Height = 28;
            this.dataGridViewYogaListing.Size = new System.Drawing.Size(1344, 394);
            this.dataGridViewYogaListing.TabIndex = 4;
            // 
            // panelSeperator
            // 
            this.panelSeperator.Controls.Add(this.buttonAddToMaster);
            this.panelSeperator.Controls.Add(this.buttonDelete);
            this.panelSeperator.Controls.Add(this.buttonSelect);
            this.panelSeperator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSeperator.Location = new System.Drawing.Point(0, 394);
            this.panelSeperator.Name = "panelSeperator";
            this.panelSeperator.Size = new System.Drawing.Size(1344, 55);
            this.panelSeperator.TabIndex = 5;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(126, 10);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(111, 34);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // buttonAddToMaster
            // 
            this.buttonAddToMaster.Location = new System.Drawing.Point(243, 10);
            this.buttonAddToMaster.Name = "buttonAddToMaster";
            this.buttonAddToMaster.Size = new System.Drawing.Size(156, 34);
            this.buttonAddToMaster.TabIndex = 10;
            this.buttonAddToMaster.Text = "Add To Master";
            this.buttonAddToMaster.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Lagna Rashi";
            // 
            // comboBoxLagnaRashies
            // 
            this.comboBoxLagnaRashies.FormattingEnabled = true;
            this.comboBoxLagnaRashies.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxLagnaRashies.Location = new System.Drawing.Point(758, 18);
            this.comboBoxLagnaRashies.Name = "comboBoxLagnaRashies";
            this.comboBoxLagnaRashies.Size = new System.Drawing.Size(121, 28);
            this.comboBoxLagnaRashies.TabIndex = 11;
            // 
            // comboBoxRashies
            // 
            this.comboBoxRashies.FormattingEnabled = true;
            this.comboBoxRashies.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxRashies.Location = new System.Drawing.Point(669, 99);
            this.comboBoxRashies.Name = "comboBoxRashies";
            this.comboBoxRashies.Size = new System.Drawing.Size(210, 28);
            this.comboBoxRashies.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(560, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Rashi Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Planet Rashi Relation";
            // 
            // comboBoxPlanetRashiRelations
            // 
            this.comboBoxPlanetRashiRelations.FormattingEnabled = true;
            this.comboBoxPlanetRashiRelations.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxPlanetRashiRelations.Location = new System.Drawing.Point(173, 102);
            this.comboBoxPlanetRashiRelations.Name = "comboBoxPlanetRashiRelations";
            this.comboBoxPlanetRashiRelations.Size = new System.Drawing.Size(369, 28);
            this.comboBoxPlanetRashiRelations.TabIndex = 15;
            // 
            // comboBoxEmptyHouseNumbers
            // 
            this.comboBoxEmptyHouseNumbers.FormattingEnabled = true;
            this.comboBoxEmptyHouseNumbers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxEmptyHouseNumbers.Location = new System.Drawing.Point(173, 146);
            this.comboBoxEmptyHouseNumbers.Name = "comboBoxEmptyHouseNumbers";
            this.comboBoxEmptyHouseNumbers.Size = new System.Drawing.Size(170, 28);
            this.comboBoxEmptyHouseNumbers.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Empty House Number";
            // 
            // comboBoxFilledHouseNumbers
            // 
            this.comboBoxFilledHouseNumbers.FormattingEnabled = true;
            this.comboBoxFilledHouseNumbers.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxFilledHouseNumbers.Location = new System.Drawing.Point(173, 190);
            this.comboBoxFilledHouseNumbers.Name = "comboBoxFilledHouseNumbers";
            this.comboBoxFilledHouseNumbers.Size = new System.Drawing.Size(170, 28);
            this.comboBoxFilledHouseNumbers.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Filled House Number";
            // 
            // YogaController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMiddle);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "YogaController";
            this.Size = new System.Drawing.Size(1344, 929);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYogaItem)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYogaListing)).EndInit();
            this.panelSeperator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxYogaName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewYogaItem;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ComboBox comboBoxPlanetNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxHouseNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.DataGridView dataGridViewYogaListing;
        private System.Windows.Forms.Panel panelSeperator;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ComboBox comboBoxFilledHouseNumbers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxEmptyHouseNumbers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxPlanetRashiRelations;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxRashies;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxLagnaRashies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonAddToMaster;
    }
}
