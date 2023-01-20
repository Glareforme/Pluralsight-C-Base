using Gragebook;

namespace Gradebook.Tests;

public class TypeUnitTests
{

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
    public void CanSetNewBookToOtherBook()
    {
        var book = GetBook("Test");
        SetBookToOtherBook(book, "New name");

        Assert.NotEqual("New name", book.Name);
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
}