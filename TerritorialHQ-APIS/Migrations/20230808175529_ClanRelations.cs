using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerritorialHQ_APIS.Migrations
{
    /// <inheritdoc />
    public partial class ClanRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClanRelation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Creator = table.Column<string>(type: "longtext", nullable: true),
                    ClanId = table.Column<string>(type: "varchar(255)", nullable: true),
                    TargetClanId = table.Column<string>(type: "varchar(255)", nullable: true),
                    DiplomaticRelation = table.Column<int>(type: "int", nullable: false),
                    HierachicalRelation = table.Column<int>(type: "int", nullable: false),
                    MilitaryRelation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClanRelation_Clans_ClanId",
                        column: x => x.ClanId,
                        principalTable: "Clans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClanRelation_Clans_TargetClanId",
                        column: x => x.TargetClanId,
                        principalTable: "Clans",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClanRelation_ClanId",
                table: "ClanRelation",
                column: "ClanId");

            migrationBuilder.CreateIndex(
                name: "IX_ClanRelation_TargetClanId",
                table: "ClanRelation",
                column: "TargetClanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClanRelation");
        }
    }
}
