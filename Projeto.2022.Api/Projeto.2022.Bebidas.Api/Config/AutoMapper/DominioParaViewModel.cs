using AutoMapper;
using Projeto._2022.Bebidas.Api.ViewModels;
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
using Projeto.Bebidas.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Config.AutoMapper
{
    public class DominioParaViewModel : Profile
    {
        public DominioParaViewModel()
        {
            CreateMap<BebidaModel, BebidaViewModel>();
            CreateMap<FuncionarioModel, FuncionarioViewModel>();
            CreateMap<ClienteModel, ClienteViewModel>();
            CreateMap<DistribuidorModel, DistribuidorViewModel>();
            CreateMap<SaborModel, SaborViewModel>();
            CreateMap<AcrescentoModel, AcrescentosViewModel>();
            CreateMap<MlModel, MlViewModel>();
            CreateMap<EnderecoModelBase, EnderecoViewModel>();
            CreateMap<PedidoModel, PedidoViewModel>();
            CreateMap<PedidoBebidaModel, PedidoBebidaViewModel>();
        }
    }
}
