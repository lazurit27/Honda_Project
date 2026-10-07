using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 






namespace Honda_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "a18be9c0-aa65-4af8-bd17-00bd9344e575", "Admin", "ADMIN" },
                    { "b29cf0d1-bb76-5bf9-ce28-11ce0455f686", "b29cf0d1-bb76-5bf9-ce28-11ce0455f686", "Customer", "CUSTOMER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b29cf0d1-bb76-5bf9-ce28-11ce0455f686");
        }
    }
}
