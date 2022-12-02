#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class TrackingNumberAddedToShipmentTrackingPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrackingNumber",
                table: "ShipmentsTrackingPath",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: string.Empty,
                comment: "Tracking number of the shipment.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "ShipmentsTrackingPath");
        }
    }
}
