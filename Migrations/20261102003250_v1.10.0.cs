using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v1100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregadores_Pedidos_IdPedido",
                table: "Entregadores");

            migrationBuilder.AlterColumn<int>(
                name: "IdPedido",
                table: "Entregadores",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregadores_Pedidos_IdPedido",
                table: "Entregadores",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entregadores_Pedidos_IdPedido",
                table: "Entregadores");

            migrationBuilder.AlterColumn<int>(
                name: "IdPedido",
                table: "Entregadores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Entregadores_Pedidos_IdPedido",
                table: "Entregadores",
                column: "IdPedido",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
