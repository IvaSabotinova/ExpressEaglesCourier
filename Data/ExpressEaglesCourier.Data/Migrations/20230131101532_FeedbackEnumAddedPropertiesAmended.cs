using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressEaglesCourier.Data.Migrations
{
    public partial class FeedbackEnumAddedPropertiesAmended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Customers_CustomerId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentId",
                table: "Feedbacks",
                type: "int",
                nullable: true,
                comment: "The id of the shipment that the feedback refers to.",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The id of the shipment that the feedback refers to.");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Feedbacks",
                type: "nvarchar(max)",
                maxLength: 7000,
                nullable: false,
                comment: "Content of the feedback of a customer or user.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 7000,
                oldComment: "Content of the feedback of a customer concerning particular shipment.");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty,
                comment: "The id of the ApplicationUser that provided feedback.");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Feedbacks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeedbackType",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "A value indicating whether feedback is positive, negative, neutral or just recommendation.");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_ApplicationUserId",
                table: "Feedbacks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_IsDeleted",
                table: "Feedbacks",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_IsDeleted",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "FeedbackType",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The id of the shipment that the feedback refers to.",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "The id of the shipment that the feedback refers to.");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Feedbacks",
                type: "nvarchar(max)",
                maxLength: 7000,
                nullable: false,
                comment: "Content of the feedback of a customer concerning particular shipment.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 7000,
                oldComment: "Content of the feedback of a customer or user.");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: true,
                comment: "The id of the customer that provided his/her feedback.");

            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "A value indicating whether customer's feedback is positive.");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_CustomerId",
                table: "Feedbacks",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Customers_CustomerId",
                table: "Feedbacks",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
