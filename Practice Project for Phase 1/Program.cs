using System;
using System.IO;
using System.Collections.Generic;

namespace Student_Details
{
    class Program
    {
        static void Main(string[] args)
        {
            var File_name = @"D:\Assignment for Simplilearn\Assignment 1\student_details.txt";
            string[] text = new string[File_name.Length];
            text = File.ReadAllLines(File_name);
            var Name = new List<string>();
            var id = new List<int>();
            var place = new List<string>();
            int count = 0;
            foreach(var line in text)
            {
                var data = line.Split(',');
                Name.Add(data[0]);
                id.Add(Convert.ToInt32(data[1]));
                place.Add(data[2]);
                count++;
            }
            Console.WriteLine("Content of the student_details.txt file:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Name\t\tId\t\tPlace");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(Name[i] + "\t\t" + id[i] + "\t\t" + place[i]);
            }
            Console.ReadKey();
          

        }
    }
}
