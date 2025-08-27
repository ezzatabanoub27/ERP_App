using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewApp.Migrations
{
    /// <inheritdoc />
    public partial class tanent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppLanguages",
                table: "AppLanguages");

            migrationBuilder.RenameTable(
                name: "AppLanguages",
                newName: "Languages");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "GeneralSetting",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "GeneralSetting");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "AppLanguages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppLanguages",
                table: "AppLanguages",
                column: "Id");
        }
    }
}
