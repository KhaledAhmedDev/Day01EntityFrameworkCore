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
                name: "DeptId",
                table: "EmployeesTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesTable_DeptId",
                table: "EmployeesTable",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_DeptId",
                table: "EmployeesTable",
                column: "DeptId",
                principalSchema: "Sales",
                principalTable: "DepartmentsTable",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesTable_DepartmentsTable_DeptId",
                table: "EmployeesTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeesTable_DeptId",
                table: "EmployeesTable");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "EmployeesTable");
        }
    }
}
