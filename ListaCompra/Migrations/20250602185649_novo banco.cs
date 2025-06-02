using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaCompra.Migrations
{
    /// <inheritdoc />
    public partial class novobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidade",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Produtos",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produtos",
                newName: "Product_Name");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "Produtos",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Produtos",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Product_Name",
                table: "Produtos",
                newName: "Descricao");

            migrationBuilder.AddColumn<string>(
                name: "Unidade",
                table: "Produtos",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                defaultValue: "");
        }
    }
}
