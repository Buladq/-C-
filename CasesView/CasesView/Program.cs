using Microsoft.EntityFrameworkCore;
using CasesView.Models;    // ������������ ���� ������ ApplicationContext


var builder = WebApplication.CreateBuilder(args);


string connection = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();