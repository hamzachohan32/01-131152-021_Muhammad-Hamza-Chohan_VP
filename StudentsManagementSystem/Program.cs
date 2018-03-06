using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace StudentsManagementSystem
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Main File Path");
            string path = args[0];
            Console.WriteLine("Deletion File Path");
            string path1 = args[0]+"1.txt";
            Console.WriteLine("Attendence File Path");
            string path2 = args[0] + "2.txt";
            Console.WriteLine("Welcome to Student Management System");
            Console.WriteLine("Please Select and Option");
            StreamWriter file = new StreamWriter(path);
            file.Close();
            Program obj = new Program();
            char option = 'y';
            do
            {
                obj.availableFunctions();// List of Functions
                int input = int.Parse(Console.ReadLine());
                obj.callFunctions(input, path, path1, path2);

                Console.Write("Again(y/n)::");
                option = Console.ReadKey().KeyChar;
            } while (option == 'y' || option == 'Y');
            Console.ReadLine();
        }
        public void availableFunctions()
        {
            Console.WriteLine("1. Create Student profile");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Delete Student Record");
            Console.WriteLine("4. List top 03 of class");
            Console.WriteLine("5. Mark student attendance");
            Console.WriteLine("6. View attendance");

        }
        public void callFunctions(int choice, string path, string path1, string path2)
        {
            if (choice == 1)
            {
                functions obj = new functions();
                obj.createStudent(path);
            }
            if (choice == 2)
            {
                functions obj = new functions();
                obj.search(path);
            }
            if (choice == 3)
            {
                functions obj = new functions();
                obj.delete(path,path1);
            }
            if (choice == 4)
            {
                functions obj = new functions();
                obj.topStudents(path);
            }
            if (choice == 5)
            {
                functions obj = new functions();
                obj.markAttendence(path,path2);
            }
            if (choice == 6)
            {
                functions obj = new functions();
                obj.viewAttendence(path2);
            }
        }

    }
}
