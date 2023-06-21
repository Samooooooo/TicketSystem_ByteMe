using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

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
//    Introducing FOREIGN KEY constraint 'FK_Tickets_Employees_Created' on table 'Tickets' may cause cycles or multiple cascade paths.Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
//Could not create constraint or index.See previous errors.

    public DbSet<Project> Projects { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
  }
}
