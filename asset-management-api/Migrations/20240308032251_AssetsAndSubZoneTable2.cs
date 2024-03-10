using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class AssetsAndSubZoneTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AssetStatus",
                table: "Assets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "AssetName",
                table: "Assets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AssetLocation",
                table: "Assets",
                newName: "Location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Assets",
                newName: "AssetStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Assets",
                newName: "AssetName");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Assets",
                newName: "AssetLocation");
        }
    }
}
