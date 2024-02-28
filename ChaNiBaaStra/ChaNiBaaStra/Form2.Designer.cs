namespace ChaNiBaaStra
{
    partial class Form2
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
            this.richTextBoxMainText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxMainCode = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonAppend = new System.Windows.Forms.Button();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxHouseNumber = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxMainText
            // 
            this.richTextBoxMainText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMainText.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxMainText.Name = "richTextBoxMainText";
            this.richTextBoxMainText.Size = new System.Drawing.Size(473, 443);
            this.richTextBoxMainText.TabIndex = 0;
            this.richTextBoxMainText.Text = "";
            // 
            // richTextBoxMainCode
            // 
            this.richTextBoxMainCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMainCode.Location = new System.Drawing.Point(491, 12);
            this.richTextBoxMainCode.Name = "richTextBoxMainCode";
            this.richTextBoxMainCode.Size = new System.Drawing.Size(473, 443);
            this.richTextBoxMainCode.TabIndex = 1;
            this.richTextBoxMainCode.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxHouseNumber);
            this.panel1.Controls.Add(this.buttonAppend);
            this.panel1.Controls.Add(this.buttonGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 54);
            this.panel1.TabIndex = 2;
            // 
            // buttonAppend
            // 
            this.buttonAppend.Location = new System.Drawing.Point(184, 3);
            this.buttonAppend.Name = "buttonAppend";
            this.buttonAppend.Size = new System.Drawing.Size(139, 39);
            this.buttonAppend.TabIndex = 1;
            this.buttonAppend.Text = "Append";
            this.buttonAppend.UseVisualStyleBackColor = true;
            this.buttonAppend.Click += new System.EventHandler(this.buttonAppend_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(346, 3);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(139, 39);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxHouseNumber
            // 
            this.textBoxHouseNumber.Location = new System.Drawing.Point(799, 15);
            this.textBoxHouseNumber.Name = "textBoxHouseNumber";
            this.textBoxHouseNumber.Size = new System.Drawing.Size(100, 26);
            this.textBoxHouseNumber.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 515);
            this.Controls.Add(this.richTextBoxMainCode);
            this.Controls.Add(this.richTextBoxMainText);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxMainText;
        private System.Windows.Forms.RichTextBox richTextBoxMainCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonAppend;
        private System.Windows.Forms.TextBox textBoxHouseNumber;
    }
}