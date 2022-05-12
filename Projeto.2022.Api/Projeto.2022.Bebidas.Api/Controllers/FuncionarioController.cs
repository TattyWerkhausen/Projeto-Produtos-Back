using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Distribuidor;
using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Funcionario;
using Projeto.Bebidas.Repository.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;
        public FuncionarioController(FuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }
        [HttpPost("registrarFuncionario")]
        public async Task<IActionResult> RegistrarFuncionario([FromBody] FuncionarioViewModel funcionarioVM)
        {
            funcionarioVM.Id = Guid.NewGuid();
            var funcionario = _mapper.Map<FuncionarioModel>(funcionarioVM);
            await _funcionarioRepository.RegistrarFuncionarioAsync(funcionario);
            return Ok();
        }
        [HttpGet("buscarFuncionario/{id}")]
        public async Task<IActionResult> BuscarFuncionarioId(string id)
        {
            //converte o Guid em string
            
            var guidValido = Guid.TryParse(id, out Guid idGuid);
            if (!guidValido)
                return Ok(null);
            var funcionarioId = await _funcionarioRepository.BuscarFuncionarioIdAsync(idGuid);
            var funcionarioVM = _mapper.Map<FuncionarioViewModel>(funcionarioId);
            return Ok(funcionarioVM);
        }
        [HttpGet("funcionarioChaveAcesso/{chaveAcesso}")]
        public async Task<IActionResult> BuscarFuncionarioChaveAcesso(string chaveAcesso)
        {
                var funcionarioChave = await _funcionarioRepository.FuncionarioChaveAcessoAsync(chaveAcesso);
                var funcionarioVM = _mapper.Map<FuncionarioViewModel>(funcionarioChave);
                return Ok(funcionarioVM);
            
        }
        [HttpGet("buscarFuncionarioNome/{nome}")]
        public async Task<IActionResult> BuscarFuncionarioNome(string nome)
        {
            var funcionario = await _funcionarioRepository.BuscarFuncionarioNomeAsync(nome);
            var funcionarioVM = _mapper.Map<FuncionarioViewModel>(funcionario);
            return Ok(funcionarioVM);
        }
        [HttpGet("buscarTodosFuncionarios")]
        public async Task<IActionResult> BuscarTodosFuncionarios()
        {
            var funcionarios = await _funcionarioRepository.BuscarTodosFuncionariosAsync();
            var funcionarioVM = _mapper.Map<List<FuncionarioViewModel>>(funcionarios);
            return Ok(funcionarioVM);
        }
        [HttpPut("editarFuncionario/{id}")]
        public async Task<IActionResult> EditarFuncionario(Guid id, [FromBody] FuncionarioViewModel funcionarioVM)
        {
            var funcionarioEditar = await _funcionarioRepository.BuscarFuncionarioIdAsync(id);
            var endereco = _mapper.Map<EnderecoFuncionario>(funcionarioVM.EnderecoModel);
            funcionarioEditar.Editar(funcionarioVM.Nome,funcionarioVM.ChaveAcesso, funcionarioVM.Sobrenome, funcionarioVM.Email, funcionarioVM.Telefone, funcionarioVM.Cpf, funcionarioVM.DataNascimento, endereco);
            await _funcionarioRepository.EditarFuncionarioAsync(funcionarioEditar);
            return Ok();
        }
        [HttpPut("editarFuncionarioNome/{nome}")]
        public async Task<IActionResult> EditarFuncionarioNome(string nome, [FromBody] FuncionarioViewModel funcionarioVM)
        {
            var funcionarioEditar = await _funcionarioRepository.BuscarFuncionarioNomeAsync(nome);
            var endereco = _mapper.Map<EnderecoFuncionario>(funcionarioVM.EnderecoModel);
            funcionarioEditar.Editar(funcionarioVM.Nome, funcionarioVM.ChaveAcesso, funcionarioVM.Sobrenome, funcionarioVM.Email, funcionarioVM.Telefone, funcionarioVM.Cpf, funcionarioVM.DataNascimento, endereco);
            await _funcionarioRepository.EditarFuncionarioAsync(funcionarioEditar);
            return Ok();
        }
        [HttpDelete("excluirFuncionario/{id}")]
        public async Task<IActionResult> ExcluirFuncionario(Guid id)
        {
            var FuncionarioExcluir = await _funcionarioRepository.BuscarFuncionarioIdAsync(id);
            var erros = new List<string>();

            if (FuncionarioExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _funcionarioRepository.ExcluirFuncionarioAsync(id);
            return Ok(FuncionarioExcluir);
        }
        [HttpDelete("excluirFuncionarioNome/{nome}")]
        public async Task<IActionResult> ExcluirFuncionarioNome(string nome)
        {
            var FuncionarioExcluir = await _funcionarioRepository.BuscarFuncionarioNomeAsync(nome);
            var erros = new List<string>();

            if (FuncionarioExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _funcionarioRepository.ExcluirFuncionarioNomeAsync(nome);
            return Ok(FuncionarioExcluir);
        }
    }
}
