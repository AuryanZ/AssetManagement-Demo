using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    /// <inheritdoc />
    public partial class AssetsAndSubZoneTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubZone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubZoneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputVotage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputVotage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubZone", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubZone");
        }
    }
}
