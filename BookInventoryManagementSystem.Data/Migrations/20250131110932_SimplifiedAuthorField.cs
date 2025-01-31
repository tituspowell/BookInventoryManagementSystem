using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookInventoryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SimplifiedAuthorField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBqWWjX4fMPP7QpczhH8JZzAvnWHPNnuhP8/WmBQnZk8RQwLbxb6o/40z4LEhcHY+Q==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEO/LujHEIhF9yzKjDHyJt+LZ+4eWl+8eZsGG7ZTNzHeS87L1FBqkiv5+XaTSiFjTFw==");
        }
    }
}
