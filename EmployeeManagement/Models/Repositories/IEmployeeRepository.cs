using System.Collections.Generic;

namespace EmployeeManagement.Models.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Get(int id);
        IEnumerable<Employee> GetAll();
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
    }
}
