using System;
using System.Collections.Generic;

namespace Gragebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var result = 0.0;
            var grade = new List<double> { 1.3, 13.3, 3, 10.3 };
            grade.Add(random.Next(1, 10));

            foreach (var number in grade)
            {
                result += number;
            }
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

            Console.WriteLine("The average grade is " + result / grade.Count);
            System.Console.WriteLine($"Just result {result}");
            System.Console.WriteLine($"Result {result:N1} with fixed numbers after comma");
        }
    }
}