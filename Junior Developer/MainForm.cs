using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Junior_Developer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DGV_invoice.ContextMenuStrip = contextMenuStrip1;
            TSL_allSum.Text = "Сумма всех счетов: ";
        }

        /// <summary>
        /// Копирует данные в DGV_invoice 
        /// </summary>
        /// <param name="sourceGrid">Таблица-источник</param>
        private void Copy(DataGridView sourceGrid)
        {
            var targetRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow sourceRow in sourceGrid.Rows)
                if (!sourceRow.IsNewRow)
                {
                    var targetRow = (DataGridViewRow)sourceRow.Clone();
                    foreach (DataGridViewCell cell in sourceRow.Cells)
                        targetRow.Cells[cell.ColumnIndex].Value = cell.Value;
                    targetRows.Add(targetRow);
                }

            DGV_invoice.Columns.Clear();
            foreach (DataGridViewColumn column in sourceGrid.Columns)
                DGV_invoice.Columns.Add((DataGridViewColumn)column.Clone());

            DGV_invoice.Rows.AddRange(targetRows.ToArray());
        }

        /// <summary>
        /// Загружает данные из БД в таблицу
        /// </summary>
        private void LoadGrid()
        {
            var tmp = Functions.AccountAction(Structs.Action.show);//проверили подключение к БД
            if (tmp == null)
            {
                MessageBox.Show("Ошибка при подключении к базе данных", "Загрузка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                P_Loading.Hide();
                return;
            }

            Task.Factory.StartNew(() =>
            {
                P_Loading.Show();
                TB_search.Enabled = false;
                BT_add.Enabled = false;
                TSL_allSum.Text = "Сумма всех счетов: ";
                DataGridView new_dgv = new DataGridView();

                foreach (DataGridViewColumn column in DGV_invoice.Columns)
                    new_dgv.Columns.Add((DataGridViewColumn)column.Clone());
                
                tmp = (List<object[]>)tmp;

                double sum = 0;
                DGV_invoice.Rows.Clear();
                foreach (var t in (List<object[]>)tmp)
                {
                    new_dgv.Rows.Add(t[1], t[2], t[3], t[4], t[5]);
                    new_dgv.Rows[new_dgv.Rows.Count - 2].Tag = t[0];//для каждой строки сохраняем соответствующий ей id из БД

                    sum += Convert.ToDouble(t[5]);
                }

                Copy(new_dgv);                

                TSL_allSum.Text = "Сумма всех счетов: " + sum.ToString() + " тыс.";
                P_Loading.Hide();
                TB_search.Enabled = true;
                BT_add.Enabled = true;
            }, TaskCreationOptions.LongRunning);             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Functions.SetUsers();
            LoadGrid();
        }

        private void BT_add_Click(object sender, EventArgs e)
        {
            using (var accForm = new AccountForm(Structs.Action.change))
            {
                accForm.ShowDialog();
            }

            LoadGrid();
        }

        private void AccountAction(object sender, EventArgs e)
        {   
            if (DGV_invoice.Rows[DGV_invoice.CurrentRow.Index].Cells[0].Value != null)
            {
                string tag = ((ToolStripMenuItem)sender).Tag.ToString();//получили тип действия пользователя
                var act = tag ==  "change" ? Structs.Action.change : Structs.Action.delete;

                switch (act)
                {
                    case Structs.Action.change:
                        using (var accForm = new AccountForm(act, Convert.ToInt32(DGV_invoice.Rows[DGV_invoice.CurrentRow.Index].Tag),
                        DGV_invoice.Rows[DGV_invoice.CurrentRow.Index]))
                        {
                            accForm.ShowDialog();
                        }

                        LoadGrid();
                        break;

                    case Structs.Action.delete:
                        if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if ((bool)Functions.AccountAction(act, id: Convert.ToInt32(DGV_invoice.Rows[DGV_invoice.CurrentRow.Index].Tag)))
                            {
                                MessageBox.Show("Информация успешно удалена", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadGrid();
                            }                                
                            else
                                MessageBox.Show("Ошибка при удалении информации", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                        
                        break;

                    default:
                        using (var accForm = new AccountForm(Structs.Action.change))
                        {
                            accForm.ShowDialog();
                        }

                        LoadGrid();

                        break;
                }
            }
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (DGV_invoice.Rows[DGV_invoice.CurrentRow.Index].Cells[0].Value == null)//если строка таблицы пуста, то можно только добавить новую запись
            {
                TSMI_changeAccount.Enabled = false;
                TSMI_deleteAccount.Enabled = false;
            }
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            TSMI_changeAccount.Enabled = true;
            TSMI_deleteAccount.Enabled = true;
        }

        private void TB_search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_LastName.Text) && string.IsNullOrWhiteSpace(TB_FirstName.Text) && string.IsNullOrWhiteSpace(TB_Patronymic.Text))
            {
                LoadGrid();
                return;
            }

            Task.Factory.StartNew(() =>
            {
                P_Loading.Show();
                L_LoadText.Text = "Идет поиск данных";
                TB_search.Enabled = false;

                DataGridView new_dgv = new DataGridView();//буфер для загрузки данных
                foreach (DataGridViewColumn column in DGV_invoice.Columns)//скопировали структуру таблицы во временную таблицу
                    new_dgv.Columns.Add((DataGridViewColumn)column.Clone());

                foreach (DataGridViewRow row in DGV_invoice.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((row.Cells[1].Value.ToString().ToLower() == TB_LastName.Text.Trim().ToLower()) || 
                             (row.Cells[2].Value.ToString().ToLower() == TB_FirstName.Text.Trim().ToLower()) ||
                             (row.Cells[3].Value.ToString().ToLower() == TB_Patronymic.Text.Trim().ToLower()))
                        {
                            new_dgv.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value);
                        }
                    }
                }

                DGV_invoice.Rows.Clear();
                Thread.Sleep(300);//тестовым путем выяснилось, что необходимо притормозить поток, иначе в RunTime ошибка отрисовки таблицы 

                Copy(new_dgv);

                P_Loading.Hide();
                TB_search.Enabled = true;
            }, TaskCreationOptions.LongRunning);            
        }
    }
}
