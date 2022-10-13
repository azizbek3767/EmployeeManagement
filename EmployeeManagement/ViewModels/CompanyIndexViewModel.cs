using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class CompanyIndexViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
    }
}
