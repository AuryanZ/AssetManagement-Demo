using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class AssetsAndSubZoneTable4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SubZoneID",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SubZoneID",
                table: "Assets",
                column: "SubZoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_SubZone_SubZoneID",
                table: "Assets",
                column: "SubZoneID",
                principalTable: "SubZone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_SubZone_SubZoneID",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_SubZoneID",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "SubZoneID",
                table: "Assets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
