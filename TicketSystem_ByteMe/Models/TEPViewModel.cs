using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketSystem_ByteMe.Models
{
  public class TEPViewModel
  {
    public SelectList Employees { get; set; }
    public SelectList Projects { get; set; }
    public Ticket Ticket { get; set; }
  }
}
