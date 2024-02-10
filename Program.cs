using Npgsql;

namespace adoNetTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tableName, fullName, email, password, phoneNumber;
            CRUD crud = new CRUD();

            Console.Write("Table name >> ");
            tableName = Console.ReadLine()!;
            Console.Write("Fullname >> ");
            fullName = Console.ReadLine()!;
            Console.Write("Email >> ");
            email = Console.ReadLine()!;
            Console.Write("Password >> ");
            password = Console.ReadLine()!;
            Console.Write("Phone number >> ");
            phoneNumber = Console.ReadLine()!;

            Console.WriteLine(crud.Create(tableName, fullName, email, password, phoneNumber));

        }

    }
}
