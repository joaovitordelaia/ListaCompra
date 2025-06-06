using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaCompra.Migrations
{
    /// <inheritdoc />
    public partial class statusProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StatusProd",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusProd",
                table: "Produtos");
        }
    }
}
