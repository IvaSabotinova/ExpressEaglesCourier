using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    public partial class IncreaseFeedbackContentMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Feedbacks",
                type: "nvarchar(max)",
                maxLength: 7000,
                nullable: false,
                comment: "Content of the feedback of a customer concerning particular shipment.",
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldComment: "Content of the feedback of a customer concerning particular shipment.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Feedbacks",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                comment: "Content of the feedback of a customer concerning particular shipment.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 7000,
                oldComment: "Content of the feedback of a customer concerning particular shipment.");
        }
    }
}
