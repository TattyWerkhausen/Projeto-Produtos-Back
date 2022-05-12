using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Projeto.Bebidas.Domain.Acrescento;
using Projeto.Bebidas.Domain.Bebida;
using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Domain.Distribuidor;
using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Funcionario;
using Projeto.Bebidas.Domain.Mls;
using Projeto.Bebidas.Domain.PedidoBebida;
using Projeto.Bebidas.Domain.Pedidos;
using Projeto.Bebidas.Domain.Sabor;
using Projeto.Bebidas.Repository.FluentApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Context
{
    public class BancoDb:DbContext
    {
            public DbSet<BebidaModel> Bebidas { get; set; }
            public DbSet<FuncionarioModel> Funcionarios { get; set; }
            public DbSet<ClienteModel> Clientes { get; set; }
            public DbSet<DistribuidorModel> Distribuidores { get; set; }
            public DbSet<SaborModel> Sabores { get; set; }
            public DbSet<AcrescentoModel> Acrescentos { get; set; }
            public DbSet<MlModel> Mls { get; set; }
            public DbSet<PedidoModel> Pedidos { get; set; }
            public DbSet<PedidoBebidaModel> PedidoBebida { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfiguration(new BebidaFA());
                modelBuilder.ApplyConfiguration(new FuncionarioFA());
                modelBuilder.ApplyConfiguration(new ClienteFA());
                modelBuilder.ApplyConfiguration(new DistribuidorFA());
                modelBuilder.ApplyConfiguration(new SaborFA());
                modelBuilder.ApplyConfiguration(new AcrescentoFA());
                modelBuilder.ApplyConfiguration(new MlFA());
                modelBuilder.ApplyConfiguration(new PedidoFA());
                modelBuilder.ApplyConfiguration(new PedidoBebidaFA());
                //   modelBuilder.ApplyConfiguration(new EnderecoFA());
                base.OnModelCreating(modelBuilder);
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();

                optionsBuilder
                    .EnableSensitiveDataLogging(true)
                    .UseNpgsql(config.GetConnectionString("DefaultConnection"));
                base.OnConfiguring(optionsBuilder);
            }
    }
}
