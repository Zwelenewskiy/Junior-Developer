using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Junior_Developer
{
    public class Functions
    {        
        private static readonly string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Invoice;Integrated Security=True";
                
        /// <summary>
        /// Обрабатывает действие пользователя
        /// </summary>
        /// <param name="act">Тип действия пользователя</param>
        /// <param name="date">Дата создания счета</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="firstName">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="sum">Сумма счета</param>
        /// <param name="id">ID записи в БД</param>
        /// <returns></returns>
        public static object AccountAction(AccountActionParams parameters)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection
                };                

                switch (parameters.action)
                {
                    case Structs.UserAction.add:
                        Database.AddRecord(new ChangeRecordParams()
                        {
                            date = parameters.date,
                            last_name = parameters.last_name,
                            first_name = parameters.first_name,
                            patronymic = parameters.patronymic,
                            sum = parameters.sum,
                            id = parameters.id
                        });

                        return true;

                    case Structs.UserAction.change:
                        Database.ChangeRecord(new ChangeRecordParams()
                        {
                            date = parameters.date,
                            last_name = parameters.last_name,
                            first_name = parameters.first_name,
                            patronymic = parameters.patronymic,
                            sum = parameters.sum,
                            id = parameters.id
                        });

                        return true;

                    case Structs.UserAction.delete:
                        Database.DeleteRecord(new ChangeRecordParams() {
                            id = parameters.id
                        });

                        return true;

                    case Structs.UserAction.show:

                        return Database.GetRecords();
                }

                connection.Close();
            }

            return true;
        }

        /// <summary>
        /// Проверяет строку на соответствие шаблону
        /// </summary>
        /// <param name="expression">Проверяемая строка</param>
        /// <param name="pattern">Шаблон</param>
        /// <returns></returns>
        public static bool ExpressionMatches(string expression, string pattern)
        {
            return Regex.IsMatch(expression, pattern, RegexOptions.IgnoreCase);
        }
    }
}
