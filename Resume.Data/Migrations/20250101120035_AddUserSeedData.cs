using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "Email", "FirstName", "IsActive", "LastName", "Mobile", "Password" },
                values: new object[] { 1, new DateTime(2025, 1, 1, 15, 30, 34, 614, DateTimeKind.Local).AddTicks(47), "shamsisadr01@gmail.com", "شهریار", true, "شمسی صدر", "09367806232", "82-7C-CB-0E-EA-8A-70-6C-4C-34-A1-68-91-F8-4E-7B" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
