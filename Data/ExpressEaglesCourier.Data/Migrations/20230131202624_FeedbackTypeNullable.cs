#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FeedbackTypeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FeedbackType",
                table: "Feedbacks",
                type: "int",
                nullable: true,
                comment: "A value indicating whether feedback is positive, negative, neutral or just recommendation.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "A value indicating whether feedback is positive, negative, neutral or just recommendation.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FeedbackType",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "A value indicating whether feedback is positive, negative, neutral or just recommendation.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "A value indicating whether feedback is positive, negative, neutral or just recommendation.");
        }
    }
}
