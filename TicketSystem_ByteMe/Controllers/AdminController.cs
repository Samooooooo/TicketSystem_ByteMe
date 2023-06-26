using Microsoft.AspNetCore.Mvc;
using TicketSystem_ByteMe.Models;

namespace TicketSystem_ByteMe.Home
{
  public class AdminController : Controller
  {
    private ITicketSystemRepository repo;

    public AdminController(ITicketSystemRepository repository)
    {
      repo = repository;
    }

    public IActionResult Home()
    {
      return View();
    }

    public IActionResult ShowProjects()
    {
      return View(repo.Projects);
    }

    [HttpGet]
    public IActionResult NewProject()
    {
      return View();
    }
    [HttpPost]
    public IActionResult NewProject(Project project)
    {
      if (ModelState.IsValid)
      {
        repo.AddProject(project);
        return RedirectToAction("ManageProjects");
      }
      return View(project);
    }

    public IActionResult ShowEmployees()
    {
      var employees = repo.Employees.ToList();
      return View(employees);
    }

    [HttpGet]
    public IActionResult NewEmployee()
    {
      return View();
    }

    [HttpPost]
    public IActionResult NewEmployee(Employee employee)
    {
      if (ModelState.IsValid)
      {
        repo.AddEmployee(employee);
        return RedirectToAction("ShowEmployees");
      }

      return View(employee);
    }
    [HttpGet]
    public IActionResult EditProject(int id)
    {
      return View(repo.Projects.FirstOrDefault(p => p.ProjectID == id));
    }
    [HttpPost]
    public IActionResult EditProject(Project project)
    {
      repo.EditProject(project);
      return RedirectToAction("Home");
    }
    public IActionResult ProjectDetail(int id) 
    {
      return View(repo.Projects.FirstOrDefault(p => p.ProjectID == id));
    }
    public IActionResult EndProject(int id)
    {
      repo.EndProject(id);
      return RedirectToAction("ShowProjects");
    }
    public IActionResult DeleteProject(int id) 
    {
      repo.RemoveProject(id);
      return RedirectToAction("ShowProjects");
    }
  }
}
