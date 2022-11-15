#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CountryAddedToShipmentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationCountry",
                table: "Shipments",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickUpCountry",
                table: "Shipments",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationCountry",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "PickUpCountry",
                table: "Shipments");
        }
    }
}
