using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Assessment2
{
    class Program
    {
        
        public static void display()
        {
            var File_name = @"D:\Assignment for Simplilearn\Assignment 1\Teacher_Details.txt";
            var table = new DataTable();
            var fileContents = File.ReadAllLines(File_name);
            var splitFileContents = (from f in fileContents select f.Split(',')).ToArray();
            int maxLength = (from s in splitFileContents select s.Count()).Max();
            for (int i = 0; i < maxLength; i++)
                table.Columns.Add();

            foreach (var line in splitFileContents)
            {
                DataRow row = table.NewRow();
                row.ItemArray = (object[])line;
                table.Rows.Add(row);
            }

            Console.WriteLine("\nID\t\tName\t\tClass\t\tSection");

            foreach (DataRow dataRow in table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item + "\t\t");
                }
                Console.WriteLine();
            }
        }

        public static void update()
        {
            Console.WriteLine("Enter the details to be updated:");
            Console.Write("Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Class: ");
            int clss = Convert.ToInt32(Console.ReadLine());
            Console.Write("Section: ");
            string Section = Console.ReadLine();

            var File_name = @"D:\Assignment for Simplilearn\Assignment 1\Teacher_Details.txt";
            using (StreamWriter sw = File.AppendText(File_name))
            {
                sw.WriteLine(Id + "," + Name + "," + clss + "," + Section);
            }
        }
    
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nWelcome to the Teacher's Database.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            string choice = "Y";
            do
            {
                Console.WriteLine("What functionality would you like to perform?");
                Console.WriteLine("\n\t1.Retrieve and Display\n\t2.Update/Add\n");
                Console.WriteLine("Enter the option:");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        display();
                        break;

                    case 2:
                        update();
                        Console.WriteLine("\nDone updating...");
                        break;

                    default:
                        Console.WriteLine("EXITING.....");
                            break;
                }
                Console.WriteLine("\nDo you want to continue? (Y/N)");
                choice = Console.ReadLine();
                Console.WriteLine();
            } while (choice.ToUpper() == "Y");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThank you for using the Teacher's Database.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
            
    }
}
