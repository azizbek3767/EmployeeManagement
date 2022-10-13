using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EmployeeManagement.Models.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees = null;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "AAA", LastName = "aaa", StartDateOfWork = DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture), Position = Positions.ManualQA, Company = "Company 1"},
                new Employee() { Id = 2, FirstName = "BBB", LastName = "bbb", StartDateOfWork = DateTime.ParseExact("18/03/2012", "dd/MM/yyyy", CultureInfo.InvariantCulture), Position = Positions.ProjectManager, Company = "Company 2"},
                new Employee() { Id = 3, FirstName = "CCC", LastName = "ccc", StartDateOfWork = DateTime.ParseExact("05/04/2007", "dd/MM/yyyy", CultureInfo.InvariantCulture), Position = Positions.SowtwareDeveloper, Company = "Company 3"},
                new Employee() { Id = 4, FirstName = "DDD", LastName = "ddd", StartDateOfWork = DateTime.ParseExact("22/07/2004", "dd/MM/yyyy", CultureInfo.InvariantCulture), Position = Positions.ManualQA, Company = "Company 4"},
            };
        }

        public Employee Create(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id.Equals(id));
            if(employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }

        public Employee Get(int id)
        {
            return _employees.FirstOrDefault(e => e.Id.Equals(id));
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee Update(Employee updatedEmployee)
        {
            var employee = _employees.FirstOrDefault(e => e.Id.Equals(updatedEmployee.Id));
            if(employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.StartDateOfWork = updatedEmployee.StartDateOfWork;
                employee.Position = updatedEmployee.Position;
                employee.Company = updatedEmployee.Company;
            }
            return employee;
        }
    }
}
