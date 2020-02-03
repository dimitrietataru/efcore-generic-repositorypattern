using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EFCore.RepositoryPattern.Sample.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DealerId = table.Column<Guid>(nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 100, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 4001, nullable: true),
                    VinNumber = table.Column<string>(maxLength: 17, nullable: false),
                    BodyType = table.Column<int>(nullable: false, defaultValue: 0),
                    FuelType = table.Column<int>(nullable: false, defaultValue: 3),
                    ProductionDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VinNumber",
                table: "Cars",
                column: "VinNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
