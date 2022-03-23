using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodDonationProject.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "200 Elizabeth St.", "Toronto General Hospital", "(416)340-3131" },
                    { 9, "1 Bridgepoint Dr.", "Bridgepoint Hospital", "(416)461-8252" },
                    { 8, "36 Grenville St.", "St Regis Hospital", "(647)491-0642" },
                    { 7, "555 University Ave.", "The Hospital for Sick Children", "(416)813-1500" },
                    { 6, "76 Grenville St.", "Women's College Hospital", "(416)323-6400" },
                    { 10, "610 University Ave.", "Princess Margaret Cancer Centre", "(416)946-2000" },
                    { 4, "600 University Ave.", "Mount Sinai Hospital", "(416)596-4200" },
                    { 3, "2075 Bayview Ave.", "Sunnybrook Health Sciences Centre", "(416)480-6100" },
                    { 2, "399 Bathurst St.", "Toronto Western Hospital", "(416)603-2591" },
                    { 5, "36 Queen St. E", "Saint Michael's Hospital", "(416)360-4000" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "address", "age", "firstName", "lastName", "phone", "sex" },
                values: new object[,]
                {
                    { 9, "15 Richard Place", 68, "Ariel", "Spencer", "(416)232-9525", "Female" },
                    { 1, "3578 Yonge St.", 34, "Toby", "Rau", "(647)872-3645", "Female" },
                    { 2, "30 Township Road", 79, "Christoper", "Cummings", "(647)758-2598", "Female" },
                    { 3, "5 Beaver Street", 56, "Lavelle", "Koch", "(647)836-0594", "Male" },
                    { 4, "12 Brooke Drive", 54, "Lorrie", "Kiehn", "(647)782-2351", "Female" },
                    { 5, "24 Rue Perreault", 71, "Helene", "Harvey", "(647)323-9547", "Male" },
                    { 6, "25 Rupert Street", 58, "Landon", "Krajcik", "(416)861-0795", "Male" },
                    { 7, "354 Highway", 34, "Brain", "Kirlin", "(416)743-3774", "Female" },
                    { 8, "51 Avenue", 60, "Nicolas", "Torp", "(647)773-3315", "Male" },
                    { 10, "30 Golburn Road", 22, "Justine", "Mraz", "(416)456-7356", "Female" }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "BloodType", "Date", "HospitalId", "Status", "UserId" },
                values: new object[,]
                {
                    { 6, "B+", "13-Mar-2022", 5, "Not Available", 1 },
                    { 1, "O-", "21-Mar-2022", 10, "Available", 2 },
                    { 7, "AB-", "22-Mar-2022", 4, "Available", 3 },
                    { 2, "O+", "15-Mar-2022", 9, "Not Available", 4 },
                    { 8, "AB+", "21-Mar-2022", 3, "Available", 5 },
                    { 3, "A-", "22-Mar-2022", 8, "Available", 6 },
                    { 9, "AB+", "19-Mar-2022", 2, "Available", 7 },
                    { 4, "A+", "15-Mar-2022", 7, "Not Available", 8 },
                    { 10, "O-", "15-Mar-2022", 1, "Not Available", 9 },
                    { 5, "B-", "15-Mar-2022", 6, "Not Available", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
