using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaCompra.Migrations
{
    /// <inheritdoc />
    public partial class MundancaNomeProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaDeComprasId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Produtos",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Produtos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "Product_Name",
                table: "Produtos",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "ListaDeComprasId",
                table: "Produtos",
                newName: "ListaId");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_ListaDeComprasId",
                table: "Produtos",
                newName: "IX_Produtos_ListaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaId",
                table: "Produtos",
                column: "ListaId",
                principalTable: "ListaDeCompras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaId",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Produtos",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ListaId",
                table: "Produtos",
                newName: "ListaDeComprasId");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produtos",
                newName: "Product_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_ListaId",
                table: "Produtos",
                newName: "IX_Produtos_ListaDeComprasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaDeComprasId",
                table: "Produtos",
                column: "ListaDeComprasId",
                principalTable: "ListaDeCompras",
                principalColumn: "Id");
        }
    }
}
