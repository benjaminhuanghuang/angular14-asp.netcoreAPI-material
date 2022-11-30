

using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Services.Implementation
{

    public class DepartmentService : IDepartmentService
    {

        private readonly DbEmployeeContext _dbContext;
        
        public DepartmentService(DbEmployeeContext dbContext)
        {
            this._dbContext = dbContext;
        }

       public async Task<List<Department>> GetList()
        {
            try
            {
                var departmentList = await this._dbContext.Departments.ToListAsync();
                return departmentList;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
