#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EmployeeShipmentInheritsIDeletableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "EmployeesShipments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeesShipments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesShipments_IsDeleted",
                table: "EmployeesShipments",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeesShipments_IsDeleted",
                table: "EmployeesShipments");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "EmployeesShipments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeesShipments");
        }
    }
}
