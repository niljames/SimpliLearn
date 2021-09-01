using System;
using System.Collections.Generic;

using System.IO;


namespace Assessment
{
    class Program
    {
       /* public static List<int> assign()
        {
            var File_name = @"D:\Assignment for Simplilearn\Assignment 1\Teacher_Details.txt";
            string[] lines = File.ReadAllLines(File_name);
            var Name = new List<string>();
            var id = new List<int>();
            var clss = new List<int>();
            var Section = new List<string>();
            int count = 5;
            foreach (string line in lines)
            {
                var data = line.Split(',');
                id.Add(Convert.ToInt32(data[0]));
                Name.Add(data[1]);
                clss.Add(Convert.ToInt32(data[2]));
                Section.Add(data[3]);
                count++;
            }
            return id;
        }*/

        public static int display()
        {
            var File_name = @"D:\Assignment for Simplilearn\Assignment 1\Teacher_Details.txt";
            string[] lines = File.ReadAllLines(File_name);
            var Name = new List<string>();
            var id = new List<int>();
            var clss = new List<int>();
            var Section = new List<string>();
            int count = 0;
            foreach (string line in lines)
            {
                var data = line.Split(',');
                Console.WriteLine(data[0]);
                id.Add(Convert.ToInt32(data[0]));
                Name.Add(data[1]);
                clss.Add(Convert.ToInt32(data[2]));
                Section.Add(data[3]);
                count++;
            }
            Console.WriteLine("Content of the Teacher_Details_1.txt file:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Id\t\tName\t\tClass\t\tSection");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < count; i++)

            {
                Console.WriteLine(id[i] + "\t\t" + Name[i] + "\t\t" + clss[i] + "\t\t" + Section[i]);
            }

            return count;
        }

        public static void update(int count)
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
           /* List<int> id1 = assign();

            for (int i = 0; i < count; i++)
            {
                if (id1[i] == Id)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot update as no two teachers can have the same ids.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }*/
            using (StreamWriter sw = File.AppendText(File_name))
            {
                sw.WriteLine(Id + "," + Name + "," + clss + "," + Section);
            }
            Console.WriteLine("\nDone updating...");
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
                int count = 0;
                Console.WriteLine("What functionality would you like to perform?");
                Console.WriteLine("\n\t1.Retrieve and Display\n\t2.Update/Add\n");
                Console.WriteLine("Enter the option:");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        count = display();
                        break;

                    case 2:
                        update(count);
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

