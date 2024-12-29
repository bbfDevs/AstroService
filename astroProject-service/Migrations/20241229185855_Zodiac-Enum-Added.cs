using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace astroProject_service.Migrations
{
    /// <inheritdoc />
    public partial class ZodiacEnumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zodiac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zodiac", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Zodiac",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Aries" },
                    { 2, "Taurus" },
                    { 3, "Gemini" },
                    { 4, "Cancer" },
                    { 5, "Leo" },
                    { 6, "Virgo" },
                    { 7, "Libra" },
                    { 8, "Scorpio" },
                    { 9, "Sagittarius" },
                    { 10, "Capricorn" },
                    { 11, "Aquarius" },
                    { 12, "Pisces" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zodiac");
        }
    }
}
