#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NewPropertiesToFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Feedbacks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: string.Empty,
                comment: "Title of the feedback of a customer or user.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Feedbacks");
        }
    }
}
