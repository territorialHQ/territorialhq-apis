using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    DiscordId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    Role = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    GuildId = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    Foundation = table.Column<string>(type: "longtext", nullable: true),
                    Founders = table.Column<string>(type: "longtext", nullable: true),
                    Motto = table.Column<string>(type: "longtext", nullable: true),
                    BotEndpoint = table.Column<string>(type: "longtext", nullable: true),
                    LogoFile = table.Column<string>(type: "longtext", nullable: true),
                    BannerFile = table.Column<string>(type: "longtext", nullable: true),
                    DiscordLink = table.Column<string>(type: "longtext", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    IsPublished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    InReview = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContentPages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true),
                    Content = table.Column<string>(type: "longtext", nullable: true),
                    SidebarContent = table.Column<string>(type: "longtext", nullable: true),
                    BannerImage = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentPages", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JournalArticles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true),
                    Subtitle = table.Column<string>(type: "longtext", nullable: true),
                    PublishFrom = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PublishTo = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Teaser = table.Column<string>(type: "longtext", nullable: true),
                    Body = table.Column<string>(type: "longtext", nullable: true),
                    Image = table.Column<string>(type: "longtext", nullable: true),
                    Tags = table.Column<string>(type: "longtext", nullable: true),
                    IsSticky = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalArticles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TokenClients",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    ReturnUrl = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenClients", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClanUserRelations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    ClanId = table.Column<string>(type: "varchar(255)", nullable: true),
                    AppUserId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanUserRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClanUserRelations_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClanUserRelations_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NavigationEntries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Slug = table.Column<string>(type: "longtext", nullable: true),
                    Public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ParentId = table.Column<string>(type: "varchar(255)", nullable: true),
                    Order = table.Column<short>(type: "smallint", nullable: false),
                    ContentPageId = table.Column<string>(type: "varchar(255)", nullable: true),
                    ExternalUrl = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavigationEntries_ContentPages_ContentPageId",
                        column: x => x.ContentPageId,
                        principalTable: "ContentPages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NavigationEntries_NavigationEntries_ParentId",
                        column: x => x.ParentId,
                        principalTable: "NavigationEntries",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClanUserRelations_AppUserId",
                table: "ClanUserRelations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClanUserRelations_ClanId",
                table: "ClanUserRelations",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationEntries_ContentPageId",
                table: "NavigationEntries",
                column: "ContentPageId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationEntries_ParentId",
                table: "NavigationEntries",
                column: "ParentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanUserRelations");

            migrationBuilder.DropTable(
                name: "JournalArticles");

            migrationBuilder.DropTable(
                name: "NavigationEntries");

            migrationBuilder.DropTable(
                name: "TokenClients");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Clans");

            migrationBuilder.DropTable(
                name: "ContentPages");
        }
    }
}
