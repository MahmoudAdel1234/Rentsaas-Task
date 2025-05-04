using CRUDApplication.BL.DTOs;
using CRUDApplication.DAL.Model;
using CRUDApplication.DAL.Repositories;

namespace CRUDApplication.BL.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task AddEmployeeAsync(EmployeeWriteDTO employeeDto)
        {
            if (employeeDto == null)
            {
                throw new ArgumentNullException(nameof(employeeDto));
            }
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Position = employeeDto.Position
            };
            await _employeeRepository.AddEmployeeAsync(employee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<IEnumerable<EmployeeReadDTO>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            if (employees == null)
            {
                throw new KeyNotFoundException("No employees found.");
            }
            return employees.Select(e => new EmployeeReadDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Position = e.Position
            });
        }

        public async Task<EmployeeReadDTO> GetEmployeeByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero.");
            }
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with ID {id} not found.");
            }
            return new EmployeeReadDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Position = employee.Position
            };
        }

        public async Task<EmployeeReadDTO> GetEmployeeByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
            }
            var employee = await _employeeRepository.GetEmployeeByNameAsync(name);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with name {name} not found.");
            }
            return new EmployeeReadDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Position = employee.Position
            };
        }

        public async Task<IEnumerable<EmployeeReadDTO>> SearchEmployeeAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
            }
            var employees = await _employeeRepository.SearchEmployeeAsync(name);
            if (employees == null)
            {
                throw new KeyNotFoundException($"No employees found with name {name}.");
            }
            return employees.Select(e => new EmployeeReadDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Position = e.Position
            });
        }

        public async Task UpdateEmployeeAsync(int id,EmployeeWriteDTO employeeDto)
        {
            if (employeeDto == null)
            {
                throw new ArgumentNullException(nameof(employeeDto));
            }
            var employee = new Employee
            {
                Id = id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Position = employeeDto.Position
            };
            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task<IEnumerable<EmployeeReadDTO>> GetEmployeesAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be greater than zero.");
            }
            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be greater than zero.");
            }
            var employees = await _employeeRepository.GetEmployeesAsync(pageNumber, pageSize);
            if (employees == null)
            {
                throw new KeyNotFoundException("No employees found.");
            }
            return employees.Select(e => new EmployeeReadDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Position = e.Position
            });

        }

    }
}
