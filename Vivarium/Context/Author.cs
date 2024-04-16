using System;
using System.Collections.Generic;

namespace Vivarium.Context;

public partial class Author
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Surname { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual ICollection<BooksAuthor> BooksAuthors { get; set; } = new List<BooksAuthor>();
}
