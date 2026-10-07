using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honda_Project.Migrations
{

    public partial class littleSeesChange : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "CRF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CarModels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "CRF450R");
        }
    }
}
