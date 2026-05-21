using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroPhytoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPacientFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Produse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CNP",
                table: "Produse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataProgramare",
                table: "Produse",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OraProgramare",
                table: "Produse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Produse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "DataProgramare",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "OraProgramare",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Produse");
        }
    }
}
