using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class AssetsAndSubZoneTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetDescription",
                table: "Assets");

            // migrationBuilder.DropColumn(
            //     name: "AssetType",
            //     table: "Assets");

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimateRetairDate",
                table: "Assets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GPS",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallDate",
                table: "Assets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastInspectionDate",
                table: "Assets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LocationDescraption",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimateRetairDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "GPS",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "InstallDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "LastInspectionDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "LocationDescraption",
                table: "Assets");

            migrationBuilder.AddColumn<string>(
                name: "AssetDescription",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssetType",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
