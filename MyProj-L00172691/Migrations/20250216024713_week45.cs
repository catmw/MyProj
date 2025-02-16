using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyProj_L00172691.Migrations
{
    /// <inheritdoc />
    public partial class week45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "GenreId", "ImageName", "Title" },
                values: new object[,]
                {
                    { 1, 1, 4, "tcat.jpg", " The Traveling Cat Chronicles" },
                    { 2, 2, 2, "tomorrow.jpg", "Tomorrow, and Tomorrow and Tomorrow" }
                });
        }
    }
}
