using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rentaly.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RightDescription",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RightIcon",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RightTitle",
                table: "Features");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RightDescription",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RightIcon",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RightTitle",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
