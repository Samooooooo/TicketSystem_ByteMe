using TicketSystem_ByteMe;
using Microsoft.AspNetCore.Mvc;

namespace TicketSystem_ByteMe.Home
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
