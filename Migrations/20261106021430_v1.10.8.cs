using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v1108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_IdProduto",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Vendidos");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "Pedidos",
                newName: "ProdutoIdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_IdProduto",
                table: "Pedidos",
                newName: "IX_Pedidos_ProdutoIdProduto");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoIdProduto",
                table: "Pedidos",
                column: "ProdutoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_ProdutoIdProduto",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "ProdutoIdProduto",
                table: "Pedidos",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_ProdutoIdProduto",
                table: "Pedidos",
                newName: "IX_Pedidos_IdProduto");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Vendidos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_IdProduto",
                table: "Pedidos",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto");
        }
    }
}
