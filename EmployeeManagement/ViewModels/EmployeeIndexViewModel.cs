using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeIndexViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
