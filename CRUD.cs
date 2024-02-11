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

        public string Create(string tableName)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();
            
            query = $"Create table if not exists {tableName}(id serial, fullname varchar(50), email varchar(100), password varchar(100), phoneNumber varchar(50));";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            
            command.ExecuteNonQuery();

            connection.Close();
            return $"{tableName} was created successfully!";
        }

        public void GetAll(string tableName)
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

        public void GetById(string tableName, int id)
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

        public string InsertOne(string tableName, string columnName, string data)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Insert into {tableName}({columnName}) values ('{data}');";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Inserted successfully!";
        }

        public string InsertMany(string tableName, string fullname, string email, string password, string phoneNumber)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Insert into {tableName}(fullname, email, password, phoneNumber) values ('{fullname}', '{email}', '{password}', '{phoneNumber}');";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Inserted successfully!";
        }

        public string Delete(string tableName, string fullname)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Delete from {tableName} where fullname = '{fullname}';";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Deleted successfully!";
        }

        public string UpdateOne(string tableName, string columnName, string oldOne, string newOne)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Update {tableName} set {columnName} = '{newOne}' where {columnName} = '{oldOne}';";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Updated successfully!";
        }

        public string UpdateMany(string tableName, string oldname, string fullname, string email, string password, string phoneNumber)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Update {tableName} set fullname = '{fullname}', email = '{email}', password = '{password}', phoneNumber = '{phoneNumber}' where fullname = '{oldname}';";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Updated successfully!";
        }

        public void GetLike(string tableName, string columnName, string text)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Select * from {tableName} where {columnName} like '%{text}%';";

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

        public string AddColumn(string tableName, string columnName, string type)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Alter table {tableName} add column {columnName} {type};";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Column was added successfully!";
        }

        public string AddColumnWithDefaultValue(string tableName, string columnName, string type, string defaultValue)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Alter table {tableName} add column {columnName} {type} default {defaultValue};";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Column was added successfully!";
        }

        public string AlterColumnName(string tableName, string oldColumnName, string newColumnName)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Alter table {tableName} rename column {oldColumnName} to {newColumnName};";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Column was altered successfully!";
        }

        public string AlterTableName(string tableName, string newTableName)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Alter table {tableName} rename to {newTableName};";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();
            tableName = newTableName;

            connection.Close();
            return "Table was altered successfully!";
        }

        public string NewDatabase(string databaseName)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Create database {databaseName};\r\n\\c {databaseName};\r\nCreate table names(id serial, fullname varchar(50));\r\nCreate table emails(id serial, email varchar(100));\r\nCreate table phoneNumbers(id serial, phoneNumber varchar(100));";
            
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            
            command.ExecuteNonQuery();

            connection.Close();
            return $"New database was created successfully!";
        }

        public string Truncate(string tableName)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Truncate table {tableName};";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            command.ExecuteNonQuery();

            connection.Close();
            return "Truncated successfully!";
        }

        public void Join(string table1, string table2)
        {
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();

            query = $"Select * from {table1} as t1 join {table2} as t2 on t1.id = t2.id;";

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


    }
}
