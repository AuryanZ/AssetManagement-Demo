using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class newAssetsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputVotage",
                table: "SubZone");

            migrationBuilder.DropColumn(
                name: "OutputVotage",
                table: "SubZone");

            migrationBuilder.DropColumn(
                name: "SiteID",
                table: "SubZone");

            migrationBuilder.RenameColumn(
                name: "GPS",
                table: "SubZone",
                newName: "LocalCouncil");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubZone",
                newName: "SubZoneId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Assets",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "LocationDescraption",
                table: "Assets",
                newName: "GXP");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Assets",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "LastInspectionDate",
                table: "Assets",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "InstallDate",
                table: "Assets",
                newName: "CreatDate");

            migrationBuilder.RenameColumn(
                name: "GPS",
                table: "Assets",
                newName: "Feeder");

            migrationBuilder.RenameColumn(
                name: "EstimateRetairDate",
                table: "Assets",
                newName: "CommissionedDate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Assets",
                newName: "AssetId");

            migrationBuilder.AddColumn<string>(
                name: "AssetOwner",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetOwner",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Assets");

            migrationBuilder.RenameColumn(
                name: "LocalCouncil",
                table: "SubZone",
                newName: "GPS");

            migrationBuilder.RenameColumn(
                name: "SubZoneId",
                table: "SubZone",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Assets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "Assets",
                newName: "LastInspectionDate");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "Assets",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "GXP",
                table: "Assets",
                newName: "LocationDescraption");

            migrationBuilder.RenameColumn(
                name: "Feeder",
                table: "Assets",
                newName: "GPS");

            migrationBuilder.RenameColumn(
                name: "CreatDate",
                table: "Assets",
                newName: "InstallDate");

            migrationBuilder.RenameColumn(
                name: "CommissionedDate",
                table: "Assets",
                newName: "EstimateRetairDate");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "Assets",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "InputVotage",
                table: "SubZone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OutputVotage",
                table: "SubZone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiteID",
                table: "SubZone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
