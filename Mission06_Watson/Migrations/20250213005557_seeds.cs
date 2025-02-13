using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mission06_Watson.Migrations
{
    /// <inheritdoc />
    public partial class seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Sci-Fi", "Christopher Nolan", false, "John", "Mind-bending thriller", "PG-13", "Inception", "2010" },
                    { 2, "Sci-Fi", "The Wachowskis", true, "Sarah", "Classic cyberpunk", "R", "The Matrix", "1999" },
                    { 3, "Sci-Fi", "Christopher Nolan", false, "Michael", "Epic space journey", "PG-13", "Interstellar", "2014" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3);
        }
    }
}
