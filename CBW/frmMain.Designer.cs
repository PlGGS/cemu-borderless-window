namespace CBW
{
    partial class frmMain
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
            this.lblCBW = new System.Windows.Forms.Label();
            this.chkCBW = new System.Windows.Forms.CheckBox();
            this.chkShowMenuStrip = new System.Windows.Forms.CheckBox();
            this.lblShowMenuStrip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCBW
            // 
            this.lblCBW.AutoSize = true;
            this.lblCBW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCBW.Location = new System.Drawing.Point(7, 9);
            this.lblCBW.Name = "lblCBW";
            this.lblCBW.Size = new System.Drawing.Size(128, 16);
            this.lblCBW.TabIndex = 0;
            this.lblCBW.Text = "Borderless Window:";
            // 
            // chkCBW
            // 
            this.chkCBW.AutoSize = true;
            this.chkCBW.Location = new System.Drawing.Point(179, 11);
            this.chkCBW.Name = "chkCBW";
            this.chkCBW.Size = new System.Drawing.Size(15, 14);
            this.chkCBW.TabIndex = 1;
            this.chkCBW.UseVisualStyleBackColor = true;
            this.chkCBW.CheckedChanged += new System.EventHandler(this.chkCBW_CheckedChanged);
            // 
            // chkShowMenuStrip
            // 
            this.chkShowMenuStrip.AutoSize = true;
            this.chkShowMenuStrip.Location = new System.Drawing.Point(179, 35);
            this.chkShowMenuStrip.Name = "chkShowMenuStrip";
            this.chkShowMenuStrip.Size = new System.Drawing.Size(15, 14);
            this.chkShowMenuStrip.TabIndex = 3;
            this.chkShowMenuStrip.UseVisualStyleBackColor = true;
            this.chkShowMenuStrip.CheckedChanged += new System.EventHandler(this.chkShowMenuStrip_CheckedChanged);
            // 
            // lblShowMenuStrip
            // 
            this.lblShowMenuStrip.AutoSize = true;
            this.lblShowMenuStrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowMenuStrip.Location = new System.Drawing.Point(7, 33);
            this.lblShowMenuStrip.Name = "lblShowMenuStrip";
            this.lblShowMenuStrip.Size = new System.Drawing.Size(110, 16);
            this.lblShowMenuStrip.TabIndex = 2;
            this.lblShowMenuStrip.Text = "Show Menu Strip:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 57);
            this.Controls.Add(this.chkShowMenuStrip);
            this.Controls.Add(this.lblShowMenuStrip);
            this.Controls.Add(this.chkCBW);
            this.Controls.Add(this.lblCBW);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "CBW 1.1.1 - Blake Boris";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCBW;
        private System.Windows.Forms.CheckBox chkCBW;
        private System.Windows.Forms.CheckBox chkShowMenuStrip;
        private System.Windows.Forms.Label lblShowMenuStrip;
    }
}

