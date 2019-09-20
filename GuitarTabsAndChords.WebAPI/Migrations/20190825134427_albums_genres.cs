using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarTabsAndChords.WebAPI.Migrations
{
    public partial class albums_genres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Albums_AlbumsId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_AlbumsId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "AlbumsId",
                table: "Genres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlbumsId",
                table: "Genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_AlbumsId",
                table: "Genres",
                column: "AlbumsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Albums_AlbumsId",
                table: "Genres",
                column: "AlbumsId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
