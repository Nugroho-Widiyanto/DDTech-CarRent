using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Core.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plate = table.Column<string>(maxLength: 8, nullable: true),
                    Make = table.Column<string>(maxLength: 64, nullable: true),
                    Model = table.Column<string>(maxLength: 64, nullable: true),
                    Capacity = table.Column<byte>(nullable: false),
                    Year = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
