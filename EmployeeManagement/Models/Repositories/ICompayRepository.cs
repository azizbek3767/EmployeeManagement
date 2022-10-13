using System.Collections.Generic;

namespace EmployeeManagement.Models.Repositories
{
    public interface ICompayRepository
    {
        Company Get(int id);
        IEnumerable<Company> GetAll();
        Company Create(Company company);
        Company Update(Company company);
        Company Delete(int id);
    }
}
