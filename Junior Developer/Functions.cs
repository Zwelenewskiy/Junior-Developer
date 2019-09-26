﻿using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;

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
                        command.CommandText = $"SELECT MAX(ID) FROM Main_table";
                        var new_id = command.ExecuteScalar();

                        new_id = Convert.DBNull == new_id ? 0 : Convert.ToInt32(new_id) + 1;//новый ID должен быть на единицу больше текущего в БД

                        command.CommandText = $"INSERT INTO Main_table VALUES({new_id}, '{parameters.date}', '{parameters.last_name}', '{parameters.first_name}', '{parameters.patronymic}', {parameters.sum.ToString().Replace(',', '.')})";
                        command.ExecuteNonQuery();

                        return true;

                    case Structs.UserAction.change:
                        command.CommandText = $"UPDATE Invoice.dbo.Main_table SET Date = '{parameters.date}', LastName = '{parameters.last_name}', FirstName = '{parameters.first_name}'," +
                            $"Patronymic = '{parameters.patronymic}', Sum = {parameters.sum.ToString().Replace(',', '.')} WHERE ID = {parameters.id}";

                        command.ExecuteNonQuery();
                        return true;

                    case Structs.UserAction.delete:
                        command.CommandText = $"DELETE FROM Invoice.dbo.Main_table WHERE ID = {parameters.id}";

                        command.ExecuteNonQuery();
                        return true;

                    case Structs.UserAction.show:

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
