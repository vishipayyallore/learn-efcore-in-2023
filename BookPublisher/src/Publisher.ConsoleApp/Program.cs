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

// ************************ ************************\\

static void GetAuthors()
{
    using var context = new PublisherDbContext();
    var authors = context.Authors.ToList();

    foreach (var author in authors)
    {
        Console.WriteLine($"{author.Id} {author.FirstName} {author.LastName}");
    }
}

static void AddAuthor(Author author)
{
    using var context = new PublisherDbContext();

    context.Authors.Add(author);
    context.SaveChanges();
}
