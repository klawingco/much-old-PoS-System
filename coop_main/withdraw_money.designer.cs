namespace coop_main
{
    partial class withdraw_money
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
            this.label4 = new System.Windows.Forms.Label();
            this.txt_currSavings = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_conDep = new System.Windows.Forms.Button();
            this.btn_newDep = new System.Windows.Forms.Button();
            this.btn_canDep = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_processDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_processBy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_amtWithdraw = new System.Windows.Forms.TextBox();
            this.btn_thumb = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_currSavings);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.btn_conDep);
            this.panel1.Controls.Add(this.btn_newDep);
            this.panel1.Controls.Add(this.btn_canDep);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_processDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_processBy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_amtWithdraw);
            this.panel1.Controls.Add(this.btn_thumb);
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 372);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(160)))));
            this.label4.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(7, 167);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 50;
            this.label4.Text = "Withdraw Amt:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_currSavings
            // 
            this.txt_currSavings.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_currSavings.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_currSavings.Location = new System.Drawing.Point(147, 117);
            this.txt_currSavings.Margin = new System.Windows.Forms.Padding(2);
            this.txt_currSavings.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_currSavings.Name = "txt_currSavings";
            this.txt_currSavings.Size = new System.Drawing.Size(304, 25);
            this.txt_currSavings.TabIndex = 49;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(14, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(437, 68);
            this.listBox1.TabIndex = 48;
            this.listBox1.Visible = false;
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // btn_conDep
            // 
            this.btn_conDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.btn_conDep.FlatAppearance.BorderSize = 0;
            this.btn_conDep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_conDep.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_conDep.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_conDep.Location = new System.Drawing.Point(319, 313);
            this.btn_conDep.Margin = new System.Windows.Forms.Padding(2);
            this.btn_conDep.Name = "btn_conDep";
            this.btn_conDep.Size = new System.Drawing.Size(134, 44);
            this.btn_conDep.TabIndex = 47;
            this.btn_conDep.Text = "Continue Withdraw";
            this.btn_conDep.UseVisualStyleBackColor = false;
            this.btn_conDep.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_newDep
            // 
            this.btn_newDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.btn_newDep.FlatAppearance.BorderSize = 0;
            this.btn_newDep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_newDep.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newDep.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_newDep.Location = new System.Drawing.Point(165, 313);
            this.btn_newDep.Margin = new System.Windows.Forms.Padding(2);
            this.btn_newDep.Name = "btn_newDep";
            this.btn_newDep.Size = new System.Drawing.Size(131, 44);
            this.btn_newDep.TabIndex = 46;
            this.btn_newDep.Text = "New Withdraw";
            this.btn_newDep.UseVisualStyleBackColor = false;
            this.btn_newDep.Click += new System.EventHandler(this.btn_newDep_Click);
            // 
            // btn_canDep
            // 
            this.btn_canDep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.btn_canDep.FlatAppearance.BorderSize = 0;
            this.btn_canDep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_canDep.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_canDep.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_canDep.Location = new System.Drawing.Point(12, 313);
            this.btn_canDep.Margin = new System.Windows.Forms.Padding(2);
            this.btn_canDep.Name = "btn_canDep";
            this.btn_canDep.Size = new System.Drawing.Size(131, 44);
            this.btn_canDep.TabIndex = 45;
            this.btn_canDep.Text = "Cancel Withdraw";
            this.btn_canDep.UseVisualStyleBackColor = false;
            this.btn_canDep.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(160)))));
            this.label3.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(10, 264);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 44;
            this.label3.Text = "Process Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_processDate
            // 
            this.txt_processDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_processDate.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_processDate.Location = new System.Drawing.Point(148, 261);
            this.txt_processDate.Margin = new System.Windows.Forms.Padding(2);
            this.txt_processDate.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_processDate.Name = "txt_processDate";
            this.txt_processDate.ReadOnly = true;
            this.txt_processDate.Size = new System.Drawing.Size(303, 25);
            this.txt_processDate.TabIndex = 43;
            this.txt_processDate.TextChanged += new System.EventHandler(this.txt_processDate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(160)))));
            this.label2.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 217);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 42;
            this.label2.Text = "Processed by:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txt_processBy
            // 
            this.txt_processBy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_processBy.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_processBy.Location = new System.Drawing.Point(147, 214);
            this.txt_processBy.Margin = new System.Windows.Forms.Padding(2);
            this.txt_processBy.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_processBy.Name = "txt_processBy";
            this.txt_processBy.ReadOnly = true;
            this.txt_processBy.Size = new System.Drawing.Size(303, 25);
            this.txt_processBy.TabIndex = 41;
            this.txt_processBy.TextChanged += new System.EventHandler(this.txt_processBy_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(235)))), ((int)(((byte)(160)))));
            this.label1.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Current Savings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_amtWithdraw
            // 
            this.txt_amtWithdraw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_amtWithdraw.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amtWithdraw.Location = new System.Drawing.Point(147, 167);
            this.txt_amtWithdraw.Margin = new System.Windows.Forms.Padding(2);
            this.txt_amtWithdraw.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_amtWithdraw.Name = "txt_amtWithdraw";
            this.txt_amtWithdraw.Size = new System.Drawing.Size(305, 25);
            this.txt_amtWithdraw.TabIndex = 26;
            this.txt_amtWithdraw.TextChanged += new System.EventHandler(this.txt_initialDep_TextChanged);
            this.txt_amtWithdraw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_initialDep_KeyPress);
            // 
            // btn_thumb
            // 
            this.btn_thumb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.btn_thumb.FlatAppearance.BorderSize = 0;
            this.btn_thumb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thumb.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thumb.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_thumb.Location = new System.Drawing.Point(117, 53);
            this.btn_thumb.Margin = new System.Windows.Forms.Padding(2);
            this.btn_thumb.Name = "btn_thumb";
            this.btn_thumb.Size = new System.Drawing.Size(222, 44);
            this.btn_thumb.TabIndex = 25;
            this.btn_thumb.Text = "Search Via Thumbprint";
            this.btn_thumb.UseVisualStyleBackColor = false;
            this.btn_thumb.Click += new System.EventHandler(this.btn_thumb_Click);
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_name.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(11, 14);
            this.txt_name.Margin = new System.Windows.Forms.Padding(2);
            this.txt_name.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(440, 25);
            this.txt_name.TabIndex = 2;
            this.txt_name.Text = " Customer\'s Name";
            this.txt_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_name_KeyDown);
            this.txt_name.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_name_KeyUp);
            // 
            // withdraw_money
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(140)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(481, 392);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "withdraw_money";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "initial_deposit";
            this.Load += new System.EventHandler(this.initial_deposit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_amtWithdraw;
        private System.Windows.Forms.Button btn_thumb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_processDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_processBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_conDep;
        private System.Windows.Forms.Button btn_newDep;
        private System.Windows.Forms.Button btn_canDep;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_currSavings;
    }
}