namespace TicketSystem_ByteMe.Models
{
  public interface ITicketSystemRepository
  {
    IQueryable<Project> Projects { get; }
    IQueryable<Employee> Employees { get; }
    IQueryable<Ticket> Tickets { get; }

  }
}
