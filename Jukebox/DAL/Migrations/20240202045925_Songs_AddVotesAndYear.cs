using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jukebox.DAL.Migrations
{
    public partial class Songs_AddVotesAndYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Votes",
                table: "Songs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Songs",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Songs");
        }
    }
}
