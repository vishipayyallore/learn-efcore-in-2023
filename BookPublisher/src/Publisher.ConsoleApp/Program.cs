using Publisher.ConsoleApp.Repositories;
using Publisher.Data;
using Publisher.Domain;

EnsureDbCreated();

AuthorsRepository.GetAuthors();

AuthorsRepository.AddAuthor(GetAuthor("Sri", "Varu"));
AuthorsRepository.AddAuthor(GetAuthor("Scott", "Rudy"));
AuthorsRepository.GetAuthors();

AuthorsRepository.AddAuthorWithBook(GetAuthor("Julie", "Lerman"), GetFewBooks());
AuthorsRepository.GetAuthorsWithBooks();

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();

static void EnsureDbCreated()
{
    using PublisherDbContext context = new();
    _ = context.Database.EnsureCreated();
}

static Author GetAuthor(string firstName, string lastName) =>
    new() { FirstName = firstName, LastName = lastName };

static Book GetBook(string title, DateTime publishDate) =>
    new() { Title = title, PublishDate = publishDate };

static Book[] GetFewBooks() => new Book[]
        {
            GetBook("Programming Entity Framework", new DateTime(2009, 1, 1)),
            GetBook("Programming Entity Framework 2nd Ed", new DateTime(2010, 8, 1))
        };