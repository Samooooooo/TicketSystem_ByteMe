using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public IActionResult ShowEmployees()
    {
      var employees = repo.Employees.ToList();
      return View(employees);
    }
    public IActionResult ShowProjects()
    {
      return View(repo.Projects);
    }
    public IActionResult EmployeeDetail(int id)
    {
      return View(repo.Employees.FirstOrDefault(p => p.EmployeeID == id));
    }
    public IActionResult ProjectDetail(int id)
    {
      return View(repo.Projects.FirstOrDefault(p => p.ProjectID == id));
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
        return RedirectToAction("ShowProjects");
      }
      return View(project);
    }
    [HttpGet]
    public IActionResult EditEmployee(int id)
    {
      return View(repo.Employees.FirstOrDefault(p => p.EmployeeID == id));
    }
    [HttpPost]
    public IActionResult EditEmployee(Employee employee)
    {
      repo.EditEmployee(employee);
      return RedirectToAction("ShowEmployees");
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
      return RedirectToAction("ShowProjects");
    }
    public IActionResult DeleteEmployee(Employee employee)
    {
      repo.RemoveEmployee(employee);
      return RedirectToAction("ShowEmployees");
    }
    public IActionResult DeleteProject(Project project) 
    {
      repo.RemoveProject(project);
      return RedirectToAction("ShowProjects");
    }

    public IActionResult EndProject(int id)
    {
      repo.EndProject(id);
      return RedirectToAction("ShowProjects");
    }
  }
}
