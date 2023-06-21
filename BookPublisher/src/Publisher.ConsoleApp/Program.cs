using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.Domain;

using (PublisherDbContext context = new())
{
    context.Database.EnsureCreated();
}

GetAuthors();

AddAuthor(new Author { FirstName = "Sri", LastName = "Varu" });
AddAuthor(new Author { FirstName = "Scott", LastName = "Rudy" });

GetAuthors();

AddAuthorWithBook(new Author { FirstName = "Julie", LastName = "Lerman" },
    new Book[]
    {
        new Book { Title = "Programming Entity Framework", PublishDate = new DateTime(2009, 1, 1) },
        new Book { Title = "Programming Entity Framework 2nd Ed", PublishDate = new DateTime(2010, 8, 1) }
    });

GetAuthorsWithBooks();

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();

// ************************ ************************\\

static void GetAuthors()
{
    using var context = new PublisherDbContext();
    var authors = context.Authors.ToList();

    foreach (var author in authors)
    {
        ForegroundColor = ConsoleColor.Blue;
        WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
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

static void GetAuthorsWithBooks()
{
    using var context = new PublisherDbContext();

    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authors)
    {
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
        foreach (var book in author.Books)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine($"\t{book.BookId}. {book.Title}");
        }
    }
}

