using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalClanFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "GuildId",
                table: "Clans",
                type: "bigint unsigned",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

            migrationBuilder.AddColumn<string>(
                name: "Community",
                table: "Clans",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "Clans",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "History",
                table: "Clans",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Miscellaneous",
                table: "Clans",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Community",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "History",
                table: "Clans");

            migrationBuilder.DropColumn(
                name: "Miscellaneous",
                table: "Clans");

            migrationBuilder.AlterColumn<ulong>(
                name: "GuildId",
                table: "Clans",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned",
                oldNullable: true);
        }
    }
}
