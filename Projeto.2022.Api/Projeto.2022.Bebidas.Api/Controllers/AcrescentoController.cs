using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Acrescento;
using Projeto.Bebidas.Repository.Acrescentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcrescentoController : ControllerBase
    {
        private readonly AcrescentoRepository _acrescentoRepository;
        private readonly IMapper _mapper;
        public AcrescentoController(AcrescentoRepository acrescentoRepository, IMapper mapper)
        {
            _acrescentoRepository = acrescentoRepository;
            _mapper = mapper;
        }
        [HttpPost("registrarAcrescento")]
        public async Task<IActionResult> CadastrarAcrescento([FromBody] AcrescentosViewModel acrescentosView)
        {
            acrescentosView.Id = Guid.NewGuid();
            var acrescento = _mapper.Map<AcrescentoModel>(acrescentosView);
            await _acrescentoRepository.RegistrarAcrescentoAsync(acrescento);
            return Ok();
        }
        [HttpGet("buscarAcrescentoId/{id}")]
        public async Task<IActionResult> BuscarAcrescentoId(Guid id)
        {
            var acrescentoId = await _acrescentoRepository.BuscarAcrescentoIdAsync(id);
            var acrescentoVM = _mapper.Map<AcrescentosViewModel>(acrescentoId);
            return Ok(acrescentoVM);
        }
        [HttpGet("buscarAcrescentoNome/{nome}")]
        public async Task<IActionResult> BuscarAcrescentoNome(string nome)
        {
            var acrescentoNome = await _acrescentoRepository.BuscarAcrescentoNomeAsync(nome);
            var acrescentoVM = _mapper.Map<AcrescentosViewModel>(acrescentoNome);
            return Ok(acrescentoVM);
        }
        [HttpGet("buscarTodosAcrescentos")]
        public async Task<IActionResult> BuscarTodosAcrescentos()
        {
            var acrescentos = await _acrescentoRepository.BuscarTodosAcrescentosAsync();
            var todosAcrescentos = _mapper.Map<List<AcrescentosViewModel>>(acrescentos);
            return Ok(todosAcrescentos);
        }
        [HttpPut("editarAcrescento/{id}")]
        public async Task<IActionResult> EditarAcrescento(Guid id, [FromBody] AcrescentosViewModel acrescentosView)
        {
            var acrescentoId = await _acrescentoRepository.BuscarAcrescentoIdAsync(id);
            acrescentoId.Editar(acrescentosView.Nome, acrescentosView.ValorCusto, acrescentosView.ValorVenda, acrescentosView.Gramagem);
            await _acrescentoRepository.EditarAcrescentoAsync(acrescentoId);
            return Ok();
        }
        [HttpPut("editarAcrescentoNome/{nome}")]
        public async Task<IActionResult> EditarAcrescentoNome(string nome, [FromBody] AcrescentosViewModel acrescentosView)
        {
            var acrescento = await _acrescentoRepository.BuscarAcrescentoNomeAsync(nome);
            acrescento.Editar(acrescentosView.Nome, acrescentosView.ValorCusto, acrescentosView.ValorVenda, acrescentosView.Gramagem);
            await _acrescentoRepository.EditarAcrescentoAsync(acrescento);
            return Ok();
        }
        [HttpDelete("excluirAcrescento/{id}")]
        public async Task<IActionResult> ExcluirAcrescento(Guid id)
        {
            var acrescentoId = await _acrescentoRepository.BuscarAcrescentoIdAsync(id);
            await _acrescentoRepository.ExcluirAcrescentoAsync(id);
            return Ok(acrescentoId);
        }
        [HttpDelete("excluirAcrescentoNome/{nome}")]
        public async Task<IActionResult> ExcluirAcrescentoNome(string nome)
        {
            var acrescento = await _acrescentoRepository.BuscarAcrescentoNomeAsync(nome);
            await _acrescentoRepository.ExcluirAcrescentoNomeAsync(nome);
            return Ok(acrescento);
        }
    }
}
