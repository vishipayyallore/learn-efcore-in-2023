namespace Publisher.Domain;

public class Author
{
    public Author()
    {
        Books = [];
    }

    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public List<Book> Books { get; set; }
}