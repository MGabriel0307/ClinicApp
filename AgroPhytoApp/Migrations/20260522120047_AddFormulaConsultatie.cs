using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroPhytoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFormulaConsultatie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pret",
                table: "Produse",
                newName: "TaxaConsultatie");

            migrationBuilder.AddColumn<int>(
                name: "NrAnalize",
                table: "Produse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NrAnalize",
                table: "Produse");

            migrationBuilder.RenameColumn(
                name: "TaxaConsultatie",
                table: "Produse",
                newName: "Pret");
        }
    }
}
