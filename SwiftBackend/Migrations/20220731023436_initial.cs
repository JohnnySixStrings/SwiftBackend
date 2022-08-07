using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiftBackend.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Macro",
                columns: table => new
                {
                    MacroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kelvin = table.Column<string>(type: "TEXT", nullable: false),
                    Tint = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macro", x => x.MacroId);
                });

            migrationBuilder.CreateTable(
                name: "Zoom",
                columns: table => new
                {
                    ZoomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kelvin = table.Column<string>(type: "TEXT", nullable: false),
                    Tint = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoom", x => x.ZoomId);
                });

            migrationBuilder.CreateTable(
                name: "Cameras",
                columns: table => new
                {
                    CameraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MacroId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameras", x => x.CameraId);
                    table.ForeignKey(
                        name: "FK_Cameras_Macro_MacroId",
                        column: x => x.MacroId,
                        principalTable: "Macro",
                        principalColumn: "MacroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cameras_Zoom_ZoomId",
                        column: x => x.ZoomId,
                        principalTable: "Zoom",
                        principalColumn: "ZoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    FilterId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kelvin = table.Column<string>(type: "TEXT", nullable: false),
                    Tint = table.Column<int>(type: "INTEGER", nullable: false),
                    CameraId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.FilterId);
                    table.ForeignKey(
                        name: "FK_Filters_Cameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Cameras",
                        principalColumn: "CameraId");
                });

            migrationBuilder.CreateTable(
                name: "Lenses",
                columns: table => new
                {
                    LenseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kelvin = table.Column<string>(type: "TEXT", nullable: false),
                    Tint = table.Column<int>(type: "INTEGER", nullable: false),
                    CameraId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lenses", x => x.LenseId);
                    table.ForeignKey(
                        name: "FK_Lenses_Cameras_CameraId",
                        column: x => x.CameraId,
                        principalTable: "Cameras",
                        principalColumn: "CameraId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_MacroId",
                table: "Cameras",
                column: "MacroId");

            migrationBuilder.CreateIndex(
                name: "IX_Cameras_ZoomId",
                table: "Cameras",
                column: "ZoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_CameraId",
                table: "Filters",
                column: "CameraId");

            migrationBuilder.CreateIndex(
                name: "IX_Lenses_CameraId",
                table: "Lenses",
                column: "CameraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "Lenses");

            migrationBuilder.DropTable(
                name: "Cameras");

            migrationBuilder.DropTable(
                name: "Macro");

            migrationBuilder.DropTable(
                name: "Zoom");
        }
    }
}
