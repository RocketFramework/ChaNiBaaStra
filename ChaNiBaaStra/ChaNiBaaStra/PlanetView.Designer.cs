namespace ChaNiBaaStra
{
    partial class PlanetView
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
            this.components = new System.ComponentModel.Container();
            this.buttonPlnet = new System.Windows.Forms.Button();
            this.buttonRashiRelation = new System.Windows.Forms.Button();
            this.buttonPlanetRelation = new System.Windows.Forms.Button();
            this.panelVargoththama = new System.Windows.Forms.Panel();
            this.panelOtherPlanetSeeMe = new System.Windows.Forms.Panel();
            this.toolTipPlanet = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonPlnet
            // 
            this.buttonPlnet.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlnet.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonPlnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlnet.ForeColor = System.Drawing.Color.Black;
            this.buttonPlnet.Location = new System.Drawing.Point(9, 8);
            this.buttonPlnet.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlnet.Name = "buttonPlnet";
            this.buttonPlnet.Size = new System.Drawing.Size(45, 30);
            this.buttonPlnet.TabIndex = 0;
            this.buttonPlnet.Text = "Su";
            this.buttonPlnet.UseVisualStyleBackColor = false;
            this.buttonPlnet.Click += new System.EventHandler(this.buttonPlnet_Click);
            // 
            // buttonRashiRelation
            // 
            this.buttonRashiRelation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRashiRelation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRashiRelation.Location = new System.Drawing.Point(67, 10);
            this.buttonRashiRelation.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRashiRelation.Name = "buttonRashiRelation";
            this.buttonRashiRelation.Size = new System.Drawing.Size(10, 13);
            this.buttonRashiRelation.TabIndex = 1;
            this.buttonRashiRelation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRashiRelation.UseVisualStyleBackColor = false;
            // 
            // buttonPlanetRelation
            // 
            this.buttonPlanetRelation.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPlanetRelation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPlanetRelation.Location = new System.Drawing.Point(67, 27);
            this.buttonPlanetRelation.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlanetRelation.Name = "buttonPlanetRelation";
            this.buttonPlanetRelation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonPlanetRelation.Size = new System.Drawing.Size(10, 13);
            this.buttonPlanetRelation.TabIndex = 2;
            this.buttonPlanetRelation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonPlanetRelation.UseVisualStyleBackColor = false;
            // 
            // panelVargoththama
            // 
            this.panelVargoththama.AutoScroll = true;
            this.panelVargoththama.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panelVargoththama.Location = new System.Drawing.Point(6, 5);
            this.panelVargoththama.Name = "panelVargoththama";
            this.panelVargoththama.Size = new System.Drawing.Size(51, 36);
            this.panelVargoththama.TabIndex = 3;
            this.panelVargoththama.Visible = false;
            // 
            // panelOtherPlanetSeeMe
            // 
            this.panelOtherPlanetSeeMe.BackgroundImage = global::ChaNiBaaStra.Properties.Resources.SeeIncon1;
            this.panelOtherPlanetSeeMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelOtherPlanetSeeMe.Location = new System.Drawing.Point(15, -3);
            this.panelOtherPlanetSeeMe.Name = "panelOtherPlanetSeeMe";
            this.panelOtherPlanetSeeMe.Size = new System.Drawing.Size(25, 12);
            this.panelOtherPlanetSeeMe.TabIndex = 4;
            this.panelOtherPlanetSeeMe.Visible = false;
            // 
            // PlanetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelOtherPlanetSeeMe);
            this.Controls.Add(this.buttonPlanetRelation);
            this.Controls.Add(this.buttonRashiRelation);
            this.Controls.Add(this.buttonPlnet);
            this.Controls.Add(this.panelVargoththama);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PlanetView";
            this.Size = new System.Drawing.Size(78, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlnet;
        private System.Windows.Forms.Button buttonRashiRelation;
        private System.Windows.Forms.Button buttonPlanetRelation;
        private System.Windows.Forms.Panel panelVargoththama;
        private System.Windows.Forms.Panel panelOtherPlanetSeeMe;
        private System.Windows.Forms.ToolTip toolTipPlanet;
    }
}
