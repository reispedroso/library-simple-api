using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecc.Migrations
{
    /// <inheritdoc />
    public partial class blabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE books ALTER COLUMN \"PublishDate\" TYPE timestamp with time zone USING \"PublishDate\"::timestamp with time zone;");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishDate",
                table: "books",
                type: "timestamp with time zone",
                nullable: true,
                defaultValueSql: "now()",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PublishDate",
                table: "books",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValueSql: "now()");
        }
    }
}
