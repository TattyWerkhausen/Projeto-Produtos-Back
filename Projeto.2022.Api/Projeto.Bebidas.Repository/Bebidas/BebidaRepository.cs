using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.Bebida;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Bebidas
{
    public class BebidaRepository
    {
        private readonly BancoDb _db;
        public BebidaRepository(BancoDb db)
        {
            _db = db;
        }
        public async Task RegistrarBebidaAsync(BebidaModel bebida)
        {
            await _db.Bebidas.AddAsync(bebida);
            await _db.SaveChangesAsync();
        }
        public async Task<BebidaModel> BuscarBebidaIdAsync(Guid id)
        {
            return await _db.Bebidas.FirstOrDefaultAsync(bebida => bebida.Id == id);
        }
        public async Task<BebidaModel> BuscarBebidaNomeAsync(string nome)
        {
            return await _db.Bebidas.FirstOrDefaultAsync(bebida => bebida.Nome == nome);
        }
        public async Task<List<BebidaModel>> BuscarTodasBebidasAsync()
        {
            return await _db.Bebidas.ToListAsync();
        }
        public async Task EditarBebidaAsync(BebidaModel bebida)
        {
            _db.Bebidas.UpdateRange(bebida);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirBebidaAsync(Guid id)
        {
            var bebidaExcluir = await BuscarBebidaIdAsync(id);
            _db.Bebidas.RemoveRange(bebidaExcluir);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirBebidaNomeAsync(string nome)
        {
            var bebidaExcluir = await BuscarBebidaNomeAsync(nome);
            _db.Bebidas.RemoveRange(bebidaExcluir);
            await _db.SaveChangesAsync();
        }
    }
}
