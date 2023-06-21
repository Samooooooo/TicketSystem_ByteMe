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
  }
}
