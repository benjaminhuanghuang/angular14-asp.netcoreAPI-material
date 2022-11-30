

using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Services.Contract;
using Microsoft.EntityFrameworkCore;


namespace EmployeeAPI.Services.Implementation
{
    public class EmployeeService: IEmployeeService
    {
        private readonly DbEmployeeContext _dbContext;

        public EmployeeService(DbEmployeeContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<List<Employee>> GetList()
        {
            try
            {
                var employeeList = await this._dbContext.Employees.ToListAsync();
                return employeeList;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> Get(int id)
        {
            try
            {
                var employee = await this._dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         public async Task<Employee> Add(Employee model)
        {
            try
            {
                await this._dbContext.Employees.AddAsync(model);
                await _dbContext.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> Update(Employee model)
        {
            try
            {
                this._dbContext.Employees.Update(model);
                await _dbContext.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Employee model)
        {
            try
            {
                this._dbContext.Employees.Remove(model);
                await this._dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
