using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Junior_Developer
{
    public partial class AccountForm : Form
    {
        private int id;
        private Structs.UserAction action;

        public AccountForm(AccountFormParams parameters)
        {
            InitializeComponent();

            Calendar.Hide();
            if(parameters.id != -1)
            {
                id = parameters.id; 
                action = parameters.action;

                TB_Date.Text = parameters.user_info.Cells[0].Value.ToString();
                TB_LastName.Text = parameters.user_info.Cells[1].Value.ToString();
                TB_FirstName.Text = parameters.user_info.Cells[2].Value.ToString();
                TB_Patronymic.Text = parameters.user_info.Cells[3].Value.ToString();
                TB_Sum.Text = parameters.user_info.Cells[4].Value.ToString();
            }

            if(action == Structs.UserAction.change)
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

            switch (action)
            {
                case Structs.UserAction.add:
                    if ((bool)Functions.AccountAction(action, TB_Date.Text, TB_LastName.Text, TB_FirstName.Text, TB_Patronymic.Text, Convert.ToDouble(TB_Sum.Text)))
                        MessageBox.Show("Информация успешно добавлена", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Ошибка при добавлении информации", "Добавление записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case Structs.UserAction.change:
                    if ((bool)Functions.AccountAction(action, TB_Date.Text, TB_LastName.Text, TB_FirstName.Text, TB_Patronymic.Text, Convert.ToDouble(TB_Sum.Text), id))
                        MessageBox.Show("Информация успешно изменена", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Ошибка при изменении информации", "Изменение записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

                case Structs.UserAction.delete:
                    if((bool)Functions.AccountAction(action, id: id))
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
    }
}
