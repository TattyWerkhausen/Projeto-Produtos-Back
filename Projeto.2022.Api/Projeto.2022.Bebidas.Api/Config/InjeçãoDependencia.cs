using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projeto._2022.Bebidas.Api.Config.AutoMapper;
using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Repository.Acrescentos;
using Projeto.Bebidas.Repository.Bebidas;
using Projeto.Bebidas.Repository.Clientes;
using Projeto.Bebidas.Repository.Context;
using Projeto.Bebidas.Repository.Distribuidores;
using Projeto.Bebidas.Repository.Funcionarios;
using Projeto.Bebidas.Repository.Mls;
using Projeto.Bebidas.Repository.PedidosRepository;
using Projeto.Bebidas.Repository.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Config
{
    public static class InjeçãoDependencia
    {
    public static IServiceCollection AddInjecaoDependencia(this IServiceCollection services)
        {
            // services.AddDbContext<DbContext>();
            services.AddAutoMapper(typeof(DominioParaViewModel), typeof(ViewModelParaDominio));
            services.AddDbContext<BancoDb>();
            services.AddScoped<BebidaRepository>();
            services.AddScoped<FuncionarioRepository>();
            services.AddScoped<ClienteRepository>();
            services.AddScoped<DistribuidorRepository>();
            services.AddScoped<SaborRepository>();
            services.AddScoped<AcrescentoRepository>();
            services.AddScoped<MlRepository>();
            services.AddScoped<EnderecoModelBase>();
            services.AddScoped<PedidoRepository>();
            return services;
        }
    }
}
