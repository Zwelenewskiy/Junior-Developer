using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior_Developer
{
    public static class Database
    {
        private static readonly string CONNECTION_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=Invoice;Integrated Security=True";

        /// <summary>
        /// Изменяет данные указанной записи
        /// </summary>
        public static int ChangeRecord(ChangeRecordParams parameters)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                return new SqlCommand($"UPDATE Invoice.dbo.Main_table SET Date = '{parameters.date}', LastName = '{parameters.last_name}', FirstName = '{parameters.first_name}'," +
                    $"Patronymic = '{parameters.patronymic}', Sum = {parameters.sum.ToString().Replace(',', '.')} WHERE ID = {parameters.id}", connection).ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Добаваляет в БД данные указанной записи
        /// </summary>
        public static int AddRecord(ChangeRecordParams parameters)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                object current_id = new SqlCommand("SELECT MAX(ID) FROM Main_table", connection).ExecuteScalar();
                current_id = Convert.DBNull == current_id ? 0 : Convert.ToInt32(current_id) + 1;//новый ID должен быть на единицу больше текущего в БД

                return new SqlCommand($"INSERT INTO Main_table VALUES({current_id}, '{parameters.date}', '{parameters.last_name}', '{parameters.first_name}'," +
                    $" '{parameters.patronymic}', {parameters.sum.ToString().Replace(',', '.')})", connection).ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Удаляет из БД указанную записи
        /// </summary>
        public static int DeleteRecord(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return new SqlCommand($"DELETE FROM Invoice.dbo.Main_table WHERE ID = {id}", connection).ExecuteNonQuery();
            }
        }

        // <summary>
        /// Удаляет из БД указанную записи
        /// </summary>
        public static List<object[]> GetRecords()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                var query_res = new List<object[]>();

                using (var res = new SqlCommand("SELECT * FROM Main_table", connection).ExecuteReader())
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
        }
    }
}
