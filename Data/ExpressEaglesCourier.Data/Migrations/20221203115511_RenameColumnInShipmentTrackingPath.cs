#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameColumnInShipmentTrackingPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickedUpFromCustomer",
                table: "ShipmentsTrackingPath");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptanceFromCustomer",
                table: "ShipmentsTrackingPath",
                type: "datetime2",
                nullable: true,
                comment: "Date and time of accepting the shipment from customer.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptanceFromCustomer",
                table: "ShipmentsTrackingPath");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickedUpFromCustomer",
                table: "ShipmentsTrackingPath",
                type: "datetime2",
                nullable: true,
                comment: "Date and time of picking up shipment from customer.");
        }
    }
}
