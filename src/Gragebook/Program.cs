using System;
using System.Collections.Generic;

namespace Gragebook
{
    class Program
    {
        static Book book = new Book("Test");
        static Random random = new Random();
        static void Main(string[] args)
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

            book.GradeAdded += OnGradeAdded;
            
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


            var statistics = book.GetStatistics();

            System.Console.WriteLine($"The average grade is {statistics.Average:N1}");
            System.Console.WriteLine($"The highest grade is {statistics.High}");
            System.Console.WriteLine($"The lowest grade is {statistics.Low}");
            System.Console.WriteLine($"The letter grade is {statistics.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("Grade was added");
        }
    }
}