using Microsoft.EntityFrameworkCore;

namespace TicketSystem_ByteMe.Models
{
  public class TicketSystemDBContext : DbContext
  {
    public TicketSystemDBContext(DbContextOptions options) : base(options) {
      Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TicketSystem_ByteMe;Trusted_Connection=True;");
    }
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //  modelBuilder.Entity<Ticket>()
    //    .HasKey(e => new { e.})        

    //}
    public DbSet<Project> Projects { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
  }
}
