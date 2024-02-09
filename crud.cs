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
        private readonly string CONNECTIONSTRING = "Server=localhost;Port=5432;Database=Demo;User Id=postgres;Password=135;";
        string? query;

        public string Create(string tableName, params[] values)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);

            connection.Open();
            //logic
            query = "Create table if not exists demo_table(id serial, theme varchar(40), start_date date, students_count int);";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();

            return $"{tableName} was created successfully!";
        }

        public void Select(string tableName)
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
            }
            connection.Close();
        }

        public 
    }
}
