using System;
using System.Collections.Generic;

namespace Vivarium.Context;

/// <summary>
/// Пользователь
/// </summary>
public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Pass { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<Challenge> Challenges { get; set; } = new List<Challenge>();

    public virtual ICollection<StatusBook> StatusBooks { get; set; } = new List<StatusBook>();
}
