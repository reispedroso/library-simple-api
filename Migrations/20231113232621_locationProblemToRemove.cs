using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecc.Migrations
{
    /// <inheritdoc />
    public partial class locationProblemToRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationModelLocationId",
                table: "users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_LocationModelLocationId",
                table: "users",
                column: "LocationModelLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_location_LocationModelLocationId",
                table: "users",
                column: "LocationModelLocationId",
                principalTable: "location",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_location_LocationModelLocationId",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_LocationModelLocationId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LocationModelLocationId",
                table: "users");
        }
    }
}
