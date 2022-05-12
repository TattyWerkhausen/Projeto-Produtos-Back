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
    public class ViewModelParaDominio : Profile
    {
        public ViewModelParaDominio()
        {
            CreateMap<EnderecoViewModel, ClienteEndereco>().ConstructUsing(enderecoVM => new ClienteEndereco(enderecoVM));
            CreateMap<EnderecoViewModel, EnderecoFuncionario>().ConstructUsing(enderecoVM => new EnderecoFuncionario(enderecoVM));
            CreateMap<EnderecoViewModel, EnderecoDistribuidor>().ConstructUsing(enderecoVM => new EnderecoDistribuidor(enderecoVM));
            CreateMap<EnderecoViewModel, PedidoEnderecoModel>().ConstructUsing(enderecoVM => new PedidoEnderecoModel(enderecoVM));

            CreateMap<BebidaViewModel, BebidaModel>().ConstructUsing(bebidaVm => new BebidaModel(bebidaVm.Id, bebidaVm.Nome, bebidaVm.TeorAlcoolico, bebidaVm.ValorCusto, bebidaVm.ValorVenda));

            CreateMap<FuncionarioViewModel, FuncionarioModel>().ConstructUsing((funcionarioVm, contexto) => new FuncionarioModel(funcionarioVm.Id, funcionarioVm.Nome, funcionarioVm.ChaveAcesso, funcionarioVm.Sobrenome,
                funcionarioVm.Email, funcionarioVm.Telefone, funcionarioVm.Cpf, funcionarioVm.DataNascimento, contexto.Mapper.Map<EnderecoFuncionario>(funcionarioVm.EnderecoModel)));


            CreateMap<ClienteViewModel, ClienteModel>().ConstructUsing((clienteVm, contexto ) => new ClienteModel(clienteVm.Id, clienteVm.Nome, clienteVm.ChaveAcesso, clienteVm.Sobrenome, clienteVm.Email, clienteVm.Telefone, clienteVm.Cpf,
                clienteVm.DataNascimento, contexto.Mapper.Map<ClienteEndereco>(clienteVm.EnderecoModel), clienteVm.ListaPedidos));


            CreateMap<DistribuidorViewModel, DistribuidorModel>().ConstructUsing((distribuidorVm, contexto) => new DistribuidorModel(distribuidorVm.Id, distribuidorVm.Nome, distribuidorVm.ChaveAcesso, distribuidorVm.Email, distribuidorVm.Telefone, distribuidorVm.Cnpj,
               contexto.Mapper.Map<EnderecoDistribuidor>(distribuidorVm.EnderecoModel)));


            CreateMap<SaborViewModel, SaborModel>().ConstructUsing(saborVm => new SaborModel(saborVm.Id, saborVm.Nome, saborVm.ValorCusto, saborVm.ValorVenda));

            CreateMap<AcrescentosViewModel, AcrescentoModel>().ConstructUsing(acrescentoVm => new AcrescentoModel(acrescentoVm.Id, acrescentoVm.Nome, acrescentoVm.ValorCusto, acrescentoVm.ValorVenda, acrescentoVm.Gramagem));

            CreateMap<MlViewModel, MlModel>().ConstructUsing(MlVm => new MlModel(MlVm.Id, MlVm.Ml, MlVm.ValorCusto, MlVm.ValorVenda));

            CreateMap<PedidoViewModel, PedidoModel>().ConstructUsing((pedidoVm, contexto) => new PedidoModel(pedidoVm.Id, pedidoVm.ClienteId, contexto.Mapper.Map<PedidoEnderecoModel>(pedidoVm.EnderecoPedido), contexto.Mapper.Map<List<PedidoBebidaModel>>(pedidoVm.ListaPedidoBebida), pedidoVm.Data, pedidoVm.ValorTotal));
            CreateMap<PedidoBebidaViewModel, PedidoBebidaModel>().ConstructUsing(pedidoBebidaVm => new PedidoBebidaModel(pedidoBebidaVm.Id, pedidoBebidaVm.BebidaId, pedidoBebidaVm.MlId, pedidoBebidaVm.AcrescentoId,pedidoBebidaVm.PedidoId, pedidoBebidaVm.ValorSubTotal, pedidoBebidaVm.SaborId));
        }
    }
}
