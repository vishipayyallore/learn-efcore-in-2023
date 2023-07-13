using Publisher.ConsoleApp.Repositories;
using Publisher.Data;
using Publisher.Domain;

EnsureDatabaseCreated();

using PublisherDbContext _publisherDbContext = new();

AuthorsRepository.GetAuthors(_publisherDbContext);

AuthorsRepository.AddAuthor(GetAuthor("Sri", "Varu"), _publisherDbContext);
AuthorsRepository.AddAuthor(GetAuthor("Scott", "Rudy"), _publisherDbContext);
AuthorsRepository.AddAuthor(GetAuthor("Josie", "Newf"), _publisherDbContext);
AuthorsRepository.GetAuthors(_publisherDbContext);

AuthorsRepository.AddAuthorWithBook(GetAuthor("Julie", "Lerman"), GetFewBooks(), _publisherDbContext);
AuthorsRepository.GetAuthorsWithBooks(_publisherDbContext);

var name = "Josie";
ForegroundColor = ConsoleColor.Cyan;
AuthorsRepository.QueryFilters(name, _publisherDbContext);

var filter = "L%";
AuthorsRepository.QueryFiltersWithLike(filter, _publisherDbContext);

ForegroundColor = ConsoleColor.DarkGray;
AuthorsRepository.FindIt(_publisherDbContext, 2);

ForegroundColor = ConsoleColor.DarkGreen;
AuthorsRepository.SkipAndTakeAuthors(_publisherDbContext);

ForegroundColor = ConsoleColor.Yellow;
AuthorsRepository.SortAuthors(_publisherDbContext);

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();

static void EnsureDatabaseCreated()
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

