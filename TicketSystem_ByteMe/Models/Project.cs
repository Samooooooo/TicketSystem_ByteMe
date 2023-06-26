using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TicketSystem_ByteMe.Models
{
  public class Project
  {
    [Key]
    public long ProjectID { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
  }
}
