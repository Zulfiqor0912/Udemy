using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Contents",
                newName: "UrlVideo");

            migrationBuilder.AddColumn<string>(
                name: "UrlImage",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImage",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "UrlVideo",
                table: "Contents",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
