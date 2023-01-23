using Gragebook;

namespace Gradebook.Tests;

public class GradebookUnitTests
{
    InMemoryBook book = new InMemoryBook("Test");
    [Fact]
    public void GradebookCalculateCorrect()
    {
        book.AddGrade(50.0);
        book.AddGrade(60.0);
        book.AddGrade(70);
        book.AddGrade(80);

        var actualResult = book.GetStatistics();

        var expectedResult = new Statistics()
        {
            Low = 50.0,
            High = 80,
        };
        //Assert.Equal(expectedResult.Average, actualResult.Average, 1);
        Assert.Equal(expectedResult.High, actualResult.High, 1);
        Assert.Equal(expectedResult.Low, actualResult.Low, 1);
       // Assert.Equal(expectedResult.Letter, actualResult.Letter);
    }
}