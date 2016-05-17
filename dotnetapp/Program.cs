using System;
using Npgsql;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var conn = new NpgsqlConnection("Host=db;Username=postgres;Database=postgres"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;

                    // init db
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS greetings (text VARCHAR(255))";
                    cmd.ExecuteNonQuery();
                    
                    // insert first greeting
                    cmd.CommandText = "INSERT INTO greetings (text) VALUES ('Hello Docker')";
                    cmd.ExecuteNonQuery();

                    // try to retrieve data
                    cmd.CommandText = "SELECT text FROM greetings";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0));
                        }
                    }
                    
                }     
            }
        }
        
    }
}
