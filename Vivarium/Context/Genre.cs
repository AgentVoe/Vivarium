using System;
using System.Collections.Generic;

namespace Vivarium.Context;

public partial class Genre
{
    public int Id { get; set; }

    public string? GenreName { get; set; }

    public virtual ICollection<BooksGenre> BooksGenres { get; set; } = new List<BooksGenre>();
}
