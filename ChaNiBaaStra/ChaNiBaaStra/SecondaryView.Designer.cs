namespace ChaNiBaaStra
{
    partial class SecondaryView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondaryView));
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageNawamsa = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelRight = new System.Windows.Forms.Panel();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.splitterH = new System.Windows.Forms.Splitter();
            this.NawamsaView = new ChaNiBaaStra.AlternativeView();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageNawamsa.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControlMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1007, 787);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageNawamsa);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1007, 787);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageNawamsa
            // 
            this.tabPageNawamsa.AutoScroll = true;
            this.tabPageNawamsa.Controls.Add(this.NawamsaView);
            this.tabPageNawamsa.Location = new System.Drawing.Point(4, 29);
            this.tabPageNawamsa.Name = "tabPageNawamsa";
            this.tabPageNawamsa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNawamsa.Size = new System.Drawing.Size(999, 754);
            this.tabPageNawamsa.TabIndex = 0;
            this.tabPageNawamsa.Text = "Nawamsa";
            this.tabPageNawamsa.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(999, 754);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.textBoxData);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1017, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(261, 787);
            this.panelRight.TabIndex = 1;
            // 
            // textBoxData
            // 
            this.textBoxData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxData.Location = new System.Drawing.Point(0, 0);
            this.textBoxData.Multiline = true;
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(261, 787);
            this.textBoxData.TabIndex = 0;
            // 
            // splitterH
            // 
            this.splitterH.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterH.Location = new System.Drawing.Point(1007, 0);
            this.splitterH.Name = "splitterH";
            this.splitterH.Size = new System.Drawing.Size(10, 787);
            this.splitterH.TabIndex = 2;
            this.splitterH.TabStop = false;
            // 
            // NawamsaView
            // 
            this.NawamsaView.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NawamsaView.BackgroundImage")));
            this.NawamsaView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NawamsaView.Location = new System.Drawing.Point(6, 6);
            this.NawamsaView.Name = "NawamsaView";
            this.NawamsaView.Size = new System.Drawing.Size(885, 651);
            this.NawamsaView.TabIndex = 0;
            // 
            // SecondaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 787);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.splitterH);
            this.Controls.Add(this.panelRight);
            this.Name = "SecondaryView";
            this.Text = "SecondaryView";
            this.panelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageNawamsa.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageNawamsa;
        private AlternativeView NawamsaView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Splitter splitterH;
        private System.Windows.Forms.TextBox textBoxData;
    }
}