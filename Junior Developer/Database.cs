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

        private static int ChangeRecord(string date, string lastName, string firstName, string patronymic, double sum, int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                return new SqlCommand($"UPDATE Invoice.dbo.Main_table SET Date = '{date}', LastName = '{lastName}', FirstName = '{firstName}'," +
                    $"Patronymic = '{patronymic}', Sum = {sum.ToString().Replace(',', '.')} WHERE ID = {id}").ExecuteNonQuery();
            }
        }
    }
}
