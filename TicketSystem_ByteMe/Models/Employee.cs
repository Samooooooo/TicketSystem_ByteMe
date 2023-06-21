using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
namespace TicketSystem_ByteMe.Models
{
public enum JobTitle
{
  Developer,
  Tester
}
  public class Employee
  {
    [Key]
    public int EmployeeID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public JobTitle JobTitle { get; set; }
  }
}
