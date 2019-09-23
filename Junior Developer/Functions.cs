using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;

namespace Junior_Developer
{
    public class Functions
    {
        /// <summary>
        /// Тип действия пользователя
        /// </summary>
        public enum Action
        {
            add,
            change,
            delete,
            show
        }

        private static readonly string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Invoice;Integrated Security=True";

        /// <summary>
        /// Заполняет базу данных тестовыми данными
        /// </summary>
        public static void SetUsers()
        {
            for (int i = 0; i < 20001; i++)
            {
                AccountAction(Action.add, "2018-05-28", "Фамилия " + i, "Имя " + i, "Отчество " + i, new Random().Next(0, 99999));
            }
        }
        
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
        public static object AccountAction(Action act, string date = "", string lastName = "", string firstName = "", string patronymic = "", double sum = -1, int id = -1)
        {
            string connection_string = CONNECTION_STRING;
            if(connection_string == null)
            {
                return null;
            }

            using (var connection = new SqlConnection(connection_string))
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection
                };                

                switch (act)
                {
                    case Action.add:
                        command.CommandText = $"SELECT MAX(ID) FROM Main_table";
                        var new_id = command.ExecuteScalar();

                        new_id = Convert.DBNull == new_id ? 0 : Convert.ToInt32(new_id) + 1;//новый ID должен быть на единицу больше текущего в БД

                        command.CommandText = $"INSERT INTO Main_table VALUES({new_id}, '{date}', '{lastName}', '{firstName}', '{patronymic}', {sum.ToString().Replace(',', '.')})";
                        command.ExecuteNonQuery();

                        return true;

                    case Action.change:
                        command.CommandText = $"UPDATE Invoice.dbo.Main_table SET Date = '{date}', LastName = '{lastName}', FirstName = '{firstName}'," +
                            $"Patronymic = '{patronymic}', Sum = {sum.ToString().Replace(',', '.')} WHERE ID = {id}";

                        command.ExecuteNonQuery();
                        return true;

                    case Action.delete:
                        command.CommandText = $"DELETE FROM Invoice.dbo.Main_table WHERE ID = {id}";

                        command.ExecuteNonQuery();
                        return true;

                    case Action.show:

                        var query_res = new List<object[]>();

                        command.CommandText = "SELECT * FROM Main_table";       
                        using (var res = command.ExecuteReader())
                        {
                            if (res.HasRows)
                            {
                                while (res.Read())
                                {
                                    object[] tmp = new object[6];

                                    tmp[0] = res.GetValue(0);
                                    tmp[1] = res.GetValue(1);
                                    tmp[2] = res.GetValue(2);
                                    tmp[3] = res.GetValue(3);
                                    tmp[4] = res.GetValue(4);
                                    tmp[5] = res.GetValue(5);

                                    query_res.Add(tmp);
                                    tmp = new object[6];
                                }
                            }
                        }

                        return query_res;
                }

                connection.Close();
            }

            return true;
        }
    }
}
