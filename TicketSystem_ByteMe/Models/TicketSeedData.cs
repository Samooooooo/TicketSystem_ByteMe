using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace TicketSystem_ByteMe.Models
{
  public static class TicketSeedData
  {
    public static void EnsurePopulated(IApplicationBuilder app)
    {
      TicketSystemDBContext dbContext = app
        .ApplicationServices
        .CreateScope()
        .ServiceProvider
        .GetRequiredService<TicketSystemDBContext>();

      if (dbContext.Database.GetPendingMigrations().Any())
      {
        dbContext.Database.Migrate();
      
      }
      if (!dbContext.Employees.Any())
      {
          TestData(dbContext);
      }

    }
    private static void TestData(TicketSystemDBContext dbContext)
    {

      Employee employee = new Employee()
      {
        FirstName = "osama",
        LastName = "osama2",
        JobTitle = JobTitle.Developer
      };
      Employee employee2 = new Employee()
      {
        FirstName = "nils",
        LastName = "nils2",
        JobTitle = JobTitle.Developer
      };
      Project project = new Project()
      {
        Description = "Badr",
        Start = DateTime.Now,
        Title = "Badr"
      };
      Project project2 = new Project()
      {
        Description = "kemal",
        Start = DateTime.Now,
        Title = "kemal"
      };

      dbContext.Add(employee);
      dbContext.Add(employee2); 
      dbContext.Add(project);
      dbContext.Add(project2);
      dbContext.SaveChanges();
    }
  }
  
}
