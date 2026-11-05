using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v1104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_PedidosId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PedidosId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidosId",
                table: "Produtos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PedidosId",
                table: "Produtos",
                column: "PedidosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_PedidosId",
                table: "Produtos",
                column: "PedidosId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }
    }
}
