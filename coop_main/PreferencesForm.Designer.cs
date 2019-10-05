namespace coop_main
{
    partial class PreferencesForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_serverip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_serverhost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_serverport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_serverdb = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_saveEdit = new System.Windows.Forms.Button();
            this.txt_connUserID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_connUserPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_ping = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 186);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_serverdb);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_serverport);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txt_serverhost);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txt_serverip);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(352, 159);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_ping);
            this.tabPage2.Controls.Add(this.txt_connUserPass);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txt_connUserID);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(352, 159);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Credentials";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mobile Sans", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 75;
            this.label1.Text = "Preferences";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server IP";
            // 
            // txt_serverip
            // 
            this.txt_serverip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_serverip.Location = new System.Drawing.Point(133, 12);
            this.txt_serverip.Name = "txt_serverip";
            this.txt_serverip.ReadOnly = true;
            this.txt_serverip.Size = new System.Drawing.Size(213, 22);
            this.txt_serverip.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Host URL";
            // 
            // txt_serverhost
            // 
            this.txt_serverhost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_serverhost.Location = new System.Drawing.Point(133, 47);
            this.txt_serverhost.Name = "txt_serverhost";
            this.txt_serverhost.ReadOnly = true;
            this.txt_serverhost.Size = new System.Drawing.Size(213, 22);
            this.txt_serverhost.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "PORT";
            // 
            // txt_serverport
            // 
            this.txt_serverport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_serverport.Location = new System.Drawing.Point(133, 83);
            this.txt_serverport.Name = "txt_serverport";
            this.txt_serverport.ReadOnly = true;
            this.txt_serverport.Size = new System.Drawing.Size(213, 22);
            this.txt_serverport.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "DATABASE";
            // 
            // txt_serverdb
            // 
            this.txt_serverdb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_serverdb.Location = new System.Drawing.Point(133, 119);
            this.txt_serverdb.Name = "txt_serverdb";
            this.txt_serverdb.ReadOnly = true;
            this.txt_serverdb.Size = new System.Drawing.Size(213, 22);
            this.txt_serverdb.TabIndex = 7;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Location = new System.Drawing.Point(191, 227);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 33);
            this.btn_Cancel.TabIndex = 77;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_saveEdit
            // 
            this.btn_saveEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveEdit.Location = new System.Drawing.Point(110, 227);
            this.btn_saveEdit.Name = "btn_saveEdit";
            this.btn_saveEdit.Size = new System.Drawing.Size(75, 33);
            this.btn_saveEdit.TabIndex = 76;
            this.btn_saveEdit.Tag = "EDIT";
            this.btn_saveEdit.Text = "EDIT";
            this.btn_saveEdit.UseVisualStyleBackColor = true;
            this.btn_saveEdit.Click += new System.EventHandler(this.btn_saveEdit_Click);
            // 
            // txt_connUserID
            // 
            this.txt_connUserID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_connUserID.Location = new System.Drawing.Point(133, 42);
            this.txt_connUserID.Name = "txt_connUserID";
            this.txt_connUserID.ReadOnly = true;
            this.txt_connUserID.Size = new System.Drawing.Size(213, 22);
            this.txt_connUserID.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "User ID";
            // 
            // txt_connUserPass
            // 
            this.txt_connUserPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_connUserPass.Location = new System.Drawing.Point(133, 68);
            this.txt_connUserPass.Name = "txt_connUserPass";
            this.txt_connUserPass.ReadOnly = true;
            this.txt_connUserPass.Size = new System.Drawing.Size(213, 22);
            this.txt_connUserPass.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Password";
            // 
            // btn_ping
            // 
            this.btn_ping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ping.Location = new System.Drawing.Point(133, 108);
            this.btn_ping.Name = "btn_ping";
            this.btn_ping.Size = new System.Drawing.Size(75, 33);
            this.btn_ping.TabIndex = 77;
            this.btn_ping.Text = "PING";
            this.btn_ping.UseVisualStyleBackColor = true;
            this.btn_ping.Click += new System.EventHandler(this.btn_ping_Click);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_saveEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Mobile Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_serverip;
        private System.Windows.Forms.TextBox txt_serverhost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_serverport;
        private System.Windows.Forms.TextBox txt_serverdb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_saveEdit;
        private System.Windows.Forms.TextBox txt_connUserPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_connUserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_ping;
    }
}