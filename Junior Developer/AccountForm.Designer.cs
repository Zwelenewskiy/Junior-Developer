namespace Junior_Developer
{
    partial class AccountForm
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
            this.TB_LastName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_Date = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TB_Sum = new System.Windows.Forms.TextBox();
            this.BT1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_FirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Patronymic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TB_LastName
            // 
            this.TB_LastName.Location = new System.Drawing.Point(25, 36);
            this.TB_LastName.Name = "TB_LastName";
            this.TB_LastName.Size = new System.Drawing.Size(139, 20);
            this.TB_LastName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фамилия:";
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(200, 65);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 6;
            this.Calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateSelected);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Дата:";
            // 
            // TB_Date
            // 
            this.TB_Date.Location = new System.Drawing.Point(202, 36);
            this.TB_Date.Name = "TB_Date";
            this.TB_Date.ReadOnly = true;
            this.TB_Date.Size = new System.Drawing.Size(87, 20);
            this.TB_Date.TabIndex = 7;
            this.TB_Date.Click += new System.EventHandler(this.TB_Date_Click);
            this.TB_Date.Enter += new System.EventHandler(this.textBox4_Enter);
            this.TB_Date.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Сумма счета:";
            // 
            // TB_Sum
            // 
            this.TB_Sum.Location = new System.Drawing.Point(202, 94);
            this.TB_Sum.Name = "TB_Sum";
            this.TB_Sum.Size = new System.Drawing.Size(87, 20);
            this.TB_Sum.TabIndex = 9;
            this.TB_Sum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_Sum_KeyPress);
            // 
            // BT1
            // 
            this.BT1.Location = new System.Drawing.Point(157, 239);
            this.BT1.Name = "BT1";
            this.BT1.Size = new System.Drawing.Size(75, 23);
            this.BT1.TabIndex = 11;
            this.BT1.Text = "Добавить";
            this.BT1.UseVisualStyleBackColor = true;
            this.BT1.Click += new System.EventHandler(this.BT1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(295, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "тыс.";
            // 
            // TB_FirstName
            // 
            this.TB_FirstName.Location = new System.Drawing.Point(25, 94);
            this.TB_FirstName.Name = "TB_FirstName";
            this.TB_FirstName.Size = new System.Drawing.Size(139, 20);
            this.TB_FirstName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя:";
            // 
            // TB_Patronymic
            // 
            this.TB_Patronymic.Location = new System.Drawing.Point(25, 155);
            this.TB_Patronymic.Name = "TB_Patronymic";
            this.TB_Patronymic.Size = new System.Drawing.Size(139, 20);
            this.TB_Patronymic.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Отчество:";
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(382, 274);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.BT1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TB_Sum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Patronymic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_FirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_LastName);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аккаунт";
            this.Click += new System.EventHandler(this.AccountForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_LastName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TB_Date;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TB_Sum;
        private System.Windows.Forms.Button BT1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_FirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Patronymic;
        private System.Windows.Forms.Label label3;
    }
}