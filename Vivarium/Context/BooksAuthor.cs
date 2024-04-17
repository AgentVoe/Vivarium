using System;
using System.Collections.Generic;

namespace Vivarium.Context;

/// <summary>
/// Книга и ее автор
/// </summary>
public partial class BooksAuthor
{
    public int Id { get; set; }

    public int? BookId { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual Book? Book { get; set; }
}
