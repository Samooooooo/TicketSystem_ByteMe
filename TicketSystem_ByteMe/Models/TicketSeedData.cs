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
        FirstName = "testName",
        LastName = "testLastName",
        JobTitle = JobTitle.Developer
      };
      Employee employee2 = new Employee()
      {
        FirstName = "testName2",
        LastName = "testLastName2",
        JobTitle = JobTitle.Developer
      };
      Project project = new Project()
      {
        Description = "ProjectDescriptionTest",
        Start = DateTime.Now,
        End = DateTime.Now.AddDays(20),
        Title = "TestTitleProject"
      };
      Project project2 = new Project()
      {
        Description = "ProjectDescriptionTest",
        Start = DateTime.Now,
        End = DateTime.Now.AddDays(20),
        Title = "TestTitleProject2"
      };

      dbContext.Add(employee);
      dbContext.Add(employee2); 
      dbContext.Add(project);
      dbContext.Add(project2);
      dbContext.SaveChanges();
    }
  }
  
}
