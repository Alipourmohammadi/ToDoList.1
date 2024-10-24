using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Repository;
using Infrastructure.Dat;

namespace Infrastructure
{
    public static class InfrastructureServiceRegistration
  {
    public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

      services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

      services.AddScoped<IToDoRepository, ToDoRepository>();

      return services;
    }
  }
}
