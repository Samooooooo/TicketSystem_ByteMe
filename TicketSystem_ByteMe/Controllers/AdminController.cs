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

    [HttpGet]
    public IActionResult ManageProjects()
    {
      return View(repo.Projects);
    }

    public IActionResult ShowEmployees()
    {
      var employees = repo.Employees.ToList();
      return View(employees);
    }

    [HttpGet]
    public IActionResult AddEmployee()
    {
      var jobtitle = Enum.GetValues(typeof(JobTitle)).Cast<JobTitle>().ToList();
      ViewBag.jobtitle = new SelectList(jobtitle, "jobtitle");

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
