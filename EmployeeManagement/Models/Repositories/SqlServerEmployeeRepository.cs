using EmployeeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagement.Models.Repositories
{
    public class SqlServerEmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _dbContext;

        public SqlServerEmployeeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Employee Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if(employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
            return employee;
        }

        public Employee Get(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees;
        }

        public Employee Update(Employee updateEmployee)
        {
            var employee = _dbContext.Employees.Attach(updateEmployee);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return updateEmployee;
        }
    }
}
