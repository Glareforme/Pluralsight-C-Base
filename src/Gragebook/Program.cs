using System;
using System.Collections.Generic;

namespace Gragebook
{
    class Program
    {
        static DiskBook book = new DiskBook("Test");
 

        static Random random = new Random();

        static void Main(string[] args)
        {
            HelloMessage(args);

            book.GradeAdded += OnGradeAdded;
            EnterGrade();

            var statistics = book.GetStatistics();

            DisplayStatistics(statistics);
            book.DeleteFileAfterWork();
        }

        private static void DisplayStatistics(Statistics statistics)
        {
            System.Console.WriteLine($"The average grade is {statistics.Average:N1}");
            System.Console.WriteLine($"The highest grade is {statistics.High}");
            System.Console.WriteLine($"The lowest grade is {statistics.Low}");
            System.Console.WriteLine($"The letter grade is {statistics.Letter}");
        }

        private static void EnterGrade()
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException exeption)
                {
                    System.Console.WriteLine(exeption.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        private static void HelloMessage(string[] args)
        {
            try
            {
                Console.WriteLine($"Hello, {args[0]}");
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine($"Hello, noname");
            }
            finally
            {
                Console.WriteLine("Start program");
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("Grade was added");
        }
    }
}