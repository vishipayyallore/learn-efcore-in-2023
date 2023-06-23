using Publisher.ConsoleApp.Repositories;
using Publisher.Data;
using Publisher.Domain;

using (PublisherDbContext context = new())
{
    context.Database.EnsureCreated();
}

AuthorsRepository.GetAuthors();

AuthorsRepository.AddAuthor(new Author { FirstName = "Sri", LastName = "Varu" });
AuthorsRepository.AddAuthor(new Author { FirstName = "Scott", LastName = "Rudy" });

AuthorsRepository.GetAuthors();

AuthorsRepository.AddAuthorWithBook(new Author { FirstName = "Julie", LastName = "Lerman" },
    new Book[]
    {
        new Book { Title = "Programming Entity Framework", PublishDate = new DateTime(2009, 1, 1) },
        new Book { Title = "Programming Entity Framework 2nd Ed", PublishDate = new DateTime(2010, 8, 1) }
    });

AuthorsRepository.GetAuthorsWithBooks();

ResetColor();

WriteLine("\n\nPress any key ...");
ReadKey();


