using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class CommunityEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunityEvents",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    IsPublished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InReview = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Recurring = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Interval = table.Column<int>(type: "int", nullable: true),
                    Location = table.Column<string>(type: "longtext", nullable: true),
                    DiscordServerLink = table.Column<string>(type: "longtext", nullable: true),
                    Host = table.Column<string>(type: "longtext", nullable: true),
                    ImageFile = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityEvents", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunityEvents");
        }
    }
}
