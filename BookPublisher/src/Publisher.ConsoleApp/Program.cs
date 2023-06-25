using Publisher.ConsoleApp.Repositories;
using Publisher.Data;
using Publisher.Domain;

using (PublisherDbContext context = new())
{
    context.Database.EnsureCreated();
}

AuthorsRepository.GetAuthors();

AuthorsRepository.AddAuthor(GetAuthor("Sri", "Varu"));
AuthorsRepository.AddAuthor(GetAuthor("Scott", "Rudy"));

AuthorsRepository.GetAuthors();

AuthorsRepository.AddAuthorWithBook(GetAuthor("Julie",  "Lerman" ),
    new Book[]
    {
        new Book { Title = "Programming Entity Framework", PublishDate = new DateTime(2009, 1, 1) },
        new Book { Title = "Programming Entity Framework 2nd Ed", PublishDate = new DateTime(2010, 8, 1) }
    });

AuthorsRepository.GetAuthorsWithBooks();

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();

static Author GetAuthor(string firstName, string lastName) =>
    new() { FirstName = firstName, LastName = lastName };