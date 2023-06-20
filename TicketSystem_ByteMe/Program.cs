
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
