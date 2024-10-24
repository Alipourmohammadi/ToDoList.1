
using ToDoList.Applications.Interfaces;
using ToDoList.Applications.Services;
using Infrastructure;
namespace WebAPI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.ConfigureInfrastructure(builder.Configuration);

      builder.Services.AddControllers();

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
      builder.Services.AddScoped<IFilterService, FilterService>();
      builder.Services.AddScoped<IToDoService, ToDoService>();
      builder.Services.AddScoped<IExportService, ExportService>();
      var app = builder.Build();


      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();


      app.MapControllers();

      app.Run();
    }
  }
}
