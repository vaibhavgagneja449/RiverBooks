namespace RiverBooks.Books.Tests.Entities;

public class BookUpdateTitle
{
  [Fact]
  public void ThrowsGivenEmptyTitle()
  {
    var book = new Book(Guid.NewGuid(), "title", "author", 1m);
    var ex = Should.Throw<ArgumentException>(() => book.UpdateTitle(""));
    ex.Message.ShouldContain("Title");


  }

  [Fact]
  public void ThrowsGivenNullTitle()
  {
    var book = new Book(Guid.NewGuid(), "title", "author", 1m);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
    var ex = Should.Throw<ArgumentException>(() => book.UpdateTitle(""));
    ex.Message.ShouldContain("Title");
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
  }
}
