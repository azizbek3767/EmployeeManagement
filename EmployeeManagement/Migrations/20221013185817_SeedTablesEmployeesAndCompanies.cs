using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class SeedTablesEmployeesAndCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "TypeOfBusinessEntity" },
                values: new object[,]
                {
                    { 1, "Company 1", 0 },
                    { 2, "Company 2", 1 },
                    { 3, "Company 3", 0 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Company", "FirstName", "LastName", "Position", "StartDateOfWork" },
                values: new object[,]
                {
                    { 1, "Company 1", "AAA", "aaa", 0, new DateTime(2015, 6, 15, 13, 45, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Company 2", "BBB", "bbb", 1, new DateTime(2007, 11, 2, 12, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Company 3", "CCC", "ccc", 2, new DateTime(2000, 7, 18, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Company 2", "DDD", "ddd", 0, new DateTime(2021, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
