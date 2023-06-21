using Microsoft.EntityFrameworkCore;

namespace TicketSystem_ByteMe.Models
{
  public class TicketSystemDBContext : DbContext
  {
    public TicketSystemDBContext(DbContextOptions options) : base(options) {
      Database.EnsureCreated();
    }
  }
}
