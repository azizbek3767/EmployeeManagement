using EmployeeManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagement.Models.Repositories
{
    public class SqlServerCompanyRepository : ICompayRepository
    {
        private AppDbContext _dbContext;

        public SqlServerCompanyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Company Create(Company company)
        {
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
            return company;
        }

        public Company Delete(int id)
        {
            var company = _dbContext.Companies.Find(id);
            if(company != null)
            {
                _dbContext.Remove(company);
                _dbContext.SaveChanges();
            }
            return company;
        }

        public Company Get(int id)
        {
            return _dbContext.Companies.Find(id);
        }

        public IEnumerable<Company> GetAll()
        {
            return _dbContext.Companies;
        }

        public Company Update(Company updateCompany)
        {
            var company = _dbContext.Companies.Attach(updateCompany);
            company.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
            return updateCompany;
        }
    }
}
