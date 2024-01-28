using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jcm.DAL.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PerformanceActs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceActs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Performers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PerformanceActId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performers_PerformanceActs_PerformanceActId",
                        column: x => x.PerformanceActId,
                        principalTable: "PerformanceActs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PerformanceActs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "The Beatles" });

            migrationBuilder.InsertData(
                table: "PerformanceActs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, null, "The Rolling Stones" });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 1, "John", null, 1 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 2, "Paul", null, 1 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 3, "George", null, 1 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 4, "Ringo", null, 1 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 5, "Mick", "Jagger", 2 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 6, "Keith", "Richards", 2 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 7, "Ron", "Wood", 2 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 8, "Bill", "Wyman", 2 });

            migrationBuilder.InsertData(
                table: "Performers",
                columns: new[] { "Id", "FirstName", "LastName", "PerformanceActId" },
                values: new object[] { 9, "Charlie", "Watts", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Performers_PerformanceActId",
                table: "Performers",
                column: "PerformanceActId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performers");

            migrationBuilder.DropTable(
                name: "PerformanceActs");
        }
    }
}
