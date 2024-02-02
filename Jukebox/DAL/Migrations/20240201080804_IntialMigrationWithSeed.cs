using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jukebox.DAL.Migrations
{
    public partial class IntialMigrationWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PerformerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Performers_PerformerId",
                        column: x => x.PerformerId,
                        principalTable: "Performers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "The Beatles" });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "The Rolling Stones" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 1, "Strawberry Fields", 1 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 2, "Yellow Submarine", 1 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 3, "The Long and Winding Road", 1 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 4, "All You Need Is Love", 1 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 5, "Tumblin Dice", 2 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 6, "Gimme Shelter", 2 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 7, "Angie", 2 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 8, "Wild Horses", 2 });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Name", "PerformerId" },
                values: new object[] { 9, "Can't You Hear Me Knocking", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PerformerId",
                table: "Songs",
                column: "PerformerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Performers");
        }
    }
}
