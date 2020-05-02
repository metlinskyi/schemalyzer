using System;
using MySql.Data.MySqlClient;

namespace MySql
{
    public class MsSqlClient
    {
        public void A()
        {
            using (var connection = new MySqlConnection
                {
                    ConnectionString = "server=localhost;user id=root;password=******;persistsecurityinfo=True;port=3305;database=music"
                }) {
                connection.Open();
                var command = new MySqlCommand("SELECT * FROM music.category;", connection);

                using (MySqlDataReader reader =  command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["category_id"]}: {reader["name"]} {reader["last_update"]}");
                    }
                }
            }
        }
    }
}
