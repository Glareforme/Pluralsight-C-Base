namespace Gragebook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        private string name;
        private List<double> grades;

        public void AddGrade(double grade)
        {
            this.grades.Add(grade);
        }

        public void ShowStatistics()
        {
            var result = 0.0;
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;

             foreach (var number in grades)
            {
                lowestGrade = Math.Min(number, lowestGrade);
                highestGrade = Math.Max(number, highestGrade);
                result += number;
            }

            System.Console.WriteLine("The lowest grade is " + lowestGrade);
            System.Console.WriteLine("The highest grade is " + highestGrade);
            Console.WriteLine($"The average grade is {result / grades.Count:N1}");
        }
    }
}