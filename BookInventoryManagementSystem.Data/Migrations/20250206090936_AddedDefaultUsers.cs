using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookInventoryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECG3++ZL98mfx3d5te6u5DQkjwM5hj5CNKdRRzcZfR/wq8RHu4VcicmiMslz/v/U8g==");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "librarianid", 0, "stamp-admin-user", "lib@localhost.com", true, "Sally", "Sotherby", false, null, "LIB@LOCALHOST.COM", "LIB@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEMD8SQ5DCO4rK8Ns5Lp9XwGplOWcXn5sGVXbjSpXSP1zgbjKmN4Kwy02iehDZ4Sxg==", null, false, "SECURITYSTAMP", false, "lib@localhost.com" },
                    { "readerid", 0, "stamp-admin-user", "reader@localhost.com", true, "Roger", "Rabbit", false, null, "READER@LOCALHOST.COM", "READER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEEgCbW0FOM+F3IaydE12XR+2CkfnFIwAXOp/uGFTvalh59ojNnTy2Ln4KPPGwii0gw==", null, false, "SECURITYSTAMP", false, "reader@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "233e1017-9c65-4690-bf48-546434d3b93e", "librarianid" },
                    { "3db65512-a1a9-4087-986f-a2e9360b2f47", "readerid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233e1017-9c65-4690-bf48-546434d3b93e", "librarianid" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3db65512-a1a9-4087-986f-a2e9360b2f47", "readerid" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "librarianid");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "readerid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMV0hDwZrGEFzezeRyaQsNoXW7avKX/OVEYc1pO3bL3RMeijo6RkVyygBf/ycDipbQ==");
        }
    }
}
