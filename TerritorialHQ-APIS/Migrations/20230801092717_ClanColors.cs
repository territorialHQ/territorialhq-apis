using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class ClanColors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color1",
                table: "Clans",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color2",
                table: "Clans",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color1",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "Color2",
                table: "Clans");
        }
    }
}
