using Practical_20.Interfaces;
using Practical_20.Models;
using Practical_20.Repository;
using Practical_20.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Practical_20.GlobalExceptions;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.



LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
Log.Logger = loggerConfiguration.MinimumLevel.Override("Microsoft", LogEventLevel.Information).Enrich.FromLogContext().WriteTo.Console().CreateLogger();






builder.Services.AddControllersWithViews();
var services = builder.Services;
services.AddMvc();
services.AddDbContext<ApplicationDBContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDBCS")));



services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddTransient<IStudentService, StudentService>();
var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseMiddleware (typeof(ExceptionHandlingMiddleware));
app.UseHttpsRedirection();
app.UseStaticFiles();



app.UseRouting();



app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=GetAllStudents}/{id?}");



app.Run();