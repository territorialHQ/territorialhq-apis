using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class ClanLeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Leader",
                table: "Clans",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Leader",
                table: "Clans");
        }
    }
}
