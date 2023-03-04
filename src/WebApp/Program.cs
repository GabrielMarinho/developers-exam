using Domain.IoC;
using Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.InfrastructureRegister(builder.Configuration);
services.DomainRegister(builder.Configuration);

services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();