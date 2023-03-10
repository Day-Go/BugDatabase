#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;


public enum Status
{
    Unassigned,
    Assigned,
    InProgress,
    Resolved,
    OnHold
}

public enum Priority
{
    Low,
    Medium,
    High
}

public class Bug
{
    [Key]
    public int Id { get; set; }

    public bool Approved { get; set; }

    [MaxLength(100)]
    public string Project { get; set; }

    [MaxLength(100)]
    public string Department { get; set; }

    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(100)]
    public string AssignedTo { get; set; }

    public Status Status { get; set; }

    public Priority Priority { get; set; }

    [MaxLength(100)]
    public string FixFor { get; set; }

    public string Version { get; set; }

    [MaxLength(100)]
    public string Computer { get; set; }

    public ICollection<Comment> Comments { get; set; }
}
