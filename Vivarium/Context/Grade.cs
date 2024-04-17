using System;
using System.Collections.Generic;

namespace Vivarium.Context;

/// <summary>
/// Оценка книги
/// </summary>
public partial class Grade
{
    public int Id { get; set; }

    public int? Grade1 { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
}
