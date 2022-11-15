#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MakeCountryFieldsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickUpCountry",
                table: "Shipments",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationCountry",
                table: "Shipments",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickUpCountry",
                table: "Shipments",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56);

            migrationBuilder.AlterColumn<string>(
                name: "DestinationCountry",
                table: "Shipments",
                type: "nvarchar(56)",
                maxLength: 56,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(56)",
                oldMaxLength: 56);
        }
    }
}
