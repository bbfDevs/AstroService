using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace astroProject_service.Migrations
{
    /// <inheritdoc />
    public partial class LifeAspectsEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ZodiacSignStream",
                type: "VARCHAR(2500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

            migrationBuilder.CreateTable(
                name: "LifeAspect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeAspect", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LifeAspect",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Love" },
                    { 2, "Career" },
                    { 3, "Health" },
                    { 4, "Money" },
                    { 5, "Family" },
                    { 6, "Friends" },
                    { 7, "Travel" },
                    { 8, "Education" },
                    { 9, "SocialLife" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LifeAspect");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ZodiacSignStream",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2500)");
        }
    }
}
