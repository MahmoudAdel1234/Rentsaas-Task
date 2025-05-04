using CRUDApplication.DAL.Context;
using CRUDApplication.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CRUDApplication.DAL;
public static class DataAccessExtensions
{
    public static void AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));


        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
       
    }
}
