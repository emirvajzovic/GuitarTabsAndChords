using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarTabsAndChords.WebAPI.Migrations
{
    public partial class notation_corrections_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tuning",
                table: "NotationCorrections");

            migrationBuilder.DropColumn(
                name: "TuningDescription",
                table: "NotationCorrections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tuning",
                table: "NotationCorrections",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TuningDescription",
                table: "NotationCorrections",
                nullable: true);
        }
    }
}
