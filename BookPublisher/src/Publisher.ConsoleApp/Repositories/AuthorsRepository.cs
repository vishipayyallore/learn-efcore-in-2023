using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.Domain;

namespace Publisher.ConsoleApp.Repositories;

public static class AuthorsRepository
{
    public static void GetAuthors(PublisherDbContext publisherDbContext)
    {
        var authors = publisherDbContext.Authors.ToList();

        foreach (var author in authors)
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
        }
    }

    public static void AddAuthor(Author author, PublisherDbContext publisherDbContext)
    {
        publisherDbContext.Authors.Add(author);
        _ = publisherDbContext.SaveChanges();
    }

    public static void AddAuthorWithBook(Author author, Book[] books, PublisherDbContext publisherDbContext)
    {
        foreach (var book in books)
        {
            author.Books.Add(book);
        }

        publisherDbContext.Authors.Add(author);
        _ = publisherDbContext.SaveChanges();
    }

    public static void GetAuthorsWithBooks(PublisherDbContext publisherDbContext)
    {
        var authors = publisherDbContext.Authors.Include(a => a.Books).ToList();

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

}
