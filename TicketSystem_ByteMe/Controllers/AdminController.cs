using TicketSystem_ByteMe;
using Microsoft.AspNetCore.Mvc;

namespace TicketSystem_ByteMe.Home
{
  public class AdminController : Controller
  {
    public IActionResult Home()
    {
      return View();
    }

    public IActionResult ManageProjects()
    {
      return View();
    }
    public IActionResult ShowEmployees()
    {
      return View();
    }
  }
}
