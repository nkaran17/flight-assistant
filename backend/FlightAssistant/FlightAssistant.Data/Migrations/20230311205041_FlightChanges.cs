using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightAssistant.Data.Migrations
{
    /// <inheritdoc />
    public partial class FlightChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLayovers",
                table: "Flight",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "Flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfLayovers",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Flight");
        }
    }
}
