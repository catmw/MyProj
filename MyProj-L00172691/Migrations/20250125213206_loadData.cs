using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyProj_L00172691.Migrations
{
    /// <inheritdoc />
    public partial class loadData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "Title" },
                values: new object[,]
                {
                    { 1, "Hiro Arikawa", "Contemporary", "The Travelling Cat Chronicles" },
                    { 2, "Clair Keegan", "Historical", "Small Things Like These" },
                    { 3, "Jason Rekulak", "Mystery", "Hidden Pictures" },
                    { 4, "Peter Beagle", "Fantasy", "The Story of Kao Yu" },
                    { 5, "Barbara Comyns", "Classics", "Who Was Changed and Who Was Dead" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
