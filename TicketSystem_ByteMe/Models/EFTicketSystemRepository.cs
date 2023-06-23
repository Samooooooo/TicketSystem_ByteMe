using Microsoft.EntityFrameworkCore;

namespace TicketSystem_ByteMe.Models
{
  public class EFTicketSystemRepository : ITicketSystemRepository
  {
    private TicketSystemDBContext ctx;
    public EFTicketSystemRepository(TicketSystemDBContext ctx)
    {
      this.ctx = ctx;
    }
    public IQueryable<Project> Projects => ctx.Projects;
    public IQueryable<Employee> Employees => ctx.Employees;
    public IQueryable<Ticket> Tickets => ctx.Tickets;

    public void AddTicket(Ticket ticket)
    {
      ctx.Tickets.Add(ticket);
      ctx.SaveChanges();
    }
    public void EditTicket(Ticket ticket)
    {
      Ticket oldTicket = ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID);
      oldTicket.Description = ticket.Description;
      oldTicket.AssignedTo = ticket.AssignedTo;
      ctx.Update(oldTicket);
      ctx.SaveChanges();
    }
  }
}
