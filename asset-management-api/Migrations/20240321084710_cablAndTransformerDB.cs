using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class cablAndTransformerDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GPS",
                table: "BatteryBank",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DisposalDate",
                table: "Assets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DisposalReason",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cable",
                columns: table => new
                {
                    CableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableVoltage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfPhases = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegLife = table.Column<int>(type: "int", nullable: false),
                    AssetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cable", x => x.CableId);
                    table.ForeignKey(
                        name: "FK_Cable_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transformer",
                columns: table => new
                {
                    TransformerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransformerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputVotage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputVotage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandOwner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegLife = table.Column<int>(type: "int", nullable: false),
                    AssetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transformer", x => x.TransformerId);
                    table.ForeignKey(
                        name: "FK_Transformer_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cable_AssetID",
                table: "Cable",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_AssetID",
                table: "Transformer",
                column: "AssetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cable");

            migrationBuilder.DropTable(
                name: "Transformer");

            migrationBuilder.DropColumn(
                name: "GPS",
                table: "BatteryBank");

            migrationBuilder.DropColumn(
                name: "DisposalDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "DisposalReason",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Assets");
        }
    }
}
