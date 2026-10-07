using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 


namespace Honda_Project.Migrations
{

    public partial class SeedInitialData : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBodyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBodyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarEngineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: true),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEngineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarBrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    CarBodyTypeId = table.Column<int>(type: "int", nullable: false),
                    CarEngineTypeId = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<int>(type: "int", nullable: false),
                    Drive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarProducts_CarBodyTypes_CarBodyTypeId",
                        column: x => x.CarBodyTypeId,
                        principalTable: "CarBodyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarProducts_CarEngineTypes_CarEngineTypeId",
                        column: x => x.CarEngineTypeId,
                        principalTable: "CarEngineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarProducts_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CarBodyTypes",
                columns: new[] { "Id", "Description", "IconUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Classic 4-door body", "", "Sedan" },
                    { 2, "Compact 5-door body", "", "Hatchback" },
                    { 3, "Compact SUV", "", "Crossover" },
                    { 4, "Two-wheeled sports equipment", "", "Motorbike / Motocross" }
                });

            migrationBuilder.InsertData(
                table: "CarBrands",
                columns: new[] { "Id", "Description", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Precision Crafted Performance", "/Assets/Acura-motor-logo", "Acura" },
                    { 2, "Motorcycles and sports vechical Honda Powersports", "/Assets/Honda-motor-wing-logo", "Honda motocross" },
                    { 3, "The Power of Dreams", "/Assets/Honda-motor-base-logo", "Honda" }
                });

            migrationBuilder.InsertData(
                table: "CarEngineTypes",
                columns: new[] { "Id", "FuelType", "Horsepower", "Name", "Volume" },
                values: new object[,]
                {
                    { 1, 0, 140, "1.8 i-VTEC (R18A)", 1.8 },
                    { 2, 0, 315, "2.0 Turbo VTEC (K20C1)", 2.0 },
                    { 3, 2, 184, "2.0 e:HEV Hybrid", 2.0 },
                    { 4, 0, 55, "450cc Unicam 4-stroke", 0.45000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "CarBrandId", "Description", "ModelLogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, 3, "A light, maneuverable and compact car for the city", "", "Civic" },
                    { 2, 3, "Mid-size luxury sedan", "", "Accord" },
                    { 3, 3, "A popular family crossover that won't leave you in trouble.", "", "CR-V" },
                    { 4, 1, "Premium sports sedan", "", "TLX" },
                    { 5, 1, "Acura's flagship crossover", "", "MDX" },
                    { 6, 2, "Professional motocross bike", "", "CRF450R" }
                });

            migrationBuilder.InsertData(
                table: "CarProducts",
                columns: new[] { "Id", "CarBodyTypeId", "CarEngineTypeId", "CarModelId", "Color", "Description", "Drive", "IsAvailable", "MainImageUrl", "Price", "Title", "Transmission", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, "Черный", "Надежный седан 8-го поколения", 0, true, "", 14500m, "Honda Civic 1.8 i-VTEC 4D", 0, 2008 },
                    { 2, 2, 2, 1, "Championship White", "Заряженный хэтчбек с турбомотором", 0, true, "", 41000m, "Honda Civic Type R FK8", 0, 2021 },
                    { 3, 1, 2, 4, "Apex Blue", "Мощный полноприводный седан", 2, true, "", 49000m, "Acura TLX Type S", 1, 2023 },
                    { 4, 4, 4, 6, "Extreme Red", "Спортивный байк для трека и заездов", 1, true, "", 9800m, "Honda CRF450R Motocross", 0, 2024 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_CarBodyTypeId",
                table: "CarProducts",
                column: "CarBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_CarEngineTypeId",
                table: "CarProducts",
                column: "CarEngineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CarProducts_CarModelId",
                table: "CarProducts",
                column: "CarModelId");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarProducts");

            migrationBuilder.DropTable(
                name: "CarBodyTypes");

            migrationBuilder.DropTable(
                name: "CarEngineTypes");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarBrands");
        }
    }
}
