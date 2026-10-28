using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo01EfCore.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeAndDepartmentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "DepartmentsTable",
                schema: "Sales",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    DepartmentName = table.Column<string>(name: "Department Name", type: "varchar(50)", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsTable", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesTable",
                columns: table => new
                {
                    EmpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "10, 10"),
                    EmployeeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(10,3)", precision: 10, scale: 3, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTable", x => x.EmpId);
                    table.CheckConstraint("CheckAgeConstraint", "Age between 22 and 40");
                    table.CheckConstraint("EmailFormatConstraint", "Email like '%@%.%'");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentsTable",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "EmployeesTable");
        }
    }
}
