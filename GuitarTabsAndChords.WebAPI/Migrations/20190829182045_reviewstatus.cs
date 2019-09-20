using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarTabsAndChords.WebAPI.Migrations
{
    public partial class reviewstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Tunings");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Notations");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "NotationCorrections");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "Albums");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Tunings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Songs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Notations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "NotationCorrections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Genres",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Artists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Albums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tunings");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Notations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "NotationCorrections");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Albums");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Tunings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Songs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "Notations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "NotationCorrections",
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
    }
}
