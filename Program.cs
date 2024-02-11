using Npgsql;

namespace adoNetTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUD crud = new CRUD();

            crud.Create("users");
            crud.InsertMany("users", "Nuriddin Asrorov", "accigen@gmail.com", "accigen", "+998907777777");
            crud.InsertMany("users", "Den Rov", "denrov@gmail.com", "denrov", "+998907777777");
            crud.GetAll("users");
            crud.GetById("users", 2);
            crud.Delete("users", "Den Rov");
            crud.NewDatabase("Test");
        }

    }
}
