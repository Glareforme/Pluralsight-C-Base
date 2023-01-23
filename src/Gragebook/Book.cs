using System;
using System.Collections.Generic;

namespace Gragebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class InMemoryBook : BookBase
    {
        Random random = new Random();
        public InMemoryBook(string name) : base(name)
        {
            // One = 2; can change 
            grades = new List<double>();
            Name = name;
        }

        public override void DeleteFileAfterWork()
        {
        }

        private List<double> grades;

        public override void AddGrade(double grade)
        {
            if (grade < 100 && grade > 0)
            {
                this.grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            var indexer = 0;

            if (grades.Count != 0)
            {
                do
                {
                    result.Add(grades[indexer]);
                    indexer++;
                } while (indexer < grades.Count);
            }

            return result;
        }

        #region Example 
        public string Dsa
        {
            get
            {
                return dsa;
            }
            set
            {
                dsa = value;
            }
        }
        private string dsa;

        readonly int One = 1;

        public void AddLetterGrade(char letter)
        {
            // One = 2; cant change 
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
        #endregion
    }

}