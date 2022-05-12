using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.Distribuidor;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Distribuidores
{
   public class DistribuidorRepository
    {
        private readonly BancoDb _db;
        public DistribuidorRepository(BancoDb db)
        {
            _db = db;
        }

        public async Task RegistrarDistribuidorAsync(DistribuidorModel distribuidor)
        {
            await _db.Distribuidores.AddAsync(distribuidor);
            await _db.SaveChangesAsync();
        }
        public async Task<DistribuidorModel> BuscarDistribuidorIdAsync(Guid id)
        {
            return await _db.Distribuidores.FirstOrDefaultAsync(distribuidor => distribuidor.Id == id);
        }
        public async Task<List<DistribuidorModel>> BuscarTodosDistribuidorsAsync()
        {
            return await _db.Distribuidores.ToListAsync();
        }
        public async Task<DistribuidorModel> BuscarDistribuidorChaveAsync(string chaveAcesso)
        {
            return await _db.Distribuidores.FirstOrDefaultAsync(distribuidor => distribuidor.ChaveAcesso == chaveAcesso);
        }
        public async Task<DistribuidorModel> BuscarDistribuidorNomeAsync(string nome)
        {
            return await _db.Distribuidores.FirstOrDefaultAsync(distribuidor => distribuidor.Nome == nome);
        }
        public async Task EditarDistribuidorAsync(DistribuidorModel distribuidor)
        {
            _db.Distribuidores.UpdateRange(distribuidor);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirDistribuidorAsync(Guid id)
        {
            var distribuidorId = await BuscarDistribuidorIdAsync(id);
            _db.Distribuidores.RemoveRange(distribuidorId);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirDistribuidorNomeAsync(string nome)
        {
            var distribuidor = await BuscarDistribuidorNomeAsync(nome);
            _db.Distribuidores.RemoveRange(distribuidor);
            await _db.SaveChangesAsync();
        }
    }
}
