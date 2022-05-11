using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FuelBase.Data.Migrations
{
    public partial class AddTransport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteNumber = table.Column<int>(type: "int", nullable: false),
                    TransportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoNowTon = table.Column<int>(type: "int", nullable: false),
                    CargoCapacityTon = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuelNowLitre = table.Column<int>(type: "int", nullable: false),
                    FuelCapacityLitre = table.Column<int>(type: "int", nullable: false),
                    GpsLatitudeNow = table.Column<double>(type: "float", nullable: false),
                    GpsLongitudeNow = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transport");
        }
    }
}
