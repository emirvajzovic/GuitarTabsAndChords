using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarTabsAndChords.WebAPI.Migrations
{
    public partial class Approved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Tunings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Tabs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "TabCorrections",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Songs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Genres",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Artists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Albums",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Tunings");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "TabCorrections");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Albums");
        }
    }
}
