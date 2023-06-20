using Publisher.Data;

using (PublisherDbContext context = new())
{
    context.Database.EnsureCreated();
}

GetAuthors();

// ************************ ************************\\

static void GetAuthors()
{
    using var context = new PublisherDbContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}
