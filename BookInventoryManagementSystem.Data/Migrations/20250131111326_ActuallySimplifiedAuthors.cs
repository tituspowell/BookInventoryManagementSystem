using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookInventoryManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ActuallySimplifiedAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Authors",
                table: "Book",
                newName: "Author");

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBtadabOAAjpv9J6eIJCKswx9NyhK7iF4BGbM/0wb3dff0ZtCVd787Y6Tg9NSK5hOw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Book",
                newName: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d6e40b98-aec1-4434-b987-d65f340536f4",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBqWWjX4fMPP7QpczhH8JZzAvnWHPNnuhP8/WmBQnZk8RQwLbxb6o/40z4LEhcHY+Q==");
        }
    }
}
