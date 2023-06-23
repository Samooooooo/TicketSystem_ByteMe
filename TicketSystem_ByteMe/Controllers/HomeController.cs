using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSystem_ByteMe.Models;

namespace TicketSystem_ByteMe.Home
{
  public class HomeController : Controller
  {
    private ITicketSystemRepository repo;
    public HomeController(ITicketSystemRepository repo)
    {
      this.repo = repo;
    }

    public IActionResult Index()
    {

      return View(repo.Tickets.Include(t => t.Project).Include(t => t.AssignedTo).Include(t => t.CreatedBy).OrderBy(h => h.Project));
    }

    public IActionResult TicketDetail(int id)
    {
      return View(repo.Tickets.FirstOrDefault(t => t.TicketID == id));
    }
    [HttpGet]
    public IActionResult NewTicket()
    {
      GenerateValues();
      return View();
    }
    [HttpPost]
    public IActionResult NewTicket(Ticket ticket)
    {
      ticket.Project = repo.Projects.FirstOrDefault(t => t.ProjectID == ticket.Project.ProjectID);
      ticket.CreatedBy = repo.Employees.FirstOrDefault(t => t.EmployeeID == ticket.CreatedBy.EmployeeID);
      ticket.AssignedTo = repo.Employees.FirstOrDefault(t => t.EmployeeID == ticket.AssignedTo.EmployeeID);

      if (ModelState.IsValid)
      {
        repo.AddTicket(ticket);
        return RedirectToAction("Index");
      }
      else
      {
        GenerateValues();
        return View(ticket);

      }
    }
    private void GenerateValues()
    {
      var employees = repo.Employees.Select(n => new { Name = n.LastName + ' ' + n.FirstName, ID = n.EmployeeID.ToString() });
      var projects = repo.Projects.Select(n => new { n.Title,  n.ProjectID });
      ViewBag.Project = new SelectList(projects, "ProjectID", "Title");
      ViewBag.Employee = new SelectList(employees, "ID", "Name");
    }
  }
}
