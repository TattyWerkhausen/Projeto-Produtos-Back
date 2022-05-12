using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Bebidas.Repository.Migrations
{
    public partial class atualizacaoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acrescentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    ValorCusto = table.Column<double>(nullable: false),
                    ValorVenda = table.Column<double>(nullable: false),
                    Gramagem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acrescentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 10, nullable: false),
                    TeorAlcoolico = table.Column<double>(nullable: false),
                    ValorCusto = table.Column<double>(nullable: false),
                    ValorVenda = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 10, nullable: false),
                    ChaveAcesso = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EnderecoModel_Uf = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Cep = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Rua = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Numero = table.Column<int>(maxLength: 100, nullable: true),
                    EnderecoModel_Complemento = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distribuidores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    ChaveAcesso = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    EnderecoModel_Uf = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Cep = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Rua = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Numero = table.Column<int>(maxLength: 100, nullable: true),
                    EnderecoModel_Complemento = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 10, nullable: false),
                    ChaveAcesso = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Cpf = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EnderecoModel_Uf = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Cep = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Rua = table.Column<string>(maxLength: 100, nullable: true),
                    EnderecoModel_Numero = table.Column<int>(maxLength: 100, nullable: true),
                    EnderecoModel_Complemento = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ml = table.Column<int>(nullable: false),
                    ValorCusto = table.Column<double>(nullable: false),
                    ValorVenda = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sabores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    ValorCusto = table.Column<double>(nullable: false),
                    ValorVenda = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClienteModelId = table.Column<Guid>(nullable: false),
                    PedidoEndereco_Uf = table.Column<string>(maxLength: 100, nullable: true),
                    PedidoEndereco_Cep = table.Column<string>(maxLength: 100, nullable: true),
                    PedidoEndereco_Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    PedidoEndereco_Bairro = table.Column<string>(maxLength: 100, nullable: true),
                    PedidoEndereco_Rua = table.Column<string>(maxLength: 100, nullable: true),
                    PedidoEndereco_Numero = table.Column<int>(maxLength: 100, nullable: true),
                    PedidoEndereco_Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteModelId",
                        column: x => x.ClienteModelId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoBebida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BebidaModelId = table.Column<Guid>(nullable: true),
                    BebidaId = table.Column<Guid>(nullable: false),
                    MlModelId = table.Column<Guid>(nullable: true),
                    MlId = table.Column<Guid>(nullable: false),
                    AcrescentoModelId = table.Column<Guid>(nullable: true),
                    AcrescentoId = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false),
                    ValorSubTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoBebida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoBebida_Acrescentos_AcrescentoModelId",
                        column: x => x.AcrescentoModelId,
                        principalTable: "Acrescentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoBebida_Bebidas_BebidaModelId",
                        column: x => x.BebidaModelId,
                        principalTable: "Bebidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoBebida_Mls_MlModelId",
                        column: x => x.MlModelId,
                        principalTable: "Mls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoBebida_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebida_AcrescentoModelId",
                table: "PedidoBebida",
                column: "AcrescentoModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebida_BebidaModelId",
                table: "PedidoBebida",
                column: "BebidaModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebida_MlModelId",
                table: "PedidoBebida",
                column: "MlModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebida_PedidoId",
                table: "PedidoBebida",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteModelId",
                table: "Pedidos",
                column: "ClienteModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distribuidores");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "PedidoBebida");

            migrationBuilder.DropTable(
                name: "Sabores");

            migrationBuilder.DropTable(
                name: "Acrescentos");

            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Mls");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
