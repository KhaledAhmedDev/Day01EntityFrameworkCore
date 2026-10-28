using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo01EfCore.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeWorkInDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkingDepartmentDeptId",
                table: "EmployeesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTable_WorkingDepartmentDeptId",
                table: "EmployeesTable",
                column: "WorkingDepartmentDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_WorkingDepartmentDeptId",
                table: "EmployeesTable",
                column: "WorkingDepartmentDeptId",
                principalSchema: "Sales",
                principalTable: "DepartmentsTable",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_WorkingDepartmentDeptId",
                table: "EmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesTable_WorkingDepartmentDeptId",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "WorkingDepartmentDeptId",
                table: "EmployeesTable");
        }
    }
}
