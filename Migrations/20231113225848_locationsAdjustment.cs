using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecc.Migrations
{
    /// <inheritdoc />
    public partial class locationsAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "location");

            migrationBuilder.DropColumn(
                name: "Gia",
                table: "location");

            migrationBuilder.DropColumn(
                name: "Ibge",
                table: "location");

            migrationBuilder.DropColumn(
                name: "Siafi",
                table: "location");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "location",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gia",
                table: "location",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ibge",
                table: "location",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Siafi",
                table: "location",
                type: "text",
                nullable: true);
        }
    }
}
