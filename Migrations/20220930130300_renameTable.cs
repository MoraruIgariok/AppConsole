using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepozitApp.Migrations
{
    public partial class renameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Owner = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Import = table.Column<bool>(type: "bit", nullable: true),
                    Export = table.Column<bool>(type: "bit", nullable: true),
                    Command_Id = table.Column<int>(type: "int", nullable: true),
                    Count_Produs = table.Column<int>(type: "int", nullable: true),
                    DataChange = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Command__Command__276EDEB3",
                        column: x => x.Command_Id,
                        principalTable: "Produs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Command_Command_Id",
                table: "Command",
                column: "Command_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Command");

            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
