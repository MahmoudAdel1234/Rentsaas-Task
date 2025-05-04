using CRUDApplication.DAL.Model;

namespace CRUDApplication.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> GetEmployeeByNameAsync(string name);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<Employee>> SearchEmployeeAsync(string name);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int pageSize);

    }
}
