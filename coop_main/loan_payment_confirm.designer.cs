namespace coop_main
{
    partial class loan_payment_confirm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_paymenAmount = new System.Windows.Forms.TextBox();
            this.txt_membersName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_conPirnt = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_conPirnt);
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Location = new System.Drawing.Point(14, 14);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 278);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(160)))));
            this.panel2.Controls.Add(this.txt_paymenAmount);
            this.panel2.Controls.Add(this.txt_membersName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 169);
            this.panel2.TabIndex = 26;
            // 
            // txt_paymenAmount
            // 
            this.txt_paymenAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_paymenAmount.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paymenAmount.Location = new System.Drawing.Point(23, 112);
            this.txt_paymenAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_paymenAmount.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_paymenAmount.Name = "txt_paymenAmount";
            this.txt_paymenAmount.ReadOnly = true;
            this.txt_paymenAmount.Size = new System.Drawing.Size(304, 25);
            this.txt_paymenAmount.TabIndex = 42;
            this.txt_paymenAmount.Text = " Loan Payment Amount";
            // 
            // txt_membersName
            // 
            this.txt_membersName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_membersName.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_membersName.Location = new System.Drawing.Point(23, 70);
            this.txt_membersName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_membersName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_membersName.Name = "txt_membersName";
            this.txt_membersName.ReadOnly = true;
            this.txt_membersName.Size = new System.Drawing.Size(304, 25);
            this.txt_membersName.TabIndex = 41;
            this.txt_membersName.Text = " Member\'s Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Continue Loan Payment?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_conPirnt
            // 
            this.btn_conPirnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.btn_conPirnt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_conPirnt.FlatAppearance.BorderSize = 0;
            this.btn_conPirnt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_conPirnt.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conPirnt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_conPirnt.Location = new System.Drawing.Point(23, 215);
            this.btn_conPirnt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_conPirnt.Name = "btn_conPirnt";
            this.btn_conPirnt.Size = new System.Drawing.Size(141, 38);
            this.btn_conPirnt.TabIndex = 33;
            this.btn_conPirnt.Text = "Continue and Print";
            this.btn_conPirnt.UseVisualStyleBackColor = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cancel.Location = new System.Drawing.Point(193, 215);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(134, 38);
            this.btn_cancel.TabIndex = 32;
            this.btn_cancel.Text = "Cancel ";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // loan_payment_confirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(376, 306);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "loan_payment_confirm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "loan_payment_confirm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_conPirnt;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_paymenAmount;
        private System.Windows.Forms.TextBox txt_membersName;
        private System.Windows.Forms.Label label1;
    }
}