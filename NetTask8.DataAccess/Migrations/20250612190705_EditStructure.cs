using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetTask8.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EditStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Files",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Approvals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_EmployeeId",
                table: "Approvals",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Employees_EmployeeId",
                table: "Approvals",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Employees_EmployeeId",
                table: "Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_EmployeeId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Approvals");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
