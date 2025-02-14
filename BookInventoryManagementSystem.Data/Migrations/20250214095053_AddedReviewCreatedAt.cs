using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookInventoryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedReviewCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELcHdWvpVpCf7ec6dlHKoMNwQYQ2Zn3eAh5mOh3CFV+avKuhu3expBb4R0NvePY97A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "librarianid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPGPOIXVCYbE//ySFhZi1Bgt9ItxXmYyXUte+a9FI6gePg2er/fun7/fmHwiOEEc3A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "readerid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBquieTsqJZFqX9gkG/MY7hMptf5IUGLKGhoXB9CMOqXfpPtGZwJKm4iX1qgM0gDZg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEJpJuhZ8Nx26/XiihjzhNxDfKHG963sbDlQ1IUdvKiLv4GI86g7QtGIF+VljK3hGnw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "librarianid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEG56+go6Y18Sx3ZXR3CrdNbROH0mCAVX6MfkxlpkNey7ZYekckl9y4wfTHPGNuc3Lw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "readerid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEB3DhAk1YhWad74a6Zr0GOKwvMDclnxsC2l0659PNV9A1fZPd9Yt3Hu+UyyVgqH//A==");
        }
    }
}
