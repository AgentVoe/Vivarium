namespace Vivarium.Context;

public partial class Author
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<BooksAuthor> BooksAuthors { get; set; } = new List<BooksAuthor>();
}
