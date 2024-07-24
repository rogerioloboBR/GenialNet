using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutoFornecedorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjustePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorCompra",
                table: "ProdutosFornecedores",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorCompra",
                table: "ProdutosFornecedores",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
