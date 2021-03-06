// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Projeto.Bebidas.Repository.Context;

namespace Projeto.Bebidas.Repository.Migrations
{
    [DbContext(typeof(BancoDb))]
    [Migration("20220415125930_saborMigraClasse")]
    partial class saborMigraClasse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Projeto.Bebidas.Domain.Acrescento.AcrescentoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Gramagem")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<double>("ValorCusto")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorVenda")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Acrescentos");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Bebida.BebidaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<double>("TeorAlcoolico")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorCusto")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorVenda")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Bebidas");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Cliente.ClienteModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ChaveAcesso")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Distribuidor.DistribuidorModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ChaveAcesso")
                        .HasColumnType("text");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Distribuidores");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Funcionario.FuncionarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ChaveAcesso")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Mls.MlModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Ml")
                        .HasColumnType("integer");

                    b.Property<double>("ValorCusto")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorVenda")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Mls");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.PedidoBebida.PedidoBebidaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AcrescentoId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AcrescentoModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BebidaId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BebidaModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MlId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MlModelId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SaborId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SaborModelId")
                        .HasColumnType("uuid");

                    b.Property<double>("ValorSubTotal")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AcrescentoModelId");

                    b.HasIndex("BebidaModelId");

                    b.HasIndex("MlModelId");

                    b.HasIndex("PedidoId");

                    b.HasIndex("SaborModelId");

                    b.ToTable("PedidoBebida");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Pedidos.PedidoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClienteModelId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ClienteModelId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Sabor.SaborModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<double>("ValorCusto")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorVenda")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Sabores");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Cliente.ClienteModel", b =>
                {
                    b.OwnsOne("Projeto.Bebidas.Domain.Cliente.ClienteEndereco", "EnderecoModel", b1 =>
                        {
                            b1.Property<Guid>("ClienteModelId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Bairro")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cep")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cidade")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Complemento")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<int>("Numero")
                                .HasColumnType("integer")
                                .HasMaxLength(100);

                            b1.Property<string>("Rua")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Uf")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.HasKey("ClienteModelId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteModelId");
                        });
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Distribuidor.DistribuidorModel", b =>
                {
                    b.OwnsOne("Projeto.Bebidas.Domain.Distribuidor.EnderecoDistribuidor", "EnderecoModel", b1 =>
                        {
                            b1.Property<Guid>("DistribuidorModelId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Bairro")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cep")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cidade")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Complemento")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<int>("Numero")
                                .HasColumnType("integer")
                                .HasMaxLength(100);

                            b1.Property<string>("Rua")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Uf")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.HasKey("DistribuidorModelId");

                            b1.ToTable("Distribuidores");

                            b1.WithOwner()
                                .HasForeignKey("DistribuidorModelId");
                        });
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Funcionario.FuncionarioModel", b =>
                {
                    b.OwnsOne("Projeto.Bebidas.Domain.Funcionario.EnderecoFuncionario", "EnderecoModel", b1 =>
                        {
                            b1.Property<Guid>("FuncionarioModelId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Bairro")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cep")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cidade")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Complemento")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<int>("Numero")
                                .HasColumnType("integer")
                                .HasMaxLength(100);

                            b1.Property<string>("Rua")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Uf")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.HasKey("FuncionarioModelId");

                            b1.ToTable("Funcionarios");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioModelId");
                        });
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.PedidoBebida.PedidoBebidaModel", b =>
                {
                    b.HasOne("Projeto.Bebidas.Domain.Acrescento.AcrescentoModel", "AcrescentoModel")
                        .WithMany()
                        .HasForeignKey("AcrescentoModelId");

                    b.HasOne("Projeto.Bebidas.Domain.Bebida.BebidaModel", "BebidaModel")
                        .WithMany("PedidosBebidasModel")
                        .HasForeignKey("BebidaModelId");

                    b.HasOne("Projeto.Bebidas.Domain.Mls.MlModel", "MlModel")
                        .WithMany()
                        .HasForeignKey("MlModelId");

                    b.HasOne("Projeto.Bebidas.Domain.Pedidos.PedidoModel", "PedidoModel")
                        .WithMany("ListaPedidoBebida")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.Bebidas.Domain.Sabor.SaborModel", "SaborModel")
                        .WithMany()
                        .HasForeignKey("SaborModelId");
                });

            modelBuilder.Entity("Projeto.Bebidas.Domain.Pedidos.PedidoModel", b =>
                {
                    b.HasOne("Projeto.Bebidas.Domain.Cliente.ClienteModel", "ClienteModel")
                        .WithMany("ListaPedidos")
                        .HasForeignKey("ClienteModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Projeto.Bebidas.Domain.Pedidos.PedidoEnderecoModel", "PedidoEndereco", b1 =>
                        {
                            b1.Property<Guid>("PedidoModelId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Bairro")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cep")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Cidade")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Complemento")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<int>("Numero")
                                .HasColumnType("integer")
                                .HasMaxLength(100);

                            b1.Property<string>("Rua")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.Property<string>("Uf")
                                .HasColumnType("character varying(100)")
                                .HasMaxLength(100);

                            b1.HasKey("PedidoModelId");

                            b1.ToTable("Pedidos");

                            b1.WithOwner()
                                .HasForeignKey("PedidoModelId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
