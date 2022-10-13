using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Models.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new
                {
                    Id = 1,
                    FirstName = "AAA",
                    LastName = "aaa",
                    StartDateOfWork = DateTime.ParseExact("15/06/2015 13:45:00", "dd/MM/yyyy HH:mm:ss", null),
                    Position = Positions.SowtwareDeveloper,
                    Company = "Company 1"
                },
                new
                {
                    Id = 2,
                    FirstName = "BBB",
                    LastName = "bbb",
                    StartDateOfWork = DateTime.ParseExact("02/11/2007 12:40:00", "dd/MM/yyyy HH:mm:ss", null),
                    Position = Positions.ManualQA,
                    Company = "Company 2"
                },
                new
                {
                    Id = 3,
                    FirstName = "CCC",
                    LastName = "ccc",
                    StartDateOfWork = DateTime.ParseExact("18/07/2000 11:30:00", "dd/MM/yyyy HH:mm:ss", null),
                    Position = Positions.BusinessAnalyst,
                    Company = "Company 3"
                },
                new
                {
                    Id = 4,
                    FirstName = "DDD",
                    LastName = "ddd",
                    StartDateOfWork = DateTime.ParseExact("01/02/2021 17:00:00", "dd/MM/yyyy HH:mm:ss", null),
                    Position = Positions.SowtwareDeveloper,
                    Company = "Company 2"
                }
                );
            modelBuilder.Entity<Company>().HasData(
                new
                {
                    Id = 1,
                    Name = "Company 1",
                    TypeOfBusinessEntity = TypesOfBusinessEntity.LLC
                },
                new
                {
                    Id = 2,
                    Name = "Company 2",
                    TypeOfBusinessEntity = TypesOfBusinessEntity.JSC
                },
                new
                {
                    Id = 3,
                    Name = "Company 3",
                    TypeOfBusinessEntity = TypesOfBusinessEntity.LLC
                }
                );
        }
    }
}
