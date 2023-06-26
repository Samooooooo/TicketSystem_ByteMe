using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

    public IActionResult ManageProjects()
    {
      var projeckts = repo.Projects.ToList();
      return View(repo.Projects);
    }

    [HttpGet]
    public IActionResult AddProject()
    {
      return View();
    }
    [HttpPost]
    public IActionResult AddProject(Project project)
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
    public IActionResult AddEmployee()
    {
      return View();
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee employee)
    {
      if (ModelState.IsValid)
      {
        repo.AddEmployee(employee);
        return RedirectToAction("ShowEmployees");
      }

      return View(employee);
    }
  }
}
