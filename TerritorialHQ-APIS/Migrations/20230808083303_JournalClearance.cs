using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class JournalClearance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCleared",
                table: "JournalArticles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseColorForPage",
                table: "Clans",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCleared",
                table: "JournalArticles");

            migrationBuilder.DropColumn(
                name: "UseColorForPage",
                table: "Clans");
        }
    }
}
