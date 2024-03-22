using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class poleandpillerBoxDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Transformer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PillerBox",
                columns: table => new
                {
                    PillerBoxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PillerBoxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line_segment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PillerBox", x => x.PillerBoxId);
                    table.ForeignKey(
                        name: "FK_PillerBox_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pole",
                columns: table => new
                {
                    PoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoleHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoleMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegLife = table.Column<int>(type: "int", nullable: false),
                    AssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pole", x => x.PoleId);
                    table.ForeignKey(
                        name: "FK_Pole_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PillerBox_AssetId",
                table: "PillerBox",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pole_AssetId",
                table: "Pole",
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PillerBox");

            migrationBuilder.DropTable(
                name: "Pole");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Transformer");
        }
    }
}
