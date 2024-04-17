using System;
using System.Collections.Generic;

namespace Vivarium.Context;

/// <summary>
/// Статус книги
/// </summary>
public partial class Status
{
    public int Id { get; set; }

    public string? Status1 { get; set; }

    public virtual ICollection<StatusBook> StatusBooks { get; set; } = new List<StatusBook>();
}
