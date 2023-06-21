using Microsoft.EntityFrameworkCore;
using Publisher.Domain;

namespace Publisher.Data;

public class PublisherDbContext : DbContext
{
    const string dbConnectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase";

    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Book> Books => Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Caution: Never do this in Production
        optionsBuilder.UseSqlServer(dbConnectionString);
    }
}