using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honda_Project.Migrations
{

    public partial class NewProductImg : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainImageUrl",
                value: "/Assets/CarProductImg/honda-civic-4d.jpg");

            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "MainImageUrl",
                value: "/Assets/CarProductImg/honda-civic-type-r-2021.jpg");

            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "MainImageUrl",
                value: "/Assets/CarProductImg/acura-TLX-Type-s.jpg");

            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "MainImageUrl",
                value: "/Assets/CarProductImg/honda-CRF450R-red.jpg");
        }

 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "MainImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "MainImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "MainImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "MainImageUrl",
                value: "");
        }
    }
}
