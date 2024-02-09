using Npgsql;

namespace adoNetTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CONNECTIONSTRING = "Server=localhost;Port=5432;Database=Demo;User Id=postgres;Password=135;";
            
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);

            connection.Open();

            //string query = "Create table if not exists demo_table(id serial, theme varchar(40), start_date date, students_count int);";
            //string insertQuery = "insert into demo_table(theme, start_date";

            //NpgsqlCommand command = new NpgsqlCommand(query, connection);
            //command.ExecuteNonQuery();

            //DemoDB table = new DemoDB();
            //table .mav

            string query = "select * from demo_table";

            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", reader.GetInt32(0),
                    reader.GetString(1), reader.GetDateTime(2), reader.GetInt32(3));
            }
            
            // logic
            //Console.WriteLine("Created table!");

            connection.Close();
        }
    }
}
