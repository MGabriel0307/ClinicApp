using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroPhytoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorieToProdus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Produse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Produse");
        }
    }
}
