using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Distribuidor;
using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Repository.Distribuidores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuidorController : ControllerBase
    {
        private readonly DistribuidorRepository _distribuidorRepository;
        private readonly IMapper _mapper;
        public DistribuidorController(DistribuidorRepository distribuidorRepository, IMapper mapper)
        {
            _distribuidorRepository = distribuidorRepository;
            _mapper = mapper;
        }
        [HttpPost("cadastrarDistribuidor")]
        public async Task<IActionResult> CadastrarDistribuidor([FromBody] DistribuidorViewModel distribuidorVM)
        {
            distribuidorVM.Id = Guid.NewGuid();
            var distribuidor = _mapper.Map<DistribuidorModel>(distribuidorVM);
            await _distribuidorRepository.RegistrarDistribuidorAsync(distribuidor);
            return Ok();
        }
        [HttpGet("buscarTodosDistribuidores")]
        public async Task<IActionResult> BuscarTodosDistribuidores()
        {
            var distribuidores = await _distribuidorRepository.BuscarTodosDistribuidorsAsync();
            var distribuidorVm = _mapper.Map<List<DistribuidorViewModel>>(distribuidores);
            return Ok(distribuidorVm);
        }
        [HttpGet("buscarDistribuidorId/{id}")]
        public async Task<IActionResult> BuscarDistribuidorId(string id)
        {
            var guidValido = Guid.TryParse(id, out Guid idGuid);
            if (!guidValido)
                return Ok(null); 

            var distribuidor = await _distribuidorRepository.BuscarDistribuidorIdAsync(idGuid);
            var distribuidorVM = _mapper.Map<DistribuidorViewModel>(distribuidor);
            return Ok(distribuidorVM);
        }
        [HttpGet("buscarDistribuidorChave/{chave}")]
        public async Task<IActionResult> BuscarDistribuidorChave(string chave)
        {
            var distribuidor = await _distribuidorRepository.BuscarDistribuidorChaveAsync(chave);
            var distribuidorVM = _mapper.Map<DistribuidorViewModel>(distribuidor);
            return Ok(distribuidorVM);
        }
        [HttpGet("buscarDistribuidorNome/{nome}")]
        public async Task<IActionResult> BuscarDistribuidorNome(string nome)
        {
            var distribuidor = await _distribuidorRepository.BuscarDistribuidorNomeAsync(nome);
            var distribuidorVM = _mapper.Map<DistribuidorViewModel>(distribuidor);
            return Ok(distribuidorVM);
        }
        [HttpPut("editarDistribuidor/{id}")]
        public async Task<IActionResult> EditarDistribuidor(Guid id, [FromBody] DistribuidorViewModel distribuidorVM)
        {
            var distribuidor = await _distribuidorRepository.BuscarDistribuidorIdAsync(id);
            var endereco = _mapper.Map<EnderecoDistribuidor>(distribuidorVM.EnderecoModel);
            distribuidor.Editar(distribuidorVM.Nome, distribuidorVM.ChaveAcesso, distribuidorVM.Cnpj, distribuidorVM.Email, distribuidorVM.Telefone, endereco);
            await _distribuidorRepository.EditarDistribuidorAsync(distribuidor);
            return Ok();
        }
        [HttpPut("editarDistribuidorNome/{nome}")]
        public async Task<IActionResult> EditarDistribuidorNome(string nome, [FromBody] DistribuidorViewModel distribuidorVM)
        {
            var distribuidor = await _distribuidorRepository.BuscarDistribuidorNomeAsync(nome);
            var endereco = _mapper.Map<EnderecoDistribuidor>(distribuidorVM.EnderecoModel);
            distribuidor.Editar(distribuidorVM.Nome, distribuidorVM.ChaveAcesso, distribuidorVM.Cnpj, distribuidorVM.Email, distribuidorVM.Telefone, endereco);
            await _distribuidorRepository.EditarDistribuidorAsync(distribuidor);
            return Ok();
        }
        [HttpDelete("excluirDistribuidor/{id}")]
        public async Task<IActionResult> ExcluirDistribuidor(Guid id)
        {
            var distribuidorExcluir = await _distribuidorRepository.BuscarDistribuidorIdAsync(id);
            var erros = new List<string>();

            if (distribuidorExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _distribuidorRepository.ExcluirDistribuidorAsync(id);
            return Ok(distribuidorExcluir);
        }
        [HttpDelete("excluirDistribuidorNome/{nome}")]
        public async Task<IActionResult> ExcluirDistribuidorNome(string nome)
        {
            var distribuidorExcluir = await _distribuidorRepository.BuscarDistribuidorNomeAsync(nome);
            var erros = new List<string>();

            if (distribuidorExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _distribuidorRepository.ExcluirDistribuidorNomeAsync(nome);
            return Ok(distribuidorExcluir);
        }
    }
}
