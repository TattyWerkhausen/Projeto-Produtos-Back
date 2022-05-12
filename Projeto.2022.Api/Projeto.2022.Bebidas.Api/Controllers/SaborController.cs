using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Sabor;
using Projeto.Bebidas.Repository.Sabores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaborController : ControllerBase
    {
        private readonly SaborRepository _saborRepository;
        private readonly IMapper _mapper;
        public SaborController(SaborRepository saborRepository, IMapper mapper)
        {
            _saborRepository = saborRepository;
            _mapper = mapper;
        }
        [HttpPost("registrarSabor")]
        public async Task<IActionResult> RegistrarSabor([FromBody] SaborViewModel saborVM)
        {
            saborVM.Id = Guid.NewGuid();
            var sabor = _mapper.Map<SaborModel>(saborVM);
            await _saborRepository.RegistrarSaborAsync(sabor);
            return Ok();
        }
        [HttpGet("buscarSabor/{id}")]
        public async Task<IActionResult> BuscarSaborId(Guid id)
        {
            var saborId = await _saborRepository.BuscarSaborIdAsync(id);
            var saborVM = _mapper.Map<SaborViewModel>(saborId);
            return Ok(saborVM);
        }
        [HttpGet("buscarSaborNome/{nome}")]
        public async Task<IActionResult> BuscarSaborNome(string nome)
        {
            var sabor = await _saborRepository.BuscarSaborNomeAsync(nome);
            var saborVM = _mapper.Map<SaborViewModel>(sabor);
            return Ok(saborVM);
        }
        [HttpGet("buscarTodosSabores")]
        public async Task<IActionResult> BuscarTodosSabores()
        {
            var sabores = await _saborRepository.BuscarTodosSaboresAsync();
            var saboresVM = _mapper.Map<List<SaborViewModel>>(sabores);
            return Ok(saboresVM);
        }
        [HttpPut("editarSabor/{id}")]
        public async Task<IActionResult> EditarSabor(Guid id, [FromBody] SaborViewModel saborVM)
        {
            var erros = new List<string>();
            var saborEditar = await _saborRepository.BuscarSaborIdAsync(id);

            if (saborEditar.Nome.Length > 100)
            {
                erros.Add("Excedeu número maxímo de caracteres");
            }
            if (string.IsNullOrEmpty(saborEditar.Nome))
            {
                erros.Add("O nome é Obrigatório");
            }
            if (erros.Count > 0)
            {
                return BadRequest(new { erros = erros });
            }
            if (saborEditar == null)
            {
                erros.Add("O Id solicitado não foi localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            saborEditar.Editar(saborVM.Nome, saborVM.ValorCusto, saborVM.ValorVenda);
            await _saborRepository.EditarSaborAsync(saborEditar);
            return Ok();
        }
        [HttpPut("editarSaborNome/{nome}")]
        public async Task<IActionResult> EditarSaborNome(string nome, [FromBody] SaborViewModel saborVM)
        {
            var saborEditar = await _saborRepository.BuscarSaborNomeAsync(nome);
            saborEditar.Editar(saborVM.Nome, saborVM.ValorCusto, saborVM.ValorVenda);
            await _saborRepository.EditarSaborAsync(saborEditar);
            return Ok();
        }
        [HttpDelete("excluirSabor/{id}")]
        public async Task<IActionResult> ExcluirSabor(Guid id)
        {
            var saborExcluir = await _saborRepository.BuscarSaborIdAsync(id);
            var erros = new List<string>();

            if (saborExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _saborRepository.ExcluirSaborAsync(id);
            return Ok(saborExcluir);
        }
        [HttpDelete("excluirSaborNome/{nome}")]
        public async Task<IActionResult> ExcluirSaborNome(string nome)
        {
            var saborExcluir = await _saborRepository.BuscarSaborNomeAsync(nome);
            var erros = new List<string>();

            if (saborExcluir == null)
            {
                erros.Add("Id não localizado, tente novamente");
                return BadRequest(new { erros = erros });
            }
            await _saborRepository.ExcluirSaborNomeAsync(nome);
            return Ok(saborExcluir);
        }
    }
}
