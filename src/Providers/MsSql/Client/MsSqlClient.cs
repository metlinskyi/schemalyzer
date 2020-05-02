using System;
using System.Data.SqlClient;

namespace MsSql
{
    public class MsSqlClient
    {
        public void A()
        {
            using (var connection = new SqlConnection("Server=tcp:localhost,1433;User Id=sa;Password=Passw0rd!"))
            {
                var command = new SqlCommand("SELECT * FROM [A].[Entity].[Customers]", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]}:{reader[1]} ${reader[2]}");
                    }
                }
            }
        }
    }
}
