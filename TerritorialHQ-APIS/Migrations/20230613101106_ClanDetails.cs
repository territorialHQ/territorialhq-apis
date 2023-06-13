using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class ClanDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BotEndpoint",
                table: "Clans",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foundation",
                table: "Clans",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Founders",
                table: "Clans",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Motto",
                table: "Clans",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BotEndpoint",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "Foundation",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "Founders",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "Motto",
                table: "Clans");
        }
    }
}
