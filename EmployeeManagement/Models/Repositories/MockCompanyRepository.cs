using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Models.Repositories
{
    public class MockCompanyRepository : ICompayRepository
    {
        private List<Company> _companies = null;
        public MockCompanyRepository()
        {
            _companies = new List<Company>()
            {
                new Company() {Id=1, Name="Company 1", TypeOfBusinessEntity=TypesOfBusinessEntity.LLC},
                new Company() {Id=2, Name="Company 2", TypeOfBusinessEntity=TypesOfBusinessEntity.JSC},
                new Company() {Id=3, Name="Company 3", TypeOfBusinessEntity=TypesOfBusinessEntity.LLC},
            };
        }

        public Company Create(Company company)
        {
            company.Id = _companies.Max(c => c.Id) + 1;
            _companies.Add(company);
            return company;
        }

        public Company Delete(int id)
        {
            var company = _companies.FirstOrDefault(c => c.Id.Equals(id));
            if(company != null)
            {
                _companies.Remove(company);
            }
            return company;
        }

        public Company Get(int id)
        {
            return _companies.FirstOrDefault(c => c.Id.Equals(id));
        }

        public IEnumerable<Company> GetAll()
        {
            return _companies;
        }

        public Company Update(Company updatedCompany)
        {
            var company = _companies.FirstOrDefault(c => c.Id.Equals(updatedCompany.Id));
            if(company != null)
            {
                company.Name = updatedCompany.Name;
                company.TypeOfBusinessEntity = updatedCompany.TypeOfBusinessEntity;
            }
            return company;
        }
    }
}
