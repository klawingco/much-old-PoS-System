namespace coop_main
{
    partial class openregister2
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listViewPurchased = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.btn_printReciept = new System.Windows.Forms.Button();
            this.txt_invoiceNum = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_checkNum = new System.Windows.Forms.TextBox();
            this.rb_manager = new System.Windows.Forms.RadioButton();
            this.rb_personal = new System.Windows.Forms.RadioButton();
            this.rb_check = new System.Windows.Forms.RadioButton();
            this.rb_masterCard = new System.Windows.Forms.RadioButton();
            this.rb_amex = new System.Windows.Forms.RadioButton();
            this.rb_visa = new System.Windows.Forms.RadioButton();
            this.txt_changeAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rb_debitCard = new System.Windows.Forms.RadioButton();
            this.rb_cash = new System.Windows.Forms.RadioButton();
            this.txt_enterAmount = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(209)))), ((int)(((byte)(229)))));
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.listViewPurchased);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.rb_check);
            this.panel2.Controls.Add(this.rb_masterCard);
            this.panel2.Controls.Add(this.rb_amex);
            this.panel2.Controls.Add(this.rb_visa);
            this.panel2.Controls.Add(this.txt_changeAmount);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.rb_debitCard);
            this.panel2.Controls.Add(this.rb_cash);
            this.panel2.Controls.Add(this.txt_enterAmount);
            this.panel2.Location = new System.Drawing.Point(42, 164);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 555);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalExtent = 100;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(462, 82);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(384, 324);
            this.listBox1.TabIndex = 35;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.listBox1_MeasureItem);
            // 
            // listViewPurchased
            // 
            this.listViewPurchased.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3});
            this.listViewPurchased.Location = new System.Drawing.Point(163, 261);
            this.listViewPurchased.Name = "listViewPurchased";
            this.listViewPurchased.Size = new System.Drawing.Size(267, 97);
            this.listViewPurchased.TabIndex = 36;
            this.listViewPurchased.UseCompatibleStateImageBehavior = false;
            this.listViewPurchased.View = System.Windows.Forms.View.Details;
            this.listViewPurchased.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item Name";
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 2;
            this.columnHeader4.Text = "QTY";
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 3;
            this.columnHeader5.Text = "Total";
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 1;
            this.columnHeader3.Text = "Price";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(209)))), ((int)(((byte)(248)))));
            this.panel4.Controls.Add(this.txt_total);
            this.panel4.Controls.Add(this.btn_printReciept);
            this.panel4.Controls.Add(this.txt_invoiceNum);
            this.panel4.Controls.Add(this.btn_cancel);
            this.panel4.Location = new System.Drawing.Point(443, 25);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(419, 512);
            this.panel4.TabIndex = 32;
            // 
            // txt_total
            // 
            this.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_total.Font = new System.Drawing.Font("Mobile Sans", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(19, 403);
            this.txt_total.Margin = new System.Windows.Forms.Padding(2);
            this.txt_total.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(384, 41);
            this.txt_total.TabIndex = 35;
            this.txt_total.Text = "  Total Amount";
            // 
            // btn_printReciept
            // 
            this.btn_printReciept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(137)))), ((int)(((byte)(170)))));
            this.btn_printReciept.FlatAppearance.BorderSize = 0;
            this.btn_printReciept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_printReciept.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_printReciept.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_printReciept.Location = new System.Drawing.Point(230, 460);
            this.btn_printReciept.Margin = new System.Windows.Forms.Padding(2);
            this.btn_printReciept.Name = "btn_printReciept";
            this.btn_printReciept.Size = new System.Drawing.Size(172, 41);
            this.btn_printReciept.TabIndex = 34;
            this.btn_printReciept.Text = "Print Receipt";
            this.btn_printReciept.UseVisualStyleBackColor = false;
            this.btn_printReciept.Click += new System.EventHandler(this.btn_printReciept_Click);
            // 
            // txt_invoiceNum
            // 
            this.txt_invoiceNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_invoiceNum.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_invoiceNum.Location = new System.Drawing.Point(19, 17);
            this.txt_invoiceNum.Margin = new System.Windows.Forms.Padding(2);
            this.txt_invoiceNum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_invoiceNum.Name = "txt_invoiceNum";
            this.txt_invoiceNum.ReadOnly = true;
            this.txt_invoiceNum.Size = new System.Drawing.Size(384, 25);
            this.txt_invoiceNum.TabIndex = 33;
            this.txt_invoiceNum.Text = " Invoice Number";
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(137)))), ((int)(((byte)(170)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_cancel.Location = new System.Drawing.Point(19, 460);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(172, 41);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_checkNum);
            this.panel3.Controls.Add(this.rb_manager);
            this.panel3.Controls.Add(this.rb_personal);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(34, 437);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 89);
            this.panel3.TabIndex = 31;
            // 
            // txt_checkNum
            // 
            this.txt_checkNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_checkNum.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_checkNum.Location = new System.Drawing.Point(15, 58);
            this.txt_checkNum.Margin = new System.Windows.Forms.Padding(2);
            this.txt_checkNum.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_checkNum.Name = "txt_checkNum";
            this.txt_checkNum.Size = new System.Drawing.Size(363, 25);
            this.txt_checkNum.TabIndex = 32;
            this.txt_checkNum.Text = " Check Number";
            // 
            // rb_manager
            // 
            this.rb_manager.AutoSize = true;
            this.rb_manager.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_manager.Location = new System.Drawing.Point(5, 31);
            this.rb_manager.Margin = new System.Windows.Forms.Padding(2);
            this.rb_manager.Name = "rb_manager";
            this.rb_manager.Size = new System.Drawing.Size(102, 24);
            this.rb_manager.TabIndex = 31;
            this.rb_manager.TabStop = true;
            this.rb_manager.Text = " Manager";
            this.rb_manager.UseVisualStyleBackColor = true;
            // 
            // rb_personal
            // 
            this.rb_personal.AutoSize = true;
            this.rb_personal.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_personal.Location = new System.Drawing.Point(5, 2);
            this.rb_personal.Margin = new System.Windows.Forms.Padding(2);
            this.rb_personal.Name = "rb_personal";
            this.rb_personal.Size = new System.Drawing.Size(100, 24);
            this.rb_personal.TabIndex = 30;
            this.rb_personal.TabStop = true;
            this.rb_personal.Text = " Personal";
            this.rb_personal.UseVisualStyleBackColor = true;
            // 
            // rb_check
            // 
            this.rb_check.AutoSize = true;
            this.rb_check.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_check.Location = new System.Drawing.Point(16, 409);
            this.rb_check.Margin = new System.Windows.Forms.Padding(2);
            this.rb_check.Name = "rb_check";
            this.rb_check.Size = new System.Drawing.Size(85, 24);
            this.rb_check.TabIndex = 29;
            this.rb_check.TabStop = true;
            this.rb_check.Text = " Check";
            this.rb_check.UseVisualStyleBackColor = true;
            this.rb_check.CheckedChanged += new System.EventHandler(this.rb_check_CheckedChanged);
            // 
            // rb_masterCard
            // 
            this.rb_masterCard.AutoSize = true;
            this.rb_masterCard.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_masterCard.Location = new System.Drawing.Point(16, 370);
            this.rb_masterCard.Margin = new System.Windows.Forms.Padding(2);
            this.rb_masterCard.Name = "rb_masterCard";
            this.rb_masterCard.Size = new System.Drawing.Size(129, 24);
            this.rb_masterCard.TabIndex = 28;
            this.rb_masterCard.TabStop = true;
            this.rb_masterCard.Text = " Master Card";
            this.rb_masterCard.UseVisualStyleBackColor = true;
            this.rb_masterCard.CheckedChanged += new System.EventHandler(this.rb_masterCard_CheckedChanged);
            // 
            // rb_amex
            // 
            this.rb_amex.AutoSize = true;
            this.rb_amex.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_amex.Location = new System.Drawing.Point(16, 334);
            this.rb_amex.Margin = new System.Windows.Forms.Padding(2);
            this.rb_amex.Name = "rb_amex";
            this.rb_amex.Size = new System.Drawing.Size(78, 24);
            this.rb_amex.TabIndex = 27;
            this.rb_amex.TabStop = true;
            this.rb_amex.Text = " Amex";
            this.rb_amex.UseVisualStyleBackColor = true;
            this.rb_amex.CheckedChanged += new System.EventHandler(this.rb_amex_CheckedChanged);
            // 
            // rb_visa
            // 
            this.rb_visa.AutoSize = true;
            this.rb_visa.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_visa.Location = new System.Drawing.Point(16, 296);
            this.rb_visa.Margin = new System.Windows.Forms.Padding(2);
            this.rb_visa.Name = "rb_visa";
            this.rb_visa.Size = new System.Drawing.Size(63, 24);
            this.rb_visa.TabIndex = 26;
            this.rb_visa.TabStop = true;
            this.rb_visa.Text = " Visa";
            this.rb_visa.UseVisualStyleBackColor = true;
            this.rb_visa.CheckedChanged += new System.EventHandler(this.rb_visa_CheckedChanged);
            // 
            // txt_changeAmount
            // 
            this.txt_changeAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_changeAmount.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_changeAmount.Location = new System.Drawing.Point(34, 215);
            this.txt_changeAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txt_changeAmount.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_changeAmount.Name = "txt_changeAmount";
            this.txt_changeAmount.ReadOnly = true;
            this.txt_changeAmount.Size = new System.Drawing.Size(374, 25);
            this.txt_changeAmount.TabIndex = 25;
            this.txt_changeAmount.Text = " Change Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = " Change";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(30, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 22);
            this.label8.TabIndex = 23;
            this.label8.Text = "Cash Tendered:";
            // 
            // rb_debitCard
            // 
            this.rb_debitCard.AutoSize = true;
            this.rb_debitCard.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_debitCard.Location = new System.Drawing.Point(16, 258);
            this.rb_debitCard.Margin = new System.Windows.Forms.Padding(2);
            this.rb_debitCard.Name = "rb_debitCard";
            this.rb_debitCard.Size = new System.Drawing.Size(126, 24);
            this.rb_debitCard.TabIndex = 10;
            this.rb_debitCard.TabStop = true;
            this.rb_debitCard.Text = " Debit  Card";
            this.rb_debitCard.UseVisualStyleBackColor = true;
            this.rb_debitCard.CheckedChanged += new System.EventHandler(this.rb_debitCard_CheckedChanged);
            // 
            // rb_cash
            // 
            this.rb_cash.AutoSize = true;
            this.rb_cash.Font = new System.Drawing.Font("Mobile Sans", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_cash.Location = new System.Drawing.Point(16, 50);
            this.rb_cash.Margin = new System.Windows.Forms.Padding(2);
            this.rb_cash.Name = "rb_cash";
            this.rb_cash.Size = new System.Drawing.Size(67, 24);
            this.rb_cash.TabIndex = 9;
            this.rb_cash.TabStop = true;
            this.rb_cash.Text = "Cash";
            this.rb_cash.UseVisualStyleBackColor = true;
            // 
            // txt_enterAmount
            // 
            this.txt_enterAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_enterAmount.Font = new System.Drawing.Font("Mobile Sans", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_enterAmount.Location = new System.Drawing.Point(34, 124);
            this.txt_enterAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txt_enterAmount.MinimumSize = new System.Drawing.Size(1, 1);
            this.txt_enterAmount.Name = "txt_enterAmount";
            this.txt_enterAmount.ShortcutsEnabled = false;
            this.txt_enterAmount.Size = new System.Drawing.Size(374, 25);
            this.txt_enterAmount.TabIndex = 4;
            this.txt_enterAmount.Text = " Enter Amount";
            this.txt_enterAmount.TextChanged += new System.EventHandler(this.txt_enterAmount_TextChanged);
            this.txt_enterAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_enterAmount_KeyPress);
            this.txt_enterAmount.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_enterAmount_KeyUp);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(137)))), ((int)(((byte)(170)))));
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Controls.Add(this.button3);
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(960, 164);
            this.panel9.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mobile Sans", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(610, 124);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Today is mm/dd/yyyy hh:mm:ss";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Mobile Sans", 12F, System.Drawing.FontStyle.Underline);
            this.label10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(202, 127);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 3;
            this.label10.Text = "USERNAME!";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Mobile Sans", 12F);
            this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(144, 127);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "HELLO,";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Mobile Sans", 28.2F);
            this.label13.ForeColor = System.Drawing.Color.Snow;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(143, 41);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(693, 40);
            this.label13.TabIndex = 1;
            this.label13.Text = "Cooperative Members Information System";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::coop_main.Properties.Resources.copp40;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(909, 11);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 0;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openregister2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(960, 720);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "openregister2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "openregister2";
            this.Load += new System.EventHandler(this.openregister2_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_checkNum;
        private System.Windows.Forms.RadioButton rb_manager;
        private System.Windows.Forms.RadioButton rb_personal;
        private System.Windows.Forms.RadioButton rb_check;
        private System.Windows.Forms.RadioButton rb_masterCard;
        private System.Windows.Forms.RadioButton rb_amex;
        private System.Windows.Forms.RadioButton rb_visa;
        private System.Windows.Forms.TextBox txt_changeAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rb_debitCard;
        private System.Windows.Forms.RadioButton rb_cash;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_enterAmount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_printReciept;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
        public System.Windows.Forms.TextBox txt_invoiceNum;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.ListView listViewPurchased;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Timer timer1;
    }
}