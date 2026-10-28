using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo01EfCore.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeIdAsFkInsideDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentsTable_EmployeesTable_DeptId",
                schema: "Sales",
                table: "DepartmentsTable",
                column: "DeptId",
                principalTable: "EmployeesTable",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentsTable_EmployeesTable_DeptId",
                schema: "Sales",
                table: "DepartmentsTable");

            migrationBuilder.DropColumn(
                name: "DeptManagerId",
                schema: "Sales",
                table: "DepartmentsTable");
        }
    }
}
