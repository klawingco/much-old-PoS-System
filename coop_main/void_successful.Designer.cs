namespace coop_main
{
    partial class void_successful
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
            this.btn_no = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_orNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_no);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 278);
            this.panel1.TabIndex = 5;
            // 
            // btn_no
            // 
            this.btn_no.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(137)))), ((int)(((byte)(170)))));
            this.btn_no.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_no.FlatAppearance.BorderSize = 0;
            this.btn_no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_no.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_no.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_no.Location = new System.Drawing.Point(110, 218);
            this.btn_no.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_no.Name = "btn_no";
            this.btn_no.Size = new System.Drawing.Size(123, 34);
            this.btn_no.TabIndex = 25;
            this.btn_no.Text = "Close";
            this.btn_no.UseVisualStyleBackColor = false;
            this.btn_no.Click += new System.EventHandler(this.btn_no_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(209)))), ((int)(((byte)(229)))));
            this.panel2.Controls.Add(this.txt_orNum);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 156);
            this.panel2.TabIndex = 26;
            // 
            // txt_orNum
            // 
            this.txt_orNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_orNum.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_orNum.Location = new System.Drawing.Point(26, 95);
            this.txt_orNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_orNum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_orNum.Name = "txt_orNum";
            this.txt_orNum.ReadOnly = true;
            this.txt_orNum.Size = new System.Drawing.Size(302, 25);
            this.txt_orNum.TabIndex = 5;
            this.txt_orNum.Text = " OR Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "Successful in voiding the\r\nOfficial Receipt Number.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // void_successful
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(137)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(376, 306);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "void_successful";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "void_successful";
            this.Load += new System.EventHandler(this.void_successful_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_no;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_orNum;
        private System.Windows.Forms.Label label1;
    }
}