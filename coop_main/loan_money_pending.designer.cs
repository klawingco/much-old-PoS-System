namespace coop_main
{
    partial class loan_money_pending
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
            this.btn_okay = new System.Windows.Forms.Button();
            this.btn_viewLogs = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_membersName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_okay);
            this.panel1.Controls.Add(this.btn_viewLogs);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 278);
            this.panel1.TabIndex = 9;
            // 
            // btn_okay
            // 
            this.btn_okay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(73)))), ((int)(((byte)(60)))));
            this.btn_okay.FlatAppearance.BorderSize = 0;
            this.btn_okay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_okay.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_okay.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_okay.Location = new System.Drawing.Point(23, 215);
            this.btn_okay.Margin = new System.Windows.Forms.Padding(2);
            this.btn_okay.Name = "btn_okay";
            this.btn_okay.Size = new System.Drawing.Size(141, 38);
            this.btn_okay.TabIndex = 33;
            this.btn_okay.Text = "Okay";
            this.btn_okay.UseVisualStyleBackColor = false;
            // 
            // btn_viewLogs
            // 
            this.btn_viewLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(73)))), ((int)(((byte)(60)))));
            this.btn_viewLogs.FlatAppearance.BorderSize = 0;
            this.btn_viewLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_viewLogs.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_viewLogs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_viewLogs.Location = new System.Drawing.Point(193, 215);
            this.btn_viewLogs.Margin = new System.Windows.Forms.Padding(2);
            this.btn_viewLogs.Name = "btn_viewLogs";
            this.btn_viewLogs.Size = new System.Drawing.Size(134, 38);
            this.btn_viewLogs.TabIndex = 32;
            this.btn_viewLogs.Text = "View Logs";
            this.btn_viewLogs.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(239)))), ((int)(((byte)(178)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_membersName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 169);
            this.panel2.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 22);
            this.label2.TabIndex = 42;
            this.label2.Text = "still has pending balance";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_membersName
            // 
            this.txt_membersName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_membersName.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_membersName.Location = new System.Drawing.Point(23, 70);
            this.txt_membersName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_membersName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_membersName.Name = "txt_membersName";
            this.txt_membersName.Size = new System.Drawing.Size(304, 25);
            this.txt_membersName.TabIndex = 41;
            this.txt_membersName.Text = " Member\'s Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cannot Continue Loan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loan_money_pending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(73)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(376, 306);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "loan_money_pending";
            this.Text = "loan_money_pending";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_okay;
        private System.Windows.Forms.Button btn_viewLogs;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_membersName;
    }
}