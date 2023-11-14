using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecc.Migrations
{
    /// <inheritdoc />
    public partial class locationsAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Localidade = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: true),
                    Ibge = table.Column<string>(type: "text", nullable: true),
                    Gia = table.Column<string>(type: "text", nullable: true),
                    Ddd = table.Column<string>(type: "text", nullable: true),
                    Siafi = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.LocationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "users",
                newName: "Role");
        }
    }
}
