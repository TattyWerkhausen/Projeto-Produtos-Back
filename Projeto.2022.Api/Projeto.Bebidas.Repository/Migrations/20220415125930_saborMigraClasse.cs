using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Bebidas.Repository.Migrations
{
    public partial class saborMigraClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SaborId",
                table: "PedidoBebida",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SaborModelId",
                table: "PedidoBebida",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PedidoBebida_SaborModelId",
                table: "PedidoBebida",
                column: "SaborModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoBebida_Sabores_SaborModelId",
                table: "PedidoBebida",
                column: "SaborModelId",
                principalTable: "Sabores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoBebida_Sabores_SaborModelId",
                table: "PedidoBebida");

            migrationBuilder.DropIndex(
                name: "IX_PedidoBebida_SaborModelId",
                table: "PedidoBebida");

            migrationBuilder.DropColumn(
                name: "SaborId",
                table: "PedidoBebida");

            migrationBuilder.DropColumn(
                name: "SaborModelId",
                table: "PedidoBebida");
        }
    }
}
