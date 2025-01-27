using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleErpApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateSimpleErpBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    documento_identificador = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notas_fiscais_status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas_fiscais_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notas_fiscais_tipos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas_fiscais_tipos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notas_fiscais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero_documento = table.Column<int>(type: "int", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    tipo_id = table.Column<int>(type: "int", nullable: false),
                    cliente_id = table.Column<int>(type: "int", nullable: false),
                    data_emissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    icms = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ipi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cofins = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas_fiscais", x => x.id);
                    table.ForeignKey(
                        name: "FK_notas_fiscais_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notas_fiscais_notas_fiscais_status_status_id",
                        column: x => x.status_id,
                        principalTable: "notas_fiscais_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notas_fiscais_notas_fiscais_tipos_tipo_id",
                        column: x => x.tipo_id,
                        principalTable: "notas_fiscais_tipos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notas_fiscais_produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota_fiscal_id = table.Column<int>(type: "int", nullable: false),
                    produto_id = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    valor_unitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    valor_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas_fiscais_produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_notas_fiscais_produtos_notas_fiscais_nota_fiscal_id",
                        column: x => x.nota_fiscal_id,
                        principalTable: "notas_fiscais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notas_fiscais_produtos_produtos_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "notas_fiscais_status",
                columns: new[] { "id", "descricao", "nome" },
                values: new object[,]
                {
                    { 1, "Rascunho da nota fiscal (Ainda pode ser alterado e excluido)", "RASCUNHO" },
                    { 2, "Nota fiscal lançada (Não pode mais ser alterada ou excluida)", "LANÇADA" }
                });

            migrationBuilder.InsertData(
                table: "notas_fiscais_tipos",
                columns: new[] { "id", "descricao", "nome" },
                values: new object[,]
                {
                    { 1, "Nota fiscal de entrada (compra)", "ENTRADA" },
                    { 2, "Nota fiscal de saída (venda)", "SAÍDA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_DocumentoIdentificacao_UNIQUE",
                table: "clientes",
                column: "documento_identificador",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notas_fiscais_cliente_id",
                table: "notas_fiscais",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_notas_fiscais_status_id",
                table: "notas_fiscais",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "IX_notas_fiscais_tipo_id",
                table: "notas_fiscais",
                column: "tipo_id");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_NumeroDocumento_UNIQUE",
                table: "notas_fiscais",
                column: "numero_documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notas_fiscais_produtos_nota_fiscal_id",
                table: "notas_fiscais_produtos",
                column: "nota_fiscal_id");

            migrationBuilder.CreateIndex(
                name: "IX_notas_fiscais_produtos_produto_id",
                table: "notas_fiscais_produtos",
                column: "produto_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notas_fiscais_produtos");

            migrationBuilder.DropTable(
                name: "notas_fiscais");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "notas_fiscais_status");

            migrationBuilder.DropTable(
                name: "notas_fiscais_tipos");
        }
    }
}
