using System;
using System.Collections.Generic;

namespace Vivarium.Context;

public partial class Challenge
{
    public int Id { get; set; }

    public DateOnly? ChYear { get; set; }

    public int? Plan { get; set; }

    public int? Fact { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
