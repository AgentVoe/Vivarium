using System;
using System.Collections.Generic;

namespace Vivarium.Context;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateOnly? BYear { get; set; }

    public int? AuthorId { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual Author? Author { get; set; }

    public virtual ICollection<BooksAuthor> BooksAuthors { get; set; } = new List<BooksAuthor>();

    public virtual ICollection<BooksGenre> BooksGenres { get; set; } = new List<BooksGenre>();

    public virtual ICollection<StatusBook> StatusBooks { get; set; } = new List<StatusBook>();
}
