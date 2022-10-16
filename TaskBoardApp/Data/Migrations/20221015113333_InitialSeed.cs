using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7c8b019d-fce0-4829-9829-bb46bf32800d", 0, "22b091ae-326a-4c30-8574-10c92b2dce38", "guest@mail.com", false, "Guest", "User", false, null, "GUEST@MAIL.COM", "GUEST", "AQAAAAEAACcQAAAAEKRfI0rTRphS8QyQYOrLcFJSa5jK3crWht6iEDjC3S+2VNPtLDIuFPTx+Nsf7vy1oA==", null, false, "0544d499-7d7c-4332-b938-5c8d11091d3f", false, "guest" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 9, 15, 13, 33, 32, 849, DateTimeKind.Local).AddTicks(523), "Learn using ASP.NET Core Identity", "7c8b019d-fce0-4829-9829-bb46bf32800d", "Prepare for ASP.Net Fundamentals exam" },
                    { 2, 3, new DateTime(2022, 5, 15, 13, 33, 32, 849, DateTimeKind.Local).AddTicks(541), "Learn using EF Core and MS SQL Server Management Studio", "7c8b019d-fce0-4829-9829-bb46bf32800d", "Improve EF Core skills" },
                    { 3, 2, new DateTime(2021, 12, 15, 13, 33, 32, 849, DateTimeKind.Local).AddTicks(543), "Learn using ASP.NET Core Identity", "7c8b019d-fce0-4829-9829-bb46bf32800d", "Improve ASP.NET Core skills" },
                    { 4, 3, new DateTime(2022, 9, 15, 13, 33, 32, 849, DateTimeKind.Local).AddTicks(622), "Prepare by solving old Mid and Final exams", "7c8b019d-fce0-4829-9829-bb46bf32800d", "Prepare for C# Fundamentals exam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8b019d-fce0-4829-9829-bb46bf32800d");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
