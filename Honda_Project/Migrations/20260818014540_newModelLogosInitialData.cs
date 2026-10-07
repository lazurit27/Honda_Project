using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honda_Project.Migrations
{

    public partial class newModelLogosInitialData : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelLogoUrl",
                value: "/Assets/ModelLogos/Civic.jpg");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelLogoUrl",
                value: "/Assets/ModelLogos/Accord.jpg");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelLogoUrl",
                value: "/Assets/ModelLogos/CR-V.jpg");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModelLogoUrl",
                value: "/Assets/ModelLogos/TLX.jpg");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "ModelLogoUrl",
                value: "/Assets/ModelLogos/MDX.jpg");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "ModelLogoUrl",
                value: "/Assets/ModelLogos/CRF.jpg");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModelLogoUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModelLogoUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModelLogoUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModelLogoUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 5,
                column: "ModelLogoUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "ModelLogoUrl",
                value: "");
        }
    }
}
