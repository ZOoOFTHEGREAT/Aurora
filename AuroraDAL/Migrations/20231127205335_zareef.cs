using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AuroraDAL.Migrations
{
    /// <inheritdoc />
    public partial class zareef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Clothes such as jeans, coats and etc...", "Fashion" },
                    { 2, "Drugs such as makeup, perfumes and etc...", "Health & Beauty" },
                    { 3, "Devices such as Phones, Laptops and etc...", "Electronics" }
                });

            migrationBuilder.InsertData(
                table: "ShippingCompanies",
                columns: new[] { "Id", "Name", "ServicePrice", "Telephone", "WebSite" },
                values: new object[,]
                {
                    { 1, "DHL", 400, "+202 25943200", "https://www.dhl.com/eg-en/home.html?locale=true" },
                    { 2, "FedEx", 500, "012 07575333", "https://www.fedex.com/en-us/home.html" },
                    { 3, "UPS", 600, "+202 24141456", "https://www.ups.com/sa/ar/Home.page" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingCompanies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingCompanies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingCompanies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
