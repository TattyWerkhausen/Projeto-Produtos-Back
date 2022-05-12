using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.Acrescento;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Acrescentos
{
    public class AcrescentoRepository
    {
        private readonly BancoDb _db;
        public AcrescentoRepository(BancoDb db)
        {
            _db = db;
        }
        public async Task RegistrarAcrescentoAsync(AcrescentoModel acrescento)
        {
            await _db.Acrescentos.AddAsync(acrescento);
            await _db.SaveChangesAsync();
        }
        public async Task<List<AcrescentoModel>> BuscarTodosAcrescentosAsync()
        {
            return await _db.Acrescentos.ToListAsync();
        }
        public async Task<AcrescentoModel> BuscarAcrescentoIdAsync(Guid id)
        {
            return await _db.Acrescentos.FirstOrDefaultAsync(acrescento => acrescento.Id == id);
        }
        public async Task<AcrescentoModel> BuscarAcrescentoNomeAsync(string nome)
        {
            return await _db.Acrescentos.FirstOrDefaultAsync(acrescento => acrescento.Nome == nome);
        }
        public async Task EditarAcrescentoAsync(AcrescentoModel acrescento)
        {
            _db.Acrescentos.UpdateRange(acrescento);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirAcrescentoAsync(Guid id)
        {
            var acrescentoId = await BuscarAcrescentoIdAsync(id);
            _db.Acrescentos.RemoveRange(acrescentoId);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirAcrescentoNomeAsync(string nome)
        {
            var acrescento = await BuscarAcrescentoNomeAsync(nome);
            _db.Acrescentos.RemoveRange(acrescento);
            await _db.SaveChangesAsync();
        }
    }
}
