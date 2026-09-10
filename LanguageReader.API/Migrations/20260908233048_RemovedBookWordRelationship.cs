using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageReader.API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedBookWordRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Words_Books_BookId",
                table: "Words");

            migrationBuilder.DropIndex(
                name: "IX_Words_BookId",
                table: "Words");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Words");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Words",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Words_BookId",
                table: "Words",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Words_Books_BookId",
                table: "Words",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
