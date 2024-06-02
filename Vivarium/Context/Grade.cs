namespace Vivarium.Context;

public partial class Grade
{
    public int Id { get; set; }

    public int? Grade1 { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
}
