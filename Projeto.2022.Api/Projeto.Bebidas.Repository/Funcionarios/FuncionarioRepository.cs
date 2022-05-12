using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.Funcionario;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Funcionarios
{
   public class FuncionarioRepository
    {
        private readonly BancoDb _db;
        public FuncionarioRepository(BancoDb db)
        {
            _db = db;
        }
        public async Task RegistrarFuncionarioAsync(FuncionarioModel funcionario)
        {
            await _db.Funcionarios.AddAsync(funcionario);
            await _db.SaveChangesAsync();
        }
        public async Task<FuncionarioModel> BuscarFuncionarioIdAsync(Guid id)
        {
            return await _db.Funcionarios.FirstOrDefaultAsync(funci => funci.Id == id);
        }
        public async Task<FuncionarioModel> FuncionarioChaveAcessoAsync(string chaveAcesso)
        {
            return await _db.Funcionarios.FirstOrDefaultAsync(funci => funci.ChaveAcesso == chaveAcesso);
        }
        public async Task<FuncionarioModel> BuscarFuncionarioNomeAsync(string nome)
        {
            return await _db.Funcionarios.FirstOrDefaultAsync(funci => funci.Nome == nome);
        }
        public async Task<List<FuncionarioModel>> BuscarTodosFuncionariosAsync()
        {
            return await _db.Funcionarios.ToListAsync();
        }
        public async Task EditarFuncionarioAsync(FuncionarioModel funcionario)
        {
            _db.Funcionarios.UpdateRange(funcionario);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirFuncionarioAsync(Guid id)
        {
            var funcionarioExcluir = await BuscarFuncionarioIdAsync(id);
            _db.Funcionarios.RemoveRange(funcionarioExcluir);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirFuncionarioNomeAsync(string nome)
        {
            var funcionarioExcluir = await BuscarFuncionarioNomeAsync(nome);
            _db.Funcionarios.RemoveRange(funcionarioExcluir);
            await _db.SaveChangesAsync();
        }
    }
}
