using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewApp.Migrations
{
    /// <inheritdoc />
    public partial class Adding_ContentProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AppGeneralSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "AppGeneralSettings");
        }
    }
}
