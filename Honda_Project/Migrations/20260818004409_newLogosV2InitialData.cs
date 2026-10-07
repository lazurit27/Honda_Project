using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honda_Project.Migrations
{

    public partial class newLogosV2InitialData : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "/Assets/Logos/Acura-motor-logo.jpg");

            migrationBuilder.UpdateData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "/Assets/Logos/Honda-motor-wing-logo.jpg");

            migrationBuilder.UpdateData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoUrl",
                value: "/Assets/Logos/Honda-motor-base-logo.jpg");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 1,
                column: "LogoUrl",
                value: "/Assets/Logos/Acura-motor-logo");

            migrationBuilder.UpdateData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 2,
                column: "LogoUrl",
                value: "/Assets/Logos/Honda-motor-wing-logo");

            migrationBuilder.UpdateData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 3,
                column: "LogoUrl",
                value: "/Assets/Logos/Honda-motor-base-logo");
        }
    }
}
