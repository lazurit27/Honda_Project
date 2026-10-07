using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honda_Project.Migrations
{

    public partial class newBodyTypeInitialData : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconUrl",
                value: "/Assets/BodyTypes/Sedan.jpg");

            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconUrl",
                value: "/Assets/BodyTypes/Hatchback.jpg");

            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconUrl",
                value: "/Assets/BodyTypes/Crossover.jpg");

            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IconUrl",
                value: "/Assets/BodyTypes/Motocross.jpg");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "IconUrl",
                value: "");
        }
    }
}
