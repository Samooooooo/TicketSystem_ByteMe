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
  }
}
