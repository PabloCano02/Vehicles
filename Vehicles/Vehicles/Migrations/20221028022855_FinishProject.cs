using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicles.Migrations
{
    public partial class FinishProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Histories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserId",
                table: "Histories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DocumentTypeId",
                table: "AspNetUsers",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                table: "AspNetUsers",
                column: "DocumentTypeId",
                principalTable: "DocumentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_AspNetUsers_UserId",
                table: "Histories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DocumentTypes_DocumentTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_AspNetUsers_UserId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_UserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Histories_UserId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DocumentTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
