using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace astroProject_service.Migrations
{
    /// <inheritdoc />
    public partial class TarotCard2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TarotCard",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 3, "The High Priestess" },
                    { 4, "The Empress" },
                    { 5, "The Emperor" },
                    { 6, "The Hierophant" },
                    { 7, "The Lovers" },
                    { 8, "The Chariot" },
                    { 9, "Strength" },
                    { 10, "The Hermit" },
                    { 11, "Wheel of Fortune" },
                    { 12, "Justice" },
                    { 13, "The Hanged Man" },
                    { 14, "Death" },
                    { 15, "Temperance" },
                    { 16, "The Devil" },
                    { 17, "The Tower" },
                    { 18, "The Star" },
                    { 19, "The Moon" },
                    { 20, "The Sun" },
                    { 21, "Judgement" },
                    { 22, "The World" },
                    { 23, "Ace of Cups" },
                    { 24, "Two of Cups" },
                    { 25, "Three of Cups" },
                    { 26, "Four of Cups" },
                    { 27, "Five of Cups" },
                    { 28, "Six of Cups" },
                    { 29, "Seven of Cups" },
                    { 30, "Eight of Cups" },
                    { 31, "Nine of Cups" },
                    { 32, "Ten of Cups" },
                    { 33, "Page of Cups" },
                    { 34, "Knight of Cups" },
                    { 35, "Queen of Cups" },
                    { 36, "King of Cups" },
                    { 37, "Ace of Wands" },
                    { 38, "Two of Wands" },
                    { 39, "Three of Wands" },
                    { 40, "Four of Wands" },
                    { 41, "Five of Wands" },
                    { 42, "Six of Wands" },
                    { 43, "Seven of Wands" },
                    { 44, "Eight of Wands" },
                    { 45, "Nine of Wands" },
                    { 46, "Ten of Wands" },
                    { 47, "Page of Wands" },
                    { 48, "Knight of Wands" },
                    { 49, "Queen of Wands" },
                    { 50, "King of Wands" },
                    { 51, "Ace of Swords" },
                    { 52, "Two of Swords" },
                    { 53, "Three of Swords" },
                    { 54, "Four of Swords" },
                    { 55, "Five of Swords" },
                    { 56, "Six of Swords" },
                    { 57, "Seven of Swords" },
                    { 58, "Eight of Swords" },
                    { 59, "Nine of Swords" },
                    { 60, "Ten of Swords" },
                    { 61, "Page of Swords" },
                    { 62, "Knight of Swords" },
                    { 63, "Queen of Swords" },
                    { 64, "King of Swords" },
                    { 65, "Ace of Pentacles" },
                    { 66, "Two of Pentacles" },
                    { 67, "Three of Pentacles" },
                    { 68, "Four of Pentacles" },
                    { 69, "Five of Pentacles" },
                    { 70, "Six of Pentacles" },
                    { 71, "Seven of Pentacles" },
                    { 72, "Eight of Pentacles" },
                    { 73, "Nine of Pentacles" },
                    { 74, "Ten of Pentacles" },
                    { 75, "Page of Pentacles" },
                    { 76, "Knight of Pentacles" },
                    { 77, "Queen of Pentacles" },
                    { 78, "King of Pentacles" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "TarotCard",
                keyColumn: "Id",
                keyValue: 78);
        }
    }
}
