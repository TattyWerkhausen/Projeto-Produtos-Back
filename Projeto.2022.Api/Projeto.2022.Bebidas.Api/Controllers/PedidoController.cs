using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Domain.PedidoBebida;
using Projeto.Bebidas.Domain.Pedidos;
using Projeto.Bebidas.Repository.Clientes;
using Projeto.Bebidas.Repository.PedidosRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoRepository _pedidoRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public PedidoController(PedidoRepository pedidoRepository, IMapper mapper, ClienteRepository clienteRepository)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }
        [HttpPost("cadastrarPedido")]
        public async Task <IActionResult> CadastrarPedido([FromBody]PedidoViewModel pedidoVM)
        {
            pedidoVM.Id = Guid.NewGuid();
            var pedido = _mapper.Map<PedidoModel>(pedidoVM);
            await _pedidoRepository.CadastrarPedidoAsync(pedido);
            return Ok();
        }
        [HttpGet("buscarTodosPedidos")]
        public async Task<IActionResult> BuscarTodosPedidos()
        {
            var pedidos = await _pedidoRepository.BuscarTodosPedidosAsync();
            var pedidoVm = _mapper.Map<List<PedidoViewModel>>(pedidos);
            return Ok(pedidoVm);
        }
        [HttpGet("buscarPedidoId/{id}")]
        public async Task<IActionResult> BuscarPedidoId(string id)
        {
            var guidValido = Guid.TryParse(id, out Guid idGuid);
            if (!guidValido)
                return Ok(null);
            var pedido = await _pedidoRepository.BuscarPedidoIdAsync(idGuid);
            var pedidoVm = _mapper.Map<PedidoViewModel>(pedido);
            return Ok(pedidoVm);
        }
        [HttpGet("buscarPedidoNomeCliente/{nome}")]
        public async Task<IActionResult> BuscarPedidoNomeCliente(string nome)
        {
            var pedido = await _pedidoRepository.BuscarPedidoClienteAsync(nome);
            var pedidoVm = _mapper.Map<PedidoViewModel>(pedido);
            return Ok(pedidoVm);
        }
        [HttpGet("buscarPedidoData/{data}")]
        public async Task<IActionResult> BuscarPedidoData(DateTime data)
        {
            var pedido = await _pedidoRepository.BuscarPedidoDataAsync(data);
            var pedidoVm = _mapper.Map<PedidoViewModel>(pedido);
            return Ok(pedidoVm);
        }
        [HttpPut("editarPedidoId/{id}")]
        public async Task<IActionResult> EditarPedidoId(Guid id, PedidoViewModel pedidoViewModel)
        {
            var pedidoId = await _pedidoRepository.BuscarPedidoIdAsync(id);
            var endereco = _mapper.Map<PedidoEnderecoModel>(pedidoViewModel.EnderecoPedido);
            var pedidoBebida = _mapper.Map<List<PedidoBebidaModel>>(pedidoViewModel.ListaPedidoBebida);
            pedidoId.Editar(pedidoViewModel.ClienteId, endereco, pedidoBebida, pedidoViewModel.Data, pedidoViewModel.ValorTotal) ;
            await _pedidoRepository.EditarPedidoAsync(pedidoId);
            return Ok();
        }
        [HttpPut("editarPedidoCliente/{clienteId}")]
        public async Task<IActionResult> EditarPedidoPorCliente(string nomeCliente, PedidoViewModel pedidoViewModel)
        {
            var clienteBuscar = await _pedidoRepository.BuscarPedidoClienteAsync(nomeCliente);
            var endereco = _mapper.Map<PedidoEnderecoModel>(pedidoViewModel.EnderecoPedido);
            var pedidoBebida = _mapper.Map<List<PedidoBebidaModel>>(pedidoViewModel.ListaPedidoBebida);
            clienteBuscar.Editar(pedidoViewModel.ClienteId, endereco, pedidoBebida, pedidoViewModel.Data, pedidoViewModel.ValorTotal);
            await _pedidoRepository.EditarPedidoAsync(clienteBuscar);
            return Ok();
        }
        [HttpPut("editarPedidoData/{data}")]
        public async Task<IActionResult> EditarPedidoPorData(DateTime data, PedidoViewModel pedidoViewModel)
        {
            var dataBuscar = await _pedidoRepository.BuscarPedidoDataAsync(data);
            var endereco = _mapper.Map<PedidoEnderecoModel>(pedidoViewModel.EnderecoPedido);
            var pedidoBebida = _mapper.Map<List<PedidoBebidaModel>>(pedidoViewModel.ListaPedidoBebida);
            dataBuscar.Editar(pedidoViewModel.ClienteId, endereco, pedidoBebida, pedidoViewModel.Data, pedidoViewModel.ValorTotal);
            await _pedidoRepository.EditarPedidoAsync(dataBuscar);
            return Ok();
        }
        [HttpDelete("excluirPedido/{id}")]
        public async Task<IActionResult> ExcluirPedido(Guid id)
        {
            var pedido = await _pedidoRepository.BuscarPedidoIdAsync(id);
            await _pedidoRepository.ExcluirPedidoIdAsyn(id);
            return Ok(pedido);
        }
        [HttpDelete("excluirPedidoData/{data}")]
        public async Task<IActionResult> ExcluirPedidoData(DateTime data)
        {
            var pedido = await _pedidoRepository.BuscarPedidoDataAsync(data);
            await _pedidoRepository.ExcluirPedidoDataAsyn(data);
            return Ok(pedido);
        }
        [HttpDelete("excluirPedidoNomeCliente/{nome}")]
        public async Task<IActionResult> ExcluirPedidoNomeCliente(string nome)
        {
            var pedido = await _pedidoRepository.BuscarPedidoClienteAsync(nome);
            await _pedidoRepository.ExcluirPedidoNomeClienteAsyn(nome);
            return Ok(pedido);
        }
    }
}
