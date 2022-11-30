

using EmployeeAPI.Models;

namespace EmployeeAPI.Services.Contract
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetList();
    }
}
