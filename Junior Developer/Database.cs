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

                return new SqlCommand($"UPDATE Invoice.dbo.Main_table SET Date = '{parameters.date}', LastName = '{parameters.last_mame}', FirstName = '{parameters.first_name}'," +
                    $"Patronymic = '{parameters.patronymic}', Sum = {parameters.sum.ToString().Replace(',', '.')} WHERE ID = {parameters.id}", connection).ExecuteNonQuery();
            }
        }
    }
}
