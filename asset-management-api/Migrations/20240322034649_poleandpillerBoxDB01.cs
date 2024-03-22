using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class poleandpillerBoxDB01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transformer_AssetID",
                table: "Transformer");

            migrationBuilder.DropIndex(
                name: "IX_Substation_AssetID",
                table: "Substation");

            migrationBuilder.DropIndex(
                name: "IX_Pole_AssetId",
                table: "Pole");

            migrationBuilder.DropIndex(
                name: "IX_PillerBox_AssetId",
                table: "PillerBox");

            migrationBuilder.DropIndex(
                name: "IX_Cable_AssetID",
                table: "Cable");

            migrationBuilder.DropIndex(
                name: "IX_BatteryBank_AssetID",
                table: "BatteryBank");

            migrationBuilder.AddColumn<string>(
                name: "LatestAnnualRecordID",
                table: "SubZone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatestBiMonthRecordID",
                table: "SubZone",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_AssetID",
                table: "Transformer",
                column: "AssetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Substation_AssetID",
                table: "Substation",
                column: "AssetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pole_AssetId",
                table: "Pole",
                column: "AssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PillerBox_AssetId",
                table: "PillerBox",
                column: "AssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cable_AssetID",
                table: "Cable",
                column: "AssetID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BatteryBank_AssetID",
                table: "BatteryBank",
                column: "AssetID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transformer_AssetID",
                table: "Transformer");

            migrationBuilder.DropIndex(
                name: "IX_Substation_AssetID",
                table: "Substation");

            migrationBuilder.DropIndex(
                name: "IX_Pole_AssetId",
                table: "Pole");

            migrationBuilder.DropIndex(
                name: "IX_PillerBox_AssetId",
                table: "PillerBox");

            migrationBuilder.DropIndex(
                name: "IX_Cable_AssetID",
                table: "Cable");

            migrationBuilder.DropIndex(
                name: "IX_BatteryBank_AssetID",
                table: "BatteryBank");

            migrationBuilder.DropColumn(
                name: "LatestAnnualRecordID",
                table: "SubZone");

            migrationBuilder.DropColumn(
                name: "LatestBiMonthRecordID",
                table: "SubZone");

            migrationBuilder.CreateIndex(
                name: "IX_Transformer_AssetID",
                table: "Transformer",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Substation_AssetID",
                table: "Substation",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_Pole_AssetId",
                table: "Pole",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_PillerBox_AssetId",
                table: "PillerBox",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Cable_AssetID",
                table: "Cable",
                column: "AssetID");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryBank_AssetID",
                table: "BatteryBank",
                column: "AssetID");
        }
    }
}
