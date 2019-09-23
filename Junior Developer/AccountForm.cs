using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Junior_Developer
{
    public partial class AccountForm : Form
    {
        private int _id;
        private Functions.Action _action;

        public AccountForm(Functions.Action action = Functions.Action.add, int id = -1, DataGridViewRow user_info = null)
        {
            InitializeComponent();

            Calendar.Hide();
            if(id != -1)
            {
                _id = id;
                _action = action;

                TB_Date.Text = user_info.Cells[0].Value.ToString();
                TB_LastName.Text = user_info.Cells[1].Value.ToString();
                TB_FirstName.Text = user_info.Cells[2].Value.ToString();
                TB_Patronymic.Text = user_info.Cells[3].Value.ToString();
                TB_Sum.Text = user_info.Cells[4].Value.ToString();
            }

            if(action == Functions.Action.change)
                BT1.Text = "Изменить";
            else
                BT1.Text = "Удалить";
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            Calendar.Show();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            Calendar.Hide();
        }

        private void AccountForm_Click(object sender, EventArgs e)
        {
            Calendar.Hide();
        }

        private void BT1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TB_LastName.Text) || string.IsNullOrEmpty(TB_FirstName.Text) ||
                string.IsNullOrEmpty(TB_Patronymic.Text) || string.IsNullOrEmpty(TB_Date.Text) ||
                string.IsNullOrEmpty(TB_Sum.Text) || !Regex.IsMatch(TB_Sum.Text, @"^[0-9]*[.,]?[0-9]+$", RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Не все поля заполнены либо заполнены некорректно", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (_action)
            {
                case Functions.Action.add:
                    if ((bool)Functions.AccountAction(_action, TB_Date.Text, TB_LastName.Text, TB_FirstName.Text, TB_Patronymic.Text, Convert.ToDouble(TB_Sum.Text)))
                        MessageBox.Show("Информация успешно добавлена", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Ошибка при добавлении информации", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case Functions.Action.change:
                    if ((bool)Functions.AccountAction(_action, TB_Date.Text, TB_LastName.Text, TB_FirstName.Text, TB_Patronymic.Text, Convert.ToDouble(TB_Sum.Text), _id))
                        MessageBox.Show("Информация успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Ошибка при изменении информации", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case Functions.Action.delete:
                    if((bool)Functions.AccountAction(_action, id: _id))
                        MessageBox.Show("Информация успешно удалена", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Ошибка при удалении информации", "Удаление записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }            
        }

        private void TB_Date_Click(object sender, EventArgs e)
        {
            Calendar.Show();
        }

        private void Calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            TB_Date.Text = Calendar.SelectionStart.ToString("yyyy-MM-dd");
            Calendar.Hide();
        }

        private void TB_Sum_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
