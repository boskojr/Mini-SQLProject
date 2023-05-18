using System.Configuration;
using Dapper;
using Npgsql;
using System.Data;
using MiniProjektSQL.Models;


namespace MiniProjektSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Menusystem();   
        }

        static void Menusystem()
        {

            Console.WriteLine("Welcome to our Time Reporting System!!!");

            bool showMenuSystem = true;

            while (showMenuSystem)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add Person");
                Console.WriteLine("2. Add Project");
                Console.WriteLine("3. Register the time");
                Console.WriteLine("4. Exit");
                Console.Write("");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddPersonNew();
                        Console.WriteLine();
                        break;
                    case "2":
                        AddProject();
                        Console.WriteLine();
                        break;
                    case "3":
                        RegisterTime();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program --> ");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
        }

        static void AddPersonNew()
        {
            Console.WriteLine("Enter name of person:");
            string newname = Console.ReadLine();

            // Call method in PostgresqlConnection class to add person to database
            PostgressConnection.CreateNewUser(newname);
            Console.WriteLine($"{newname} added successfully!");
        }
        static void AddProject()
        {
            Console.WriteLine("Enter name of project:");
            string addProjectName = Console.ReadLine();

            // Call method in PostgresqlConnection class to add project to database
            PostgressConnection.CreateNewProject(addProjectName);
            Console.WriteLine($"Your new project name is {addProjectName}");
            Console.WriteLine($"{addProjectName} project added successfully!");
        }

        static void RegisterTime()
        {
            Console.WriteLine("Enter name of the person:");
            string person_Name = Console.ReadLine();

            Console.WriteLine("Enter name of  the project:");
            string project_Name = Console.ReadLine();

            Console.WriteLine("Enter number of hours worked:");
            int hours_Worked = int.Parse(Console.ReadLine());

            // Get the ID of the person and project from the database
            int personNames = PostgressConnection.GetUserIdByName(person_Name);
            int projectNames = PostgressConnection.GetProjectIdByName(project_Name);

            // Call method in PostgresqlConnection class to register time worked on project
            PostgressConnection.TimeReport(projectNames, personNames, hours_Worked);
            Console.WriteLine($"Hi {person_Name}, You have been working in this project {project_Name} in the last {hours_Worked} hours");
            Console.WriteLine("Time registered successfully!");
        }

    }
}