using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    public partial class AddPropertyPickedUpFromCustomerToShipmentTrackingPathEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PickedUpByCourier",
                table: "ShipmentsTrackingPath",
                type: "datetime2",
                nullable: true,
                comment: "Date and time of picking up shipment by courier.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time of picking up shipment from customer.");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickedUpFromCustomer",
                table: "ShipmentsTrackingPath",
                type: "datetime2",
                nullable: true,
                comment: "Date and time of picking up shipment from customer.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickedUpFromCustomer",
                table: "ShipmentsTrackingPath");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PickedUpByCourier",
                table: "ShipmentsTrackingPath",
                type: "datetime2",
                nullable: true,
                comment: "Date and time of picking up shipment from customer.",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldComment: "Date and time of picking up shipment by courier.");
        }
    }
}
