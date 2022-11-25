#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ShipmentVehicleInheritsIDeletableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ShipmentsVehicles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShipmentsVehicles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentsVehicles_IsDeleted",
                table: "ShipmentsVehicles",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShipmentsVehicles_IsDeleted",
                table: "ShipmentsVehicles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ShipmentsVehicles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShipmentsVehicles");
        }
    }
}
