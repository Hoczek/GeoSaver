using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoSave.Migrations
{
    /// <inheritdoc />
    public partial class Initializedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geolocalizations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geolocalizations", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Geolocalizations");
        }
    }
}
