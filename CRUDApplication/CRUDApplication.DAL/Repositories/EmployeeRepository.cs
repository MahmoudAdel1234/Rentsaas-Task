using CRUDApplication.DAL.Context;
using CRUDApplication.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee =await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            if (employees == null)
            {
                throw new KeyNotFoundException("No employees found.");
            }
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            return employee;
        }

        public async Task<Employee> GetEmployeeByNameAsync(string name)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.FirstName == name || e.LastName == name);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with name {name} not found.");
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> SearchEmployeeAsync(string name)
        {
            return await _context.Employees
                                 .Where(e => e.FirstName.ToLower().Contains(name.ToLower()) || e.LastName.ToLower().Contains(name.ToLower()))
                                 .ToListAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
             _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int pageNumber, int pageSize)
        {
            return await _context.Employees
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
