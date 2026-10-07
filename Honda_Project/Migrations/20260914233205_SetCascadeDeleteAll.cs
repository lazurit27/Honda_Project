using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Honda_Project.Migrations
{
    
    
    
    
    
    
    
 
    public partial class SetCascadeDeleteAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarProducts_CarBodyTypes_CarBodyTypeId",
                table: "CarProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarProducts_CarEngineTypes_CarEngineTypeId",
                table: "CarProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarProducts_CarModels_CarModelId",
                table: "CarProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CarProducts_CarBodyTypes_CarBodyTypeId",
                table: "CarProducts",
                column: "CarBodyTypeId",
                principalTable: "CarBodyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarProducts_CarEngineTypes_CarEngineTypeId",
                table: "CarProducts",
                column: "CarEngineTypeId",
                principalTable: "CarEngineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarProducts_CarModels_CarModelId",
                table: "CarProducts",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarProducts_CarBodyTypes_CarBodyTypeId",
                table: "CarProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarProducts_CarEngineTypes_CarEngineTypeId",
                table: "CarProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarProducts_CarModels_CarModelId",
                table: "CarProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CarProducts_CarBodyTypes_CarBodyTypeId",
                table: "CarProducts",
                column: "CarBodyTypeId",
                principalTable: "CarBodyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarProducts_CarEngineTypes_CarEngineTypeId",
                table: "CarProducts",
                column: "CarEngineTypeId",
                principalTable: "CarEngineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarProducts_CarModels_CarModelId",
                table: "CarProducts",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
