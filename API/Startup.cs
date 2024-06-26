using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
   public class Startup {
  private readonly IConfiguration _iconfig;


public Startup(IConfiguration configuration){
    
    _iconfig=configuration;
}
    public void ConfigureServices(IServiceCollection services) {
        services.AddRazorPages();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContextFactory<DataContext>(Options =>{
      
        Options.UseSqlite(_iconfig.GetConnectionString("DefaultConnection"));
           
         });
      services.AddCors();
    }
    public void Configure(WebApplication app, IWebHostEnvironment env) {

        if (app.Environment.IsDevelopment())
           {
              app.MapControllers();
              app.UseSwagger();
              app.UseSwaggerUI();
}           
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        // app.UseHttpsRedirection();
        // app.UseStaticFiles();

        app.UseRouting();
        
        app.UseAuthorization();

        // app.MapRazorPages();
        // app.Run();
        app.UseHttpsRedirection();
        a

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


    }
}
}
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}