namespace Junior_Developer
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DGV_invoice = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_changeAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_deleteAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.TB_search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_Patronymic = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_FirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_LastName = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSL_allSum = new System.Windows.Forms.ToolStripLabel();
            this.P_Loading = new System.Windows.Forms.Panel();
            this.L_LoadText = new System.Windows.Forms.Label();
            this.BT_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_invoice)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.P_Loading.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_invoice
            // 
            this.DGV_invoice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_invoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_invoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column3});
            this.DGV_invoice.Location = new System.Drawing.Point(12, 50);
            this.DGV_invoice.Name = "DGV_invoice";
            this.DGV_invoice.ReadOnly = true;
            this.DGV_invoice.RowHeadersVisible = false;
            this.DGV_invoice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_invoice.Size = new System.Drawing.Size(751, 396);
            this.DGV_invoice.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Дата";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Фамилия";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Имя";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Отчество";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Сумма счета, тыс";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_changeAccount,
            this.TSMI_deleteAccount});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 48);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // TSMI_changeAccount
            // 
            this.TSMI_changeAccount.Name = "TSMI_changeAccount";
            this.TSMI_changeAccount.Size = new System.Drawing.Size(155, 22);
            this.TSMI_changeAccount.Tag = "change";
            this.TSMI_changeAccount.Text = "Изменить счет";
            this.TSMI_changeAccount.Click += new System.EventHandler(this.AccountAction);
            // 
            // TSMI_deleteAccount
            // 
            this.TSMI_deleteAccount.Name = "TSMI_deleteAccount";
            this.TSMI_deleteAccount.Size = new System.Drawing.Size(155, 22);
            this.TSMI_deleteAccount.Tag = "delete";
            this.TSMI_deleteAccount.Text = "Удалить счет";
            this.TSMI_deleteAccount.Click += new System.EventHandler(this.AccountAction);
            // 
            // TB_search
            // 
            this.TB_search.Location = new System.Drawing.Point(469, 21);
            this.TB_search.Name = "TB_search";
            this.TB_search.Size = new System.Drawing.Size(75, 23);
            this.TB_search.TabIndex = 1;
            this.TB_search.Text = "Поиск";
            this.TB_search.UseVisualStyleBackColor = true;
            this.TB_search.Click += new System.EventHandler(this.TB_search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Отчество:";
            // 
            // TB_Patronymic
            // 
            this.TB_Patronymic.Location = new System.Drawing.Point(302, 24);
            this.TB_Patronymic.Name = "TB_Patronymic";
            this.TB_Patronymic.Size = new System.Drawing.Size(139, 20);
            this.TB_Patronymic.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Имя:";
            // 
            // TB_FirstName
            // 
            this.TB_FirstName.Location = new System.Drawing.Point(157, 24);
            this.TB_FirstName.Name = "TB_FirstName";
            this.TB_FirstName.Size = new System.Drawing.Size(139, 20);
            this.TB_FirstName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Фамилия:";
            // 
            // TB_LastName
            // 
            this.TB_LastName.Location = new System.Drawing.Point(12, 24);
            this.TB_LastName.Name = "TB_LastName";
            this.TB_LastName.Size = new System.Drawing.Size(139, 20);
            this.TB_LastName.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSL_allSum});
            this.toolStrip1.Location = new System.Drawing.Point(0, 449);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(775, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSL_allSum
            // 
            this.TSL_allSum.Name = "TSL_allSum";
            this.TSL_allSum.Size = new System.Drawing.Size(86, 22);
            this.TSL_allSum.Text = "toolStripLabel1";
            // 
            // P_Loading
            // 
            this.P_Loading.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.P_Loading.Controls.Add(this.L_LoadText);
            this.P_Loading.Location = new System.Drawing.Point(229, 179);
            this.P_Loading.Name = "P_Loading";
            this.P_Loading.Size = new System.Drawing.Size(278, 117);
            this.P_Loading.TabIndex = 13;
            // 
            // L_LoadText
            // 
            this.L_LoadText.AutoSize = true;
            this.L_LoadText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_LoadText.Location = new System.Drawing.Point(41, 48);
            this.L_LoadText.Name = "L_LoadText";
            this.L_LoadText.Size = new System.Drawing.Size(197, 20);
            this.L_LoadText.TabIndex = 0;
            this.L_LoadText.Text = "Идет загрузка данных";
            // 
            // BT_add
            // 
            this.BT_add.Location = new System.Drawing.Point(657, 21);
            this.BT_add.Name = "BT_add";
            this.BT_add.Size = new System.Drawing.Size(106, 23);
            this.BT_add.TabIndex = 14;
            this.BT_add.Tag = "add";
            this.BT_add.Text = "Добавить запись";
            this.BT_add.UseVisualStyleBackColor = true;
            this.BT_add.Click += new System.EventHandler(this.BT_add_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(775, 474);
            this.Controls.Add(this.BT_add);
            this.Controls.Add(this.P_Loading);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_Patronymic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_FirstName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_LastName);
            this.Controls.Add(this.TB_search);
            this.Controls.Add(this.DGV_invoice);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_invoice)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.P_Loading.ResumeLayout(false);
            this.P_Loading.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_invoice;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMI_changeAccount;
        private System.Windows.Forms.ToolStripMenuItem TSMI_deleteAccount;
        private System.Windows.Forms.Button TB_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_Patronymic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_FirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_LastName;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel TSL_allSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Panel P_Loading;
        private System.Windows.Forms.Label L_LoadText;
        private System.Windows.Forms.Button BT_add;
    }
}

