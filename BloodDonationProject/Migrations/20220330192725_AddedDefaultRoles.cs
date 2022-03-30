using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonationProject.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e49b3c0-eff2-4147-8507-4912c38cb4de", "2584f26b-54ab-4be6-8323-7523d8c2d115", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6008a39-63b9-4d4e-b314-70aeff910ce1", "74212b04-d6ce-427b-8840-89a18ad09b64", "admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e49b3c0-eff2-4147-8507-4912c38cb4de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6008a39-63b9-4d4e-b314-70aeff910ce1");
        }
    }
}
