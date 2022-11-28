#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveRequiredOnVehicleEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true,
                comment: "The employee assigned with the vehicle.",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The employee assigned with the vehicle.");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Employees",
                type: "int",
                nullable: true,
                comment: "The vehicle used by the employee courier.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The vehicle used by the employee courier.");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Employees",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                comment: "Home Country",
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldComment: "Home country");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                comment: "Home City",
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28,
                oldComment: "Home city");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                comment: "Home Address",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldComment: "Home address");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                comment: "Home Country",
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldComment: "Home country");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                comment: "Home City",
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28,
                oldComment: "Home city");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                comment: "Home Address",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldComment: "Home address");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty,
                comment: "The employee assigned with the vehicle.",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "The employee assigned with the vehicle.");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The vehicle used by the employee courier.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "The vehicle used by the employee courier.");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Employees",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                comment: "Home country",
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldComment: "Home Country");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Employees",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                comment: "Home city",
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28,
                oldComment: "Home City");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Employees",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                comment: "Home address",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldComment: "Home Address");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                comment: "Home country",
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldComment: "Home Country");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                comment: "Home city",
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28,
                oldComment: "Home City");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Customers",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                comment: "Home address",
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldComment: "Home Address");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Employees_EmployeeId",
                table: "Vehicles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
