namespace coop_main
{
    partial class CapturePhoto
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
            this.vspCam1 = new AForge.Controls.VideoSourcePlayer();
            this.cmbDevList = new System.Windows.Forms.ComboBox();
            this.btn_cap = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.cmbReso = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // vspCam1
            // 
            this.vspCam1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.vspCam1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.vspCam1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.vspCam1.ForeColor = System.Drawing.Color.White;
            this.vspCam1.Location = new System.Drawing.Point(12, 67);
            this.vspCam1.Name = "vspCam1";
            this.vspCam1.Size = new System.Drawing.Size(386, 287);
            this.vspCam1.TabIndex = 49;
            this.vspCam1.Text = "KL!!!";
            this.vspCam1.VideoSource = null;
            // 
            // cmbDevList
            // 
            this.cmbDevList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevList.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevList.FormattingEnabled = true;
            this.cmbDevList.Location = new System.Drawing.Point(12, 7);
            this.cmbDevList.Name = "cmbDevList";
            this.cmbDevList.Size = new System.Drawing.Size(195, 24);
            this.cmbDevList.TabIndex = 50;
            this.cmbDevList.SelectedIndexChanged += new System.EventHandler(this.cmbDevList_SelectedIndexChanged);
            // 
            // btn_cap
            // 
            this.btn_cap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(73)))), ((int)(((byte)(60)))));
            this.btn_cap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cap.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cap.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cap.Location = new System.Drawing.Point(230, 12);
            this.btn_cap.Name = "btn_cap";
            this.btn_cap.Size = new System.Drawing.Size(81, 41);
            this.btn_cap.TabIndex = 51;
            this.btn_cap.Text = "Capture";
            this.btn_cap.UseVisualStyleBackColor = false;
            this.btn_cap.Click += new System.EventHandler(this.btn_cap_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(73)))), ((int)(((byte)(60)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_cancel.Location = new System.Drawing.Point(317, 12);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(81, 41);
            this.btn_cancel.TabIndex = 52;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // cmbReso
            // 
            this.cmbReso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReso.Font = new System.Drawing.Font("Mobile Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReso.FormattingEnabled = true;
            this.cmbReso.Location = new System.Drawing.Point(12, 37);
            this.cmbReso.Name = "cmbReso";
            this.cmbReso.Size = new System.Drawing.Size(130, 24);
            this.cmbReso.TabIndex = 53;
            // 
            // CapturePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(239)))), ((int)(((byte)(178)))));
            this.ClientSize = new System.Drawing.Size(410, 366);
            this.ControlBox = false;
            this.Controls.Add(this.cmbReso);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_cap);
            this.Controls.Add(this.cmbDevList);
            this.Controls.Add(this.vspCam1);
            this.Name = "CapturePhoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Capture Photo";
            this.Load += new System.EventHandler(this.CapturePhoto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer vspCam1;
        private System.Windows.Forms.ComboBox cmbDevList;
        private System.Windows.Forms.Button btn_cap;
        private System.Windows.Forms.ComboBox cmbReso;
        public System.Windows.Forms.Button btn_cancel;
    }
}