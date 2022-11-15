#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RequiredFieldsToShipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress",
                table: "Shipments",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PickUpTown",
                table: "Shipments",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationTown",
                table: "Shipments",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationAddress",
                table: "Shipments",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress",
                table: "Shipments",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "PickUpTown",
                table: "Shipments",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationTown",
                table: "Shipments",
                type: "nvarchar(28)",
                maxLength: 28,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(28)",
                oldMaxLength: 28);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationAddress",
                table: "Shipments",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);
        }
    }
}
