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
      ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID).Description = ticket.Description;
      ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID).AssignedTo = ticket.AssignedTo;   
      //ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID).CreatedAt = ticket.CreatedAt;   
      //ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID).CreatedBy = ticket.CreatedBy;   
      //ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID).Headline = ticket.Headline;   
      //ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID).Project = ticket.Project;   
      //ctx.Tickets.FirstOrDefault(t => t.TicketID == ticket.TicketID).SolvedAt = ticket.SolvedAt;   
      ctx.SaveChanges();
    }
  }
}
