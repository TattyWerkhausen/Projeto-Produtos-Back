using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.Sabor;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Sabores
{
    public class SaborRepository
    {
        private readonly BancoDb _db;
        public SaborRepository(BancoDb db)
        {
            _db = db;
        }
        public async Task RegistrarSaborAsync(SaborModel sabor)
        {
            await _db.Sabores.AddAsync(sabor);
            await _db.SaveChangesAsync();
        }
        public async Task<SaborModel> BuscarSaborIdAsync(Guid id)
        {
            return await _db.Sabores.FirstOrDefaultAsync(sabor => sabor.Id == id);
        }
        public async Task<SaborModel> BuscarSaborNomeAsync(string nome)
        {
            return await _db.Sabores.FirstOrDefaultAsync(sabor => sabor.Nome == nome.ToString());
        }
        public async Task<List<SaborModel>> BuscarTodosSaboresAsync()
        {
            return await _db.Sabores.ToListAsync();
        }
        public async Task EditarSaborAsync(SaborModel sabor)
        {
            _db.Sabores.UpdateRange(sabor);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirSaborAsync(Guid id)
        {
            var saborExcluir = await BuscarSaborIdAsync(id);
            _db.Sabores.RemoveRange(saborExcluir);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirSaborNomeAsync(string nome)
        {
            var saborExcluir = await BuscarSaborNomeAsync(nome);
            _db.Sabores.RemoveRange(saborExcluir);
            await _db.SaveChangesAsync();
        }
    }
}

