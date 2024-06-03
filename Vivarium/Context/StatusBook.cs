namespace Vivarium.Context;

public partial class StatusBook
{
    public int Id { get; set; }

    public DateOnly? StDate { get; set; }

    public int? UserId { get; set; }

    public int? BookId { get; set; }

    public int? StatusId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Status? Status { get; set; }

    public virtual User? User { get; set; }
}
