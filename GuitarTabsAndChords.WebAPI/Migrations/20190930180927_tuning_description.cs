using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarTabsAndChords.WebAPI.Migrations
{
    public partial class tuning_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TuningDescription",
                table: "Notations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TuningDescription",
                table: "NotationCorrections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TuningDescription",
                table: "Notations");

            migrationBuilder.DropColumn(
                name: "TuningDescription",
                table: "NotationCorrections");
        }
    }
}
