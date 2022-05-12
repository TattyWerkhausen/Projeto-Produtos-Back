using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto._2022.Bebidas.Api.ViewModels;
using Projeto.Bebidas.Domain.Mls;
using Projeto.Bebidas.Repository.Mls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MlController : ControllerBase
    {
        private readonly MlRepository _mlRepository;
        private readonly IMapper _autoMapper;

        public MlController(MlRepository mlRepository, IMapper mapper)
        {
            _mlRepository = mlRepository;
            _autoMapper = mapper;
        }
        [HttpPost("registrarMl")]
        public async Task<IActionResult> CadastrarMl([FromBody] MlViewModel mlViewModel)
        {
            mlViewModel.Id = Guid.NewGuid();
            var mlNovo = _autoMapper.Map<MlModel>(mlViewModel);
            await _mlRepository.CadastrarMlAsync(mlNovo);
            return Ok();
        }
        [HttpGet("buscarMlId/{id}")]
        public async Task<IActionResult> BuscarMlId(Guid id)
        {
            var ml = await _mlRepository.BuscarMlIdAsync(id);
            var mlEncontrado = _autoMapper.Map<MlViewModel>(ml);
            return Ok(mlEncontrado);
        }
        [HttpGet("buscarMl/{ml}")]
        public async Task<IActionResult> BuscarMl(int ml)
        {
            var mlBuscar = await _mlRepository.BuscarMlAsync(ml);
            var mlEncontrado = _autoMapper.Map<MlViewModel>(mlBuscar);
            return Ok(mlEncontrado);
        }
        [HttpGet("buscarTodosMl")]
        public async Task<IActionResult> BuscarTodosMl()
        {
            var buscarTodos = await _mlRepository.BuscarTodosMl();
            var todosMl = _autoMapper.Map<List<MlViewModel>>(buscarTodos);
            return Ok(todosMl);
        }
        [HttpPut("editarMlId/{id}")]
        public async Task<IActionResult> EditarMlId([FromBody] MlViewModel mlViewModel, Guid id)
        {
            var mlBuscaId = await _mlRepository.BuscarMlIdAsync(id);
            mlBuscaId.Editar(mlViewModel.Ml, mlViewModel.ValorCusto, mlViewModel.ValorVenda);
            await _mlRepository.EditarMlIdAsync(mlBuscaId);
            return Ok();
        }
        [HttpPut("editarMl/{ml}")]
        public async Task<IActionResult> EditarMl([FromBody] MlViewModel mlViewModel, int ml)
        {
            var mlBusca = await _mlRepository.BuscarMlAsync(ml);
            mlBusca.Editar(mlViewModel.Ml, mlViewModel.ValorCusto, mlViewModel.ValorVenda);
            await _mlRepository.EditarMlAsync(mlBusca);
            return Ok();
        }
        [HttpDelete("excluirMlId/{id}")]
        public async Task<IActionResult> ExcluirMlId(Guid id)
        {
            var mlBuscaId = await _mlRepository.BuscarMlIdAsync(id);

            await _mlRepository.ExcluirMlIdAsync(id);
            return Ok(mlBuscaId);
        }
        [HttpDelete("excluirMl/{ml}")]
        public async Task<IActionResult> ExcluirMl(int ml)
        {
            var mlBusca = await _mlRepository.BuscarMlAsync(ml);

            await _mlRepository.ExcluirMlAsync(ml);
            return Ok(mlBusca);
        }

    }
}
