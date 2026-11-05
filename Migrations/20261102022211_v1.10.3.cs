using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v1103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Entregadores_entregadorId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendidos_Entregadores_EntregadorId",
                table: "Vendidos");

            migrationBuilder.DropIndex(
                name: "IX_Vendidos_EntregadorId",
                table: "Vendidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_entregadorId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EntregadorId",
                table: "Vendidos");

            migrationBuilder.DropColumn(
                name: "IdEntregador",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "entregadorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaEntrega",
                table: "Vendidos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IdPedido",
                table: "Produtos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PedidosId",
                table: "Produtos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_IdEntregador",
                table: "Vendidos",
                column: "IdEntregador");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidosId",
                table: "Produtos",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdProduto",
                table: "Pedidos",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_IdProduto",
                table: "Pedidos",
                column: "IdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_PedidosId",
                table: "Produtos",
                column: "PedidosId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendidos_Entregadores_IdEntregador",
                table: "Vendidos",
                column: "IdEntregador",
                principalTable: "Entregadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_IdProduto",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_PedidosId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendidos_Entregadores_IdEntregador",
                table: "Vendidos");

            migrationBuilder.DropIndex(
                name: "IX_Vendidos_IdEntregador",
                table: "Vendidos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidosId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdProduto",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "TaxaEntrega",
                table: "Vendidos");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "EntregadorId",
                table: "Vendidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEntregador",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "entregadorId",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "produtoIdProduto",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_EntregadorId",
                table: "Vendidos",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_entregadorId",
                table: "Pedidos",
                column: "entregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_produtoIdProduto",
                table: "Pedidos",
                column: "produtoIdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Entregadores_entregadorId",
                table: "Pedidos",
                column: "entregadorId",
                principalTable: "Entregadores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Produtos_produtoIdProduto",
                table: "Pedidos",
                column: "produtoIdProduto",
                principalTable: "Produtos",
                principalColumn: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendidos_Entregadores_EntregadorId",
                table: "Vendidos",
                column: "EntregadorId",
                principalTable: "Entregadores",
                principalColumn: "Id");
        }
    }
}
