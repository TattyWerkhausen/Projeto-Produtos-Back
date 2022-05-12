using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Repository.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteController(ClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        [HttpPost("cadastrarCliente")]
        public async Task<IActionResult> CadastrarCliente([FromBody] ClienteViewModel clienteVM)
        {
            clienteVM.Id = Guid.NewGuid();
            var cliente = _mapper.Map<ClienteModel>(clienteVM);
            await _clienteRepository.RegistrarClienteAsync(cliente);
            return Ok();
        }
        [HttpGet("buscarTodosClientes")]
        public async Task<IActionResult> BuscarTodosClientes()
        {
            var clientes = await _clienteRepository.BuscarTodosClientesAsync();
            var clienteVm = _mapper.Map<List<ClienteViewModel>>(clientes);
            return Ok(clienteVm);
        }
        [HttpGet("buscarClienteId/{id}")]
        public async Task<IActionResult> BuscarClienteId(string id)
        {
            var guidValido = Guid.TryParse(id, out Guid idGuid);
            if (!guidValido)
                return Ok(null);

            var cliente = await _clienteRepository.BuscarClienteIdAsync(idGuid);
            var clienteVM = _mapper.Map<ClienteViewModel>(cliente);
            return Ok(clienteVM);
        }
        [HttpGet("buscarClienteChave/{chave}")]
        public async Task<IActionResult> BuscarClienteChave(string chave)
        {
            try
            {
                var cliente = await _clienteRepository.BuscarClienteChaveAsync(chave);
                var clienteVM = _mapper.Map<ClienteViewModel>(cliente);
                return Ok(clienteVM);
            }catch (Exception e)
            {
                throw e;
            }
           
        }
        [HttpGet("buscarClienteNome/{nome}")]
        public async Task<IActionResult> BuscarClienteNome(string nome)
        {
            var cliente = await _clienteRepository.BuscarClienteNomeAsync(nome);
            var clienteVM = _mapper.Map<ClienteViewModel>(cliente);
            return Ok(clienteVM);
        }
        [HttpPut("editarCliente/{id}")]
        public async Task<IActionResult> EditarCliente(Guid id, [FromBody] ClienteViewModel clienteVM)
        {
            var cliente = await _clienteRepository.BuscarClienteIdAsync(id);
            var endereco = _mapper.Map<ClienteEndereco>(clienteVM.EnderecoModel);
            cliente.Editar(clienteVM.Nome, clienteVM.ChaveAcesso, clienteVM.Sobrenome, clienteVM.Email, clienteVM.Telefone, clienteVM.Cpf, clienteVM.DataNascimento, endereco, clienteVM.ListaPedidos);
            await _clienteRepository.EditarClienteAsync(cliente);
            return Ok();
        }
        [HttpPut("editarClienteNome/{nome}")]
        public async Task<IActionResult> EditarClienteNome(string nome, [FromBody] ClienteViewModel clienteVM)
        {
            var cliente = await _clienteRepository.BuscarClienteNomeAsync(nome);
            var endereco = _mapper.Map<ClienteEndereco>(clienteVM.EnderecoModel);
            cliente.Editar(clienteVM.Nome, clienteVM.ChaveAcesso, clienteVM.Sobrenome, clienteVM.Email, clienteVM.Telefone, clienteVM.Cpf, clienteVM.DataNascimento, endereco, clienteVM.ListaPedidos);
            await _clienteRepository.EditarClienteAsync(cliente);
            return Ok();
        }
        [HttpPut("atualizarDadosClienteChave/{chave}")]
        public async Task<IActionResult> AtualizarDadosClienteChave(string chave, [FromBody] ClienteViewModel clienteVM)
        {
            var cliente = await _clienteRepository.BuscarClienteChaveAsync(chave);
            var endereco = _mapper.Map<ClienteEndereco>(clienteVM.EnderecoModel);
            cliente.Editar(clienteVM.Nome, clienteVM.ChaveAcesso, clienteVM.Sobrenome, clienteVM.Email, clienteVM.Telefone, clienteVM.Cpf, clienteVM.DataNascimento, endereco, clienteVM.ListaPedidos);
            await _clienteRepository.EditarClienteAsync(cliente);
            return Ok();
        }
        [HttpDelete("excluirCliente/{id}")]
        public async Task<IActionResult> ExcluirCliente(Guid id)
        {
            var clienteExcluir = await _clienteRepository.BuscarClienteIdAsync(id);
            var erros = new List<string>();

            if (clienteExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _clienteRepository.ExcluirClienteAsync(id);
            return Ok(clienteExcluir);
        }
        [HttpDelete("excluirClienteNome/{nome}")]
        public async Task<IActionResult> ExcluirClienteNome(string nome)
        {
            var clienteExcluir = await _clienteRepository.BuscarClienteNomeAsync(nome);
            var erros = new List<string>();

            if (clienteExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _clienteRepository.ExcluirClienteNomeAsync(nome);
            return Ok(clienteExcluir);
        }
    }
}
