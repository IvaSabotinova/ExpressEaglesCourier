using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    public partial class FluentApiMappingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesShipments_Employees_EmployeeId",
                table: "EmployeesShipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesShipments_Shipments_ShipmentId",
                table: "EmployeesShipments");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsVehicles_Shipments_ShipmentId",
                table: "ShipmentsVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsVehicles_Vehicles_VehicleId",
                table: "ShipmentsVehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesShipments_Employees_EmployeeId",
                table: "EmployeesShipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesShipments_Shipments_ShipmentId",
                table: "EmployeesShipments",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsVehicles_Shipments_ShipmentId",
                table: "ShipmentsVehicles",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsVehicles_Vehicles_VehicleId",
                table: "ShipmentsVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesShipments_Employees_EmployeeId",
                table: "EmployeesShipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesShipments_Shipments_ShipmentId",
                table: "EmployeesShipments");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsVehicles_Shipments_ShipmentId",
                table: "ShipmentsVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentsVehicles_Vehicles_VehicleId",
                table: "ShipmentsVehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesShipments_Employees_EmployeeId",
                table: "EmployeesShipments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesShipments_Shipments_ShipmentId",
                table: "EmployeesShipments",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsVehicles_Shipments_ShipmentId",
                table: "ShipmentsVehicles",
                column: "ShipmentId",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentsVehicles_Vehicles_VehicleId",
                table: "ShipmentsVehicles",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
