using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    public partial class AddDeliveryWayEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryWay",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryWay",
                table: "Shipments");
        }
    }
}
