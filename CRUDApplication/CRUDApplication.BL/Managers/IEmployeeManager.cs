using CRUDApplication.BL.DTOs;

namespace CRUDApplication.BL.Managers
{
    public interface IEmployeeManager
    {
        Task<IEnumerable<EmployeeReadDTO>> GetAllEmployeesAsync();
        Task<EmployeeReadDTO> GetEmployeeByIdAsync(int id);
        Task<EmployeeReadDTO> GetEmployeeByNameAsync(string name);
        Task AddEmployeeAsync(EmployeeWriteDTO employeeDto);
        Task UpdateEmployeeAsync(int id,EmployeeWriteDTO employeeDto);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<EmployeeReadDTO>> SearchEmployeeAsync(string name);
        Task<IEnumerable<EmployeeReadDTO>> GetEmployeesAsync(int pageNumber, int pageSize);
    }
}
