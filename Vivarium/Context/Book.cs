namespace Vivarium.Context;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? BYear { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<BooksAuthor> BooksAuthors { get; set; } = new List<BooksAuthor>();

    public virtual ICollection<BooksGenre> BooksGenres { get; set; } = new List<BooksGenre>();

    public virtual ICollection<StatusBook> StatusBooks { get; set; } = new List<StatusBook>();
}
