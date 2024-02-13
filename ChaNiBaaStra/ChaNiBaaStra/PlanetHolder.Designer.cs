namespace ChaNiBaaStra
{
    partial class PlanetHolder
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonMiddle = new System.Windows.Forms.Button();
            this.labelLeft = new System.Windows.Forms.Label();
            this.labelBottom = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.toolTipPlanet = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonMiddle
            // 
            this.buttonMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMiddle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMiddle.Location = new System.Drawing.Point(13, 14);
            this.buttonMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMiddle.Name = "buttonMiddle";
            this.buttonMiddle.Size = new System.Drawing.Size(42, 18);
            this.buttonMiddle.TabIndex = 0;
            this.buttonMiddle.Text = "Mo";
            this.buttonMiddle.UseVisualStyleBackColor = true;
            this.buttonMiddle.MouseHover += new System.EventHandler(this.buttonMiddle_MouseHover);
            // 
            // labelLeft
            // 
            this.labelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeft.Location = new System.Drawing.Point(0, 14);
            this.labelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.labelLeft.Name = "labelLeft";
            this.labelLeft.Size = new System.Drawing.Size(13, 18);
            this.labelLeft.TabIndex = 2;
            this.labelLeft.Text = "M";
            this.labelLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBottom
            // 
            this.labelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBottom.Location = new System.Drawing.Point(0, 32);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(55, 13);
            this.labelBottom.TabIndex = 3;
            this.labelBottom.Text = "V";
            this.labelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBottom.MouseHover += new System.EventHandler(this.labelBottom_MouseHover);
            // 
            // labelTop
            // 
            this.labelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTop.Location = new System.Drawing.Point(0, 0);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(55, 14);
            this.labelTop.TabIndex = 4;
            this.labelTop.Text = "NMS";
            this.labelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTop.MouseHover += new System.EventHandler(this.labelTop_MouseHover);
            // 
            // toolTipPlanet
            // 
            this.toolTipPlanet.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipPlanet.ToolTipTitle = "General Infomation";
            // 
            // PlanetHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonMiddle);
            this.Controls.Add(this.labelLeft);
            this.Controls.Add(this.labelBottom);
            this.Controls.Add(this.labelTop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PlanetHolder";
            this.Size = new System.Drawing.Size(55, 45);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonMiddle;
        private System.Windows.Forms.Label labelLeft;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.Label labelTop;
        private System.Windows.Forms.ToolTip toolTipPlanet;
    }
}
