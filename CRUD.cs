using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoNetTest
{
    public class CRUD
    {
        private readonly string CONNECTIONSTRING = "Server=localhost;Port=5432;Database=Assignment;User Id=postgres;Password=135;";
        string? query;

        public string Create(string tableName, string fullName, string email, string password, string phoneNumber)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();
            
            query = $"Create table if not exists {tableName}(id serial, fullName varchar(50), email varchar(100), password varchar(100), phoneNumber varchar(50));";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            
            command.ExecuteNonQuery();

            connection.Close();
            return $"{tableName} was created successfully!";
        }

        public void GetAll(string tableName)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"select * from {tableName}";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i]} ");
                }
                Console.WriteLine();
            }

            connection.Close();
        }

        public  
    }
}
