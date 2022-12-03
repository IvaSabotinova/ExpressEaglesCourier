#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddSendingAndReceivingOfficesIdsToShipmentTrackingPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceivingOfficeId",
                table: "ShipmentsTrackingPath",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SendingOfficeId",
                table: "ShipmentsTrackingPath",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivingOfficeId",
                table: "ShipmentsTrackingPath");

            migrationBuilder.DropColumn(
                name: "SendingOfficeId",
                table: "ShipmentsTrackingPath");
        }
    }
}
