using Microsoft.Extensions.DependencyInjection;
using UsersCrud.Data;
using UsersCrud.Interfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<IUserService,UserService>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapControllerRoute("default", "{controller=User}/{action=List}");

app.UseStaticFiles();

app.Run();
