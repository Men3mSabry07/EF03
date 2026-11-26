using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF03.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, "omar@gmail.com", "Omar Ali", new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01098765432" },
                    { 3, "men3m@gmail.com", "Abdelmenem Sabry Abdelaty", new DateTime(2005, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "01141562494" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "ManagerId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "BR01", "Assiut, Egypt", 3, "Assiut Branch", "01028841318" },
                    { "BR02", "Cairo, Egypt", 2, "Cairo Branch", "01141562494" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "BR01");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "BR02");

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
