using Npgsql;

namespace adoNetTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            \
            //Select
            //string query = "select * from demo_table";

            //NpgsqlCommand command = new NpgsqlCommand(query, connection);

            //NpgsqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}, {reader[3]}");
            //}

            connection.Close();
        }

    }
}
