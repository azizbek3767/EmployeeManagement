using EmployeeManagement.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.DataAccess
{
    public class DataAccessADO : IDataAccessADO
    {
        private IConfiguration _configuration;

        public string ConStr { get; set; }

        public SqlConnection con;
        public DataAccessADO(IConfiguration configuration)
        {
            _configuration = configuration;
            ConStr = _configuration.GetConnectionString("EmployeeManagementDB");
        }
        public List<Employee> GetEmployeesRecord()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (con = new SqlConnection(ConStr)) ;
                con.Open();
                var cmd = new SqlCommand("SP_GetEmployeesRecord", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(rdr["Id"]);
                    emp.FirstName = rdr["FirstName"].ToString();
                    emp.LastName = rdr["LastName"].ToString();

                    employees.Add(emp);
                }
                return employees.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public interface IDataAccessADO{
        public List<Employee> GetEmployeesRecord();
    }
}
