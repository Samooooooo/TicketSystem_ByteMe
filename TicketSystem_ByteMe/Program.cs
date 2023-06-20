namespace TicketSystem_ByteMe
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);
      var app = builder.Build();
      builder.Services.AddControllersWithViews();

      app.UseRouting();

      app.UseStaticFiles();


      app.Run();
    }
  }
}