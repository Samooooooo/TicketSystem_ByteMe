using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TicketSystem_ByteMe.Models
{
  public class Ticket
  {
    [Key]
    public int TicketID { get; set; }
    [Required(ErrorMessage ="This field is required")]
    public string Headline { get; set; }
    [Required(ErrorMessage = "This field is required")]
    public string Description { get; set; }
    [Required(ErrorMessage = "This field is required")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Project Project { get; set; }
    public DateTime CreatedAt { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Employee CreatedBy { get; set; }

    [Required(ErrorMessage = "This field is required")]
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Employee AssignedTo { get; set; }

    public DateTime? SolvedAt { get; set; }
  }
}
