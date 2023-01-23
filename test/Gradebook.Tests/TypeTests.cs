using Gragebook;

namespace Gradebook.Tests;

public delegate string WriteLogMessage(string logMessage);

public class TypeUnitTests
{
    int count = 0;
    WriteLogMessage logMessage;

    #region Tests
    [Fact]
    public void TheBooksReturnsDifferentObjects()
    {
        var book1 = GetBook("Test name");
        var book2 = GetBook("Testdad");
        var book = GetBook(" ");

        Assert.Equal("Test name", book1.Name);
        Assert.Equal("Testdad", book2.Name);
        Assert.Equal(" ", book.Name);
    }

    [Fact]
    public void TwoVarsReturnsSameObject()
    {
        var book1 = GetBook("Test name");
        var book2 = book1;
        var book = book2;
        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book, book1));
    }

    [Fact]
    public void CanSetNewNameFromReference()
    {
        var book1 = GetBook("Test name");
        var book2 = book1;
        var book = book2;

        SetName(book, "New name");

        Assert.True(Object.ReferenceEquals(book, book1));
        Assert.Equal("New name", book.Name);
    }

    [Fact]
    public void CantSetNewBookToOtherBook()
    {
        var book = GetBook("Test");
        SetBookToOtherBook(book, "New name");

        Assert.NotEqual("New name", book.Name);
    }

    public void CanSetNewBookToOtherBook()
    {
        var book = GetBook("Test");
        SetBookToOtherBook(ref book, "New name");

        Assert.Equal("New name", book.Name);
    }

    [Fact]
    public void ValueTypesCantPassByValue()
    {
        var x = GetInt();
        SetInt(x);

        Assert.Equal(3, x);
    }

    [Fact]
    public void ValueTypesCanPassByValue()
    {
        var x = GetInt();
        SetInt(ref x);

        Assert.Equal(32, x);
    }

    [Fact]
    public void StringsBehaveLikeValueType()
    {
        string name = "Gaga";
        TryMakeUpperCase(name);

        Assert.NotEqual("GAGA", name);

        var NewName = MakeUpperCase(name);

        Assert.NotEqual("GAGA", name);
        Assert.Equal("Gaga", name);
        Assert.Equal("GAGA", NewName);
    }

    [Fact]
    public void DelegateWorksCorrect()
    {
        logMessage += ReturnMessage; 
        logMessage += ReturnDataTime;
        var result = logMessage("dsada");

        Assert.NotEqual("dsada", result);
        Assert.Equal(2, count);
    }

    #endregion

    #region Methods
    string ReturnMessage(string logs)
    {
        count++;
        return logs;
    }

    string ReturnDataTime(string s)
    {
        count++;
        return DateTime.Today.ToString();
    }
    private void TryMakeUpperCase(string param)
    {
        param.ToUpper();
    }

    private string MakeUpperCase(string param)
    {
        return param.ToUpper();
    }

    public int GetInt()
    {
        return 3;
    }

    public void SetInt(ref int integer)
    {
        integer = 32;
    }

    public void SetInt(int integer)
    {
        integer = 32;
    }

    private void SetBookToOtherBook(ref Book book, string newName)
    {
        book = new Book(newName);
    }

    private void SetBookToOtherBook(Book book, string newName)
    {
        book = new Book(newName);
    }

    private void SetName(Book book, string newName)
    {
        book.Name = newName;
    }

    private Book GetBook(string name)
    {
        return new Book(name);
    }
    #endregion
}