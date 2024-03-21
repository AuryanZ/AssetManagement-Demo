using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class newAssetsUpdate01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssetsGroupID",
                table: "Assets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssetsGroup",
                columns: table => new
                {
                    AssetsGroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsGroup", x => x.AssetsGroupID);
                });

            migrationBuilder.CreateTable(
                name: "BatteryBank",
                columns: table => new
                {
                    BatteryBankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatteryBankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryBankType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryBankCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryBankVoltage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryBank", x => x.BatteryBankId);
                    table.ForeignKey(
                        name: "FK_BatteryBank_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Substation",
                columns: table => new
                {
                    SubstationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputVotage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputVotage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Voltage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastInspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inspactby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substation", x => x.SubstationId);
                    table.ForeignKey(
                        name: "FK_Substation_Assets_AssetID",
                        column: x => x.AssetID,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetsGroupID",
                table: "Assets",
                column: "AssetsGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryBank_AssetID",
                table: "BatteryBank",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Substation_AssetID",
                table: "Substation",
                column: "AssetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssetsGroup_AssetsGroupID",
                table: "Assets",
                column: "AssetsGroupID",
                principalTable: "AssetsGroup",
                principalColumn: "AssetsGroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssetsGroup_AssetsGroupID",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "AssetsGroup");

            migrationBuilder.DropTable(
                name: "BatteryBank");

            migrationBuilder.DropTable(
                name: "Substation");

            migrationBuilder.DropIndex(
                name: "IX_Assets_AssetsGroupID",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "AssetsGroupID",
                table: "Assets");
        }
    }
}
