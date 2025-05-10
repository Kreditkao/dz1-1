using System;
using ConsoleApp2;

class Program
{
    static void Main()
    {
        var dbService = new DatabaseService();

        // Add an administrator to the database
        dbService.AddAdmin();
        Console.WriteLine(" Administrator added to ShopDB");

        Console.WriteLine("\nDapper + SQL Server Example");

        try
        {
            Console.Write("Enter username (e.g., Admin): ");
            string? username = Console.ReadLine();

            Console.Write("Enter password (e.g., 1234): ");
            string? password = Console.ReadLine();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine(" Error: Username and password cannot be empty.");
            }
            else
            {
                if (dbService.Authenticate(username, password))
                    Console.WriteLine(" Successful login!");
                else
                    Console.WriteLine(" Error: Incorrect username or password.");
            }

            dbService.AddStudent("John Doe", 20, "john@example.com");
            dbService.AddStudent("Jane Smith", 22, "jane@example.com");

            Console.WriteLine("\nAll students:");
            foreach (var student in dbService.GetStudents())
            {
                Console.WriteLine($"{student.Id}: {student.Name}, {student.Age}, {student.Email}");
            }

            Console.WriteLine("\nUpdating student with Id = 1...");
            dbService.UpdateStudent(1, "Johnathan Doe", 21, "johnathan@example.com");

            Console.WriteLine("\nDeleting student with Id = 2...");
            dbService.DeleteStudent(2);

            Console.WriteLine("\nRemaining students:");
            foreach (var student in dbService.GetStudents())
            {
                Console.WriteLine($"{student.Id}: {student.Name}, {student.Age}, {student.Email}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
