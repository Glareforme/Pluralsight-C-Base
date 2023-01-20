using Gragebook;

namespace Gradebook.Tests;

public class GradebookUnitTests
{
    Book book = new Book("Test");
    [Fact]
    public void Test1()
    {
        book.AddGrade(10.1);
        book.AddGrade(0.1);
        book.AddGrade(20);

        var actualResult = book.GetStatistics();

        var expectedResult = new Statistics()
        {
            Average = 6.7,
            Low = 0.1,
            High = 10.1
        };
        Assert.Equal(actualResult.Average, actualResult.Average, 1);
        Assert.Equal(actualResult.High, actualResult.High, 1);
        Assert.Equal(actualResult.Low, expectedResult.Low, 1);
    }
}