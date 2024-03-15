using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CPRO2211_Assignment_3_Trips_Log_Application.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccommodationPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccommodationEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThingsToDo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingsToDo" },
                values: new object[,]
                {
                    { -2, "Evil DisneyLand Hotel", "Hotels@EvilDisneyLand.com", "636-418-7417", "Evil Disney Land", new DateTime(2024, 3, 31, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4626), new DateTime(2024, 3, 24, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4623), "[\"Ride the evil rides\",\"See the evil mascots\",\"Eat evil food\"]" },
                    { -1, "DisneyLand Hotel", "Hotels@DisneyLand.com", "714-781-4636", "Disney Land", new DateTime(2024, 3, 21, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4604), new DateTime(2024, 3, 14, 17, 52, 50, 658, DateTimeKind.Local).AddTicks(4554), "[\"Ride the rides\",\"See the mascots\",\"Eat food\"]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
