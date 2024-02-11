using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adoNetTest
{
    public class CRUD
    {
        private readonly string CONNECTIONSTRING = "Server=localhost;Port=5432;Database=Assignment;User Id=postgres;Password=135;";
        string? query;
        string? tableName;

        public string Create(string table, string fullname, string email, string password, string phoneNumber)
        {
            tableName = table;

            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();
            
            query = $"Create table if not exists {tableName}(id serial, fullname varchar(50), email varchar(100), password varchar(100), phoneNumber varchar(50));";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            
            command.ExecuteNonQuery();

            connection.Close();
            return $"{tableName} was created successfully!";
        }

        public void GetAll()
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"select * from {tableName};";

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

        public void GetById(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"select * from {tableName} where Id = {id};";

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

        public string InsertOne(string columnName, string data)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Insert into {tableName}({columnName}) values ('{data}');";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Inserted successfully!";
        }

        public string InsertMany(string fullname, string email, string password, string phoneNumber)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Insert into {tableName}(fullname, email, password, phoneNumber) values ('{fullname}', '{email}', '{password}', '{phoneNumber}');";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Inserted successfully!";
        }

        public string Delete(string fullname)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Delete from {tableName} where fullname = '{fullname}';";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Deleted successfully!";
        }

        public string UpdateOne(string columnName, string oldOne, string newOne)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Update {tableName} set {columnName} = '{newOne}' where {columnName} = '{oldOne}';";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Updated successfully!";
        }

        public string UpdateMany(string oldname, string fullname, string email, string password, string phoneNumber)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Update {tableName} set fullname = '{fullname}', email = '{email}', password = '{password}', phoneNumber = '{phoneNumber}' where fullname = '{oldname}';";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Updated successfully!";
        }

        public void GetLike(string columnName, string text)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"select * from {tableName} where {columnName} like '%{text}%';";

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

        public string AddColumn(string columnName, string type)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"alter table {tableName} add column {columnName} {type};";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Updated successfully!";
        }
    }
}
