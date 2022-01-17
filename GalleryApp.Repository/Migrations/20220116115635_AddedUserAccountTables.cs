using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GalleryApp.Repository.Migrations
{
    public partial class AddedUserAccountTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizerId",
                table: "Exhibitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartingDate",
                table: "Exhibitions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exhibitions_OrganizerId",
                table: "Exhibitions",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibitions_Accounts_OrganizerId",
                table: "Exhibitions",
                column: "OrganizerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exhibitions_Accounts_OrganizerId",
                table: "Exhibitions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Exhibitions_OrganizerId",
                table: "Exhibitions");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "Exhibitions");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "Exhibitions");
        }
    }
}
