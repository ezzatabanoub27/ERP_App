using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewApp.Migrations
{
    /// <inheritdoc />
    public partial class updatte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppGeneralSettings",
                table: "AppGeneralSettings");

            migrationBuilder.RenameTable(
                name: "AppGeneralSettings",
                newName: "GeneralSetting");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralSetting",
                table: "GeneralSetting",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralSetting",
                table: "GeneralSetting");

            migrationBuilder.RenameTable(
                name: "GeneralSetting",
                newName: "AppGeneralSettings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppGeneralSettings",
                table: "AppGeneralSettings",
                column: "Id");
        }
    }
}
