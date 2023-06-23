using Microsoft.EntityFrameworkCore;
using Publisher.Data;
using Publisher.Domain;

namespace Publisher.ConsoleApp.Repositories;

public static class AuthorsRepository
{
    public static void GetAuthors()
    {
        using var context = new PublisherDbContext();
        var authors = context.Authors.ToList();

        foreach (var author in authors)
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
        }
    }

    public static void AddAuthor(Author author)
    {
        using var context = new PublisherDbContext();

        context.Authors.Add(author);
        context.SaveChanges();
    }

    public static void AddAuthorWithBook(Author author, Book[] books)
    {
        foreach (var book in books)
        {
            author.Books.Add(book);
        }
        using var context = new PublisherDbContext();

        context.Authors.Add(author);
        context.SaveChanges();
    }

    public static void GetAuthorsWithBooks()
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

}
