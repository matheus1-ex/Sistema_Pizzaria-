using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "produtoIdProduto",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "produtoIdProduto",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_produtoIdProduto",
                table: "Pedidos",
                column: "produtoIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_produtoIdProduto",
                table: "Pedidos",
                column: "produtoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto");
        }
    }
}
