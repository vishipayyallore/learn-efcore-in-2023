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
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine($"\t{book.BookId}. {book.Title}");
            }
        }
    }

    #region Filters
    public static void QueryFilters(string name, PublisherDbContext publisherDbContext)
    {
        WriteLine($"***** QueryFilters *****");
        var authors = publisherDbContext.Authors.Where(s => s.FirstName == name).ToList();

        foreach (var author in authors)
        {
            WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
        }

        //var filter = "L%";
        //var authors = _context.Authors
        //    .Where(a => EF.Functions.Like(a.LastName, filter)).ToList();
    }

    // Tip: LINQ .Contains() method will translate into EF.Functions.Like(%abc%)
    public static void QueryFiltersWithLike(string filter, PublisherDbContext publisherDbContext)
    {
        WriteLine($"***** QueryFilters With Like *****");

        var authors = publisherDbContext.Authors
            .Where(a => EF.Functions.Like(a.LastName!, filter)).ToList();

        foreach (var author in authors)
        {
            WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
        }

    }

    public static void FindIt(PublisherDbContext publisherDbContext, int id)
    {
        var author = publisherDbContext.Authors.Find(id);

        if (author == null)
        {
            return;
        }

        WriteLine($"{author.Id} {author.FirstName} {author.LastName} --");
    }

    public static void SkipAndTakeAuthors(PublisherDbContext publisherDbContext)
    {
        var groupSize = 2;
        for (int i = 0; i < 5; i++)
        {
            var authors = publisherDbContext.Authors.Skip(groupSize * i).Take(groupSize).ToList();
            Console.WriteLine($"Group {i}:");
            foreach (var author in authors)
            {
                Console.WriteLine($" {author.FirstName} {author.LastName}");
            }
        }
    }
    #endregion

    public static void SortAuthors(PublisherDbContext publisherDbContext)
    {
        var authorsByLastName = publisherDbContext.Authors
            .OrderBy(a => a.LastName)
            .ThenBy(a => a.FirstName).ToList();
        authorsByLastName.ForEach(a => Console.WriteLine(a.LastName + "," + a.FirstName));

        var authorsDescending = publisherDbContext.Authors
            .OrderByDescending(a => a.LastName)
            .ThenByDescending(a => a.FirstName).ToList();
        Console.WriteLine("**Descending Last and First**");
        authorsDescending.ForEach(a => Console.WriteLine(a.LastName + "," + a.FirstName));
        
        var lermans = publisherDbContext.Authors.Where(a => a.LastName == "Lerman").OrderByDescending(a => a.FirstName).ToList();
        lermans.ForEach(a => Console.WriteLine(a.LastName + "," + a.FirstName));
    }

}
