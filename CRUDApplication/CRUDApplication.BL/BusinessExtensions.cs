using CRUDApplication.BL.Managers;
using Microsoft.Extensions.DependencyInjection;


namespace CRUDApplication.BL;
public static class BusinessExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    { 
         services.AddScoped<IEmployeeManager, EmployeeManager>();
    }
}
