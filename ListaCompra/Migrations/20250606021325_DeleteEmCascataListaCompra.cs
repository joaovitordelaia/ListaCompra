using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaCompra.Migrations
{
    /// <inheritdoc />
    public partial class DeleteEmCascataListaCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaDeComprasId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaDeComprasId",
                table: "Produtos",
                column: "ListaDeComprasId",
                principalTable: "ListaDeCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaDeComprasId",
                table: "Produtos");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_ListaDeCompras_ListaDeComprasId",
                table: "Produtos",
                column: "ListaDeComprasId",
                principalTable: "ListaDeCompras",
                principalColumn: "Id");
        }
    }
}
