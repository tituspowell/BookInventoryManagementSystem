using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookInventoryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRatingFieldsToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AverageRating",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfReviews",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPZrD+W10ZJLtc0NVOWJ6hiPEp8EDbeFfjS171WOsj6Uqtz01FdcmGsGnfTfDU+HSQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "librarianid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEEnyz6554/YdSK6V+GjO/JhDEEGKlDEFUHHYOPE6DTM6T0hA+884Z4kPPPvMrazB4g==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "readerid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMU3yOcP4AIooGEW9dY15jmSPStd3uFVawzHNUEbJf4Kx5wtiO/N31ujrXd1bKbhbw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumberOfReviews",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEOAMGavbJ6lYBdZAjEO/gq4e7EHeyj3ZvS9T2QSXxybftogdauZhTMQhjnEjsFl7bA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "librarianid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEF1KnK16cy5OUx8JKOFAKhGyQYEXeSJWXceI759Ap15Sy4MQLKKmQ0cQpvmrh0RkiQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "readerid",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEP6pk9RERUBOx98vMt4nbImG0KbqKRv33ydCPZeREeBS3pxGTKFvZtjMV3/l2GtxpA==");
        }
    }
}
