namespace SalesDelivery.Forms
{
    partial class About
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
            this.lbName = new System.Windows.Forms.Label();
            this.lbVersion = new System.Windows.Forms.Label();
            this.lbDesc = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbDbFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lbName.ForeColor = System.Drawing.Color.White;
            this.lbName.Location = new System.Drawing.Point(3, 20);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(234, 34);
            this.lbName.Text = "label1";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbVersion
            // 
            this.lbVersion.ForeColor = System.Drawing.Color.White;
            this.lbVersion.Location = new System.Drawing.Point(72, 109);
            this.lbVersion.Name = "lbVersion";
            this.lbVersion.Size = new System.Drawing.Size(165, 20);
            this.lbVersion.Text = "label1";
            this.lbVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDesc
            // 
            this.lbDesc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbDesc.ForeColor = System.Drawing.Color.White;
            this.lbDesc.Location = new System.Drawing.Point(6, 59);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(234, 38);
            this.lbDesc.Text = "label1";
            this.lbDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "OK";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDbFile
            // 
            this.lbDbFile.ForeColor = System.Drawing.Color.White;
            this.lbDbFile.Location = new System.Drawing.Point(6, 141);
            this.lbDbFile.Name = "lbDbFile";
            this.lbDbFile.Size = new System.Drawing.Size(231, 36);
            this.lbDbFile.Text = "label1";
            this.lbDbFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.ControlBox = false;
            this.Controls.Add(this.lbDbFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbDesc);
            this.Controls.Add(this.lbVersion);
            this.Controls.Add(this.lbName);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Text = "About";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbVersion;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbDbFile;
    }
}