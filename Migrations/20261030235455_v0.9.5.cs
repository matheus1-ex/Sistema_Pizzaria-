using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v095 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    SenhaHash = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    criadoEm = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    dataFabricado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    dataValidade = table.Column<DateTime>(type: "TEXT", nullable: false),
                    consumo = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    mensagem = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    SenhaHash = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    criadoEm = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entregadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    veiculo = table.Column<string>(type: "TEXT", nullable: false),
                    disponivel = table.Column<string>(type: "TEXT", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    Aviso = table.Column<string>(type: "TEXT", nullable: false),
                    DataAtualizada = table.Column<string>(type: "TEXT", nullable: true),
                    PedidosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    produtoIdProduto = table.Column<int>(type: "INTEGER", nullable: true),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEntregador = table.Column<int>(type: "INTEGER", nullable: true),
                    TaxaEntrega = table.Column<decimal>(type: "TEXT", nullable: false),
                    pagamento = table.Column<string>(type: "TEXT", nullable: false),
                    criadoEm = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Entregadores_IdEntregador",
                        column: x => x.IdEntregador,
                        principalTable: "Entregadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Produtos_produtoIdProduto",
                        column: x => x.produtoIdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto");
                });

            migrationBuilder.CreateTable(
                name: "Vendidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEntregador = table.Column<int>(type: "INTEGER", nullable: false),
                    EntregadorId = table.Column<int>(type: "INTEGER", nullable: true),
                    precoUnitario = table.Column<decimal>(type: "TEXT", nullable: false),
                    Observação = table.Column<string>(type: "TEXT", nullable: false),
                    Qtd = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecoSubTotal = table.Column<decimal>(type: "TEXT", nullable: false, computedColumnSql: "[Qtd] * [precoUnitario]")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendidos_Entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendidos_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendidos_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Email",
                table: "Clientes",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Nome",
                table: "Clientes",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Telefone",
                table: "Clientes",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Email",
                table: "Contas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_IdCliente",
                table: "Contas",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Nome",
                table: "Contas",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_Senha",
                table: "Contas",
                column: "Senha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_Nome",
                table: "Entregadores",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_PedidosId",
                table: "Entregadores",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregadores_Telefone",
                table: "Entregadores",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdCliente",
                table: "Pedidos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdEntregador",
                table: "Pedidos",
                column: "IdEntregador");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_produtoIdProduto",
                table: "Pedidos",
                column: "produtoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Nome",
                table: "Produtos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_EntregadorId",
                table: "Vendidos",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_IdPedido",
                table: "Vendidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_Vendidos_IdProduto",
                table: "Vendidos",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregadores_Pedidos_PedidosId",
                table: "Entregadores",
                column: "PedidosId",
                principalTable: "Pedidos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_IdCliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Entregadores_Pedidos_PedidosId",
                table: "Entregadores");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Vendidos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Entregadores");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
