using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAboutMeTableSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "Id", "Bio", "BirthDate", "CreateDate", "Email", "FirstName", "LastName", "Location", "Mobile", "Position" },
                values: new object[] { 1, "Hi", new DateOnly(2025, 1, 6), new DateTime(2025, 1, 6, 17, 9, 4, 363, DateTimeKind.Local).AddTicks(1852), "shamsisadr01@gmail.com", "شهریار", "شمسی صدر", "خرم آباد", "09367806232", "مدیر" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 6, 17, 9, 4, 361, DateTimeKind.Local).AddTicks(4540));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 1, 6, 17, 1, 54, 486, DateTimeKind.Local).AddTicks(9877));
        }
    }
}
