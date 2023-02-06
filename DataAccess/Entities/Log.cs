#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;


public class Log
{
    public int Id { get; set; }

    public string Message { get; set; }

    public string Sender { get; set; }

    public DateTime CreatedDate { get; set;}

    public int? ReplyToId { get; set; }
    public Log? ReplyTo { get; set; }

    public int BugId { get; set; } 
    public Bug Bug { get; set; }
}
