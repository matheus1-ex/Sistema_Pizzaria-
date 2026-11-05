using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregadores_Pedidos_PedidosId",
                table: "Entregadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Entregadores_IdEntregador",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_IdEntregador",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Entregadores_PedidosId",
                table: "Entregadores");

            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "Entregadores");

            migrationBuilder.AddColumn<int>(
                name: "IdPedido",
                table: "Produtos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Produtos_IdPedido",
                table: "Produtos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_entregadorId",
                table: "Pedidos",
                column: "entregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_produtoIdProduto",
                table: "Pedidos",
                column: "produtoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_IdPedido",
                table: "Entregadores",
                column: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregadores_Pedidos_IdPedido",
                table: "Entregadores",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Produtos_Pedidos_IdPedido",
                table: "Produtos",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregadores_Pedidos_IdPedido",
                table: "Entregadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Entregadores_entregadorId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Produtos_produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_IdPedido",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdPedido",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_entregadorId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Entregadores_IdPedido",
                table: "Entregadores");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "entregadorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "produtoIdProduto",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "PedidosId",
                table: "Entregadores",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdEntregador",
                table: "Pedidos",
                column: "IdEntregador");

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_PedidosId",
                table: "Entregadores",
                column: "PedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregadores_Pedidos_PedidosId",
                table: "Entregadores",
                column: "PedidosId",
                principalTable: "Pedidos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Entregadores_IdEntregador",
                table: "Pedidos",
                column: "IdEntregador",
                principalTable: "Entregadores",
                principalColumn: "Id");
        }
    }
}
