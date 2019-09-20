using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarTabsAndChords.WebAPI.Migrations
{
    public partial class ban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabCorrections");

            migrationBuilder.AddColumn<DateTime>(
                name: "BannedUntil",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotationCorrections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NotationId = table.Column<int>(nullable: false),
                    NotationContent = table.Column<string>(nullable: true),
                    TuningId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotationCorrections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotationCorrections_Notations_NotationId",
                        column: x => x.NotationId,
                        principalTable: "Notations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotationCorrections_Tunings_TuningId",
                        column: x => x.TuningId,
                        principalTable: "Tunings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotationCorrections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotationCorrections_NotationId",
                table: "NotationCorrections",
                column: "NotationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotationCorrections_TuningId",
                table: "NotationCorrections",
                column: "TuningId");

            migrationBuilder.CreateIndex(
                name: "IX_NotationCorrections_UserId",
                table: "NotationCorrections",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotationCorrections");

            migrationBuilder.DropColumn(
                name: "BannedUntil",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "TabCorrections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Approved = table.Column<bool>(nullable: false),
                    DateSubmitted = table.Column<DateTime>(nullable: false),
                    NotationContent = table.Column<string>(nullable: true),
                    NotationId = table.Column<int>(nullable: false),
                    TuningId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabCorrections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TabCorrections_Notations_NotationId",
                        column: x => x.NotationId,
                        principalTable: "Notations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabCorrections_Tunings_TuningId",
                        column: x => x.TuningId,
                        principalTable: "Tunings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TabCorrections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabCorrections_NotationId",
                table: "TabCorrections",
                column: "NotationId");

            migrationBuilder.CreateIndex(
                name: "IX_TabCorrections_TuningId",
                table: "TabCorrections",
                column: "TuningId");

            migrationBuilder.CreateIndex(
                name: "IX_TabCorrections_UserId",
                table: "TabCorrections",
                column: "UserId");
        }
    }
}
