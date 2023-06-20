using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.Domain;

using (PublisherDbContext context = new())
{
    context.Database.EnsureCreated();
}

GetAuthors();

AddAuthor(new Author { FirstName = "Sri", LastName = "Varu" });

GetAuthors();

AddAuthorWithBook(new Author { FirstName = "Julie", LastName = "Lerman" },
    new Book[]
    {
        new Book { Title = "Programming Entity Framework", PublishDate = new DateTime(2009, 1, 1) },
        new Book { Title = "Programming Entity Framework 2nd Ed", PublishDate = new DateTime(2010, 8, 1) }
    });

GetAuthors();
// ************************ ************************\\

static void GetAuthors()
{
    using var context = new PublisherDbContext();
    var authors = context.Authors.ToList();

    foreach (var author in authors)
    {
        Console.WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
        foreach (var book in author.Books)
        {
            Console.WriteLine($" {book.BookId}. {book.Title}");
        }
    }
}

static void AddAuthor(Author author)
{
    using var context = new PublisherDbContext();

    context.Authors.Add(author);
    context.SaveChanges();
}

static void AddAuthorWithBook(Author author, Book[] books)
{
    foreach (var book in books)
    {
        author.Books.Add(book);
    }
    using var context = new PublisherDbContext();

    context.Authors.Add(author);
    context.SaveChanges();
}
