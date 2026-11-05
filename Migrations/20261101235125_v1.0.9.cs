using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v109 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pedidos_IdPedido",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_IdPedido",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "IdProduto",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Pedidos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "IdPedido",
                table: "Produtos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdProduto",
                table: "Pedidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Pedidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdPedido",
                table: "Produtos",
                column: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pedidos_IdPedido",
                table: "Produtos",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
