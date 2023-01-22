using System;
using System.Collections.Generic;

namespace Gragebook
{
    public class Book
    {
        Random random = new Random();
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        public string Name;
        private List<double> grades;
        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(random.Next(99, 81));
                    break;

                case 'B':
                    AddGrade(random.Next(80, 71));
                    break;
                case 'C':
                    AddGrade(random.Next(70, 61));
                    break;
                case 'D':
                    AddGrade(random.Next(60, 51));
                    break;
                case 'E':
                    AddGrade(random.Next(50, 41));
                    break;
                case 'F':
                    AddGrade(random.Next(40, 0));
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                this.grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            var indexer = 0;

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;
            if (grades.Count != 0)
            {
                do
                {
                    if (grades[indexer] == 23.5)
                    {
                        continue;
                    }
                    else if (grades[indexer] == 99.9)
                    {
                        break;
                    }
                    else if (grades[indexer] == 1231231.3)
                    {
                        goto done;
                    }
                    result.Low = Math.Min(grades[indexer], result.Low);
                    result.High = Math.Max(grades[indexer], result.High);
                    result.Average += grades[indexer];
                    indexer++;
                } while (indexer < grades.Count);
            }
            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                case var d when d >= 50.0:
                    result.Letter = 'E';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }

        done:
            return result;
        }
    }
}