using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPizza.Migrations
{
    /// <inheritdoc />
    public partial class v1102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoSubTotal",
                table: "Vendidos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldComputedColumnSql: "[Qtd] * [precoUnitario]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoSubTotal",
                table: "Vendidos",
                type: "TEXT",
                nullable: false,
                computedColumnSql: "[Qtd] * [precoUnitario]",
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
