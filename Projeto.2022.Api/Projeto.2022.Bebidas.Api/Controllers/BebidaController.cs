using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Bebida;
using Projeto.Bebidas.Repository.Bebidas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidaController : ControllerBase
    {
        private readonly BebidaRepository _bebidaRepository;
        private readonly IMapper _mapper;
        public BebidaController(BebidaRepository bebidaRepository, IMapper mapper)
        {
            _bebidaRepository = bebidaRepository;
            _mapper = mapper;
        }
        [HttpPost("registrarBebida")]
        public async Task<IActionResult> RegistrarBebida([FromBody] BebidaViewModel bebidaVM)
        {
            bebidaVM.Id = Guid.NewGuid();
            var bebida = _mapper.Map<BebidaModel>(bebidaVM);
            await _bebidaRepository.RegistrarBebidaAsync(bebida);
            return Ok();
        }
        [HttpGet("buscarBebida/{id}")]
        public async Task<IActionResult> BuscarBebidaId(Guid id)
        {
            var bebidaId = await _bebidaRepository.BuscarBebidaIdAsync(id);
            var bebidaVM = _mapper.Map<BebidaViewModel>(bebidaId);
            return Ok(bebidaVM);
        }
        [HttpGet("buscarBebidaNome/{nome}")]
        public async Task<IActionResult> BuscarBebidaNome(string nome)
        {
            var bebida = await _bebidaRepository.BuscarBebidaNomeAsync(nome);
            var bebidaVM = _mapper.Map<BebidaViewModel>(bebida);
            return Ok(bebidaVM);
        }
        [HttpGet("buscarTodasBebidas")]
        public async Task<IActionResult> BuscarTodasBebidas()
        {
            var bebidas = await _bebidaRepository.BuscarTodasBebidasAsync();
            var bebidasVM = _mapper.Map<List<BebidaViewModel>>(bebidas);
            return Ok(bebidasVM);
        }
        [HttpPut("editarBebida/{id}")]
        public async Task<IActionResult> EditarBebida(Guid id, [FromBody] BebidaViewModel bebidaVM)
        {
            var erros = new List<string>();
            var bebidaEditar = await _bebidaRepository.BuscarBebidaIdAsync(id);

            if (bebidaEditar.Nome.Length > 100)
            {
                erros.Add("Excedeu número maxímo de caracteres");
            }
            if (string.IsNullOrEmpty(bebidaEditar.Nome))
            {
                erros.Add("O nome é Obrigatório");
            }
            if (erros.Count > 0)
            {
                return BadRequest(new { erros = erros });
            }
            if (bebidaEditar == null)
            {
                erros.Add("O Id solicitado não foi localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            bebidaEditar.Editar(bebidaVM.Nome, bebidaVM.TeorAlcoolico, bebidaVM.ValorCusto, bebidaVM.ValorVenda);
            await _bebidaRepository.EditarBebidaAsync(bebidaEditar);
            return Ok();
        }
        [HttpPut("editarBebidaNome/{nome}")]
        public async Task<IActionResult> EditarBebidaNome(string nome, [FromBody] BebidaViewModel bebidaVM)
        {
            var bebidaEditar = await _bebidaRepository.BuscarBebidaNomeAsync(nome);
            bebidaEditar.Editar(bebidaVM.Nome, bebidaVM.TeorAlcoolico, bebidaVM.ValorCusto, bebidaVM.ValorVenda);
            await _bebidaRepository.EditarBebidaAsync(bebidaEditar);
            return Ok();
        }
        [HttpDelete("excluirBebida/{id}")]
        public async Task<IActionResult> ExcluirBebida(Guid id)
        {
            var bebidaExcluir = await _bebidaRepository.BuscarBebidaIdAsync(id);
            var erros = new List<string>();

            if (bebidaExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _bebidaRepository.ExcluirBebidaAsync(id);
            return Ok(bebidaExcluir);
        }
        [HttpDelete("excluirBebidaNome/{nome}")]
        public async Task<IActionResult> ExcluirBebidaNome(string nome)
        {
            var bebidaExcluir = await _bebidaRepository.BuscarBebidaNomeAsync(nome);
            var erros = new List<string>();

            if (bebidaExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _bebidaRepository.ExcluirBebidaNomeAsync(nome);
            return Ok(bebidaExcluir);
        }
    }
}
