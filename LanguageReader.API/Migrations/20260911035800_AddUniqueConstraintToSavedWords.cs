using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageReader.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintToSavedWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add unique index on the combination of WordId and BookId
            // This ensures the same word from the same book cannot be saved twice
            migrationBuilder.CreateIndex(
                name: "IX_SavedWords_WordId_BookId_Unique",
                table: "SavedWords",
                columns: new[] { "WordId", "BookId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the unique index if rolling back
            migrationBuilder.DropIndex(
                name: "IX_SavedWords_WordId_BookId_Unique",
                table: "SavedWords");
        }
    }
}
