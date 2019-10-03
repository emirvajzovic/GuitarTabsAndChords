using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarTabsAndChords.WebAPI.Migrations
{
    public partial class tuning_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotationCorrections_Tunings_TuningId",
                table: "NotationCorrections");

            migrationBuilder.DropForeignKey(
                name: "FK_Notations_Tunings_TuningId",
                table: "Notations");

            migrationBuilder.DropIndex(
                name: "IX_Notations_TuningId",
                table: "Notations");

            migrationBuilder.DropIndex(
                name: "IX_NotationCorrections_TuningId",
                table: "NotationCorrections");

            migrationBuilder.DropColumn(
                name: "TuningId",
                table: "Notations");

            migrationBuilder.DropColumn(
                name: "TuningId",
                table: "NotationCorrections");

            migrationBuilder.AddColumn<string>(
                name: "Tuning",
                table: "Notations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tuning",
                table: "NotationCorrections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tuning",
                table: "Notations");

            migrationBuilder.DropColumn(
                name: "Tuning",
                table: "NotationCorrections");

            migrationBuilder.AddColumn<int>(
                name: "TuningId",
                table: "Notations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TuningId",
                table: "NotationCorrections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notations_TuningId",
                table: "Notations",
                column: "TuningId");

            migrationBuilder.CreateIndex(
                name: "IX_NotationCorrections_TuningId",
                table: "NotationCorrections",
                column: "TuningId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotationCorrections_Tunings_TuningId",
                table: "NotationCorrections",
                column: "TuningId",
                principalTable: "Tunings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notations_Tunings_TuningId",
                table: "Notations",
                column: "TuningId",
                principalTable: "Tunings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
