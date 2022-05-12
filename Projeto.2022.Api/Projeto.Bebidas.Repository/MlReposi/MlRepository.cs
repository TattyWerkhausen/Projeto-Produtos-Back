using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.Mls;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Mls
{
    public class MlRepository
    {
        private readonly BancoDb _db;
        public MlRepository(BancoDb db)
        {
            _db = db;
        }
        public async Task CadastrarMlAsync(MlModel mlModel)
        {
            await _db.Mls.AddAsync(mlModel);
            await _db.SaveChangesAsync();
        }
        public async Task<List<MlModel>> BuscarTodosMl()
        {
            return await _db.Mls.ToListAsync();
        }
        public async Task<MlModel> BuscarMlIdAsync(Guid id)
        {
            return await _db.Mls.FirstOrDefaultAsync(ml => ml.Id == id);
        }
        public async Task<MlModel> BuscarMlAsync(int ml)
        {
            return await _db.Mls.FirstOrDefaultAsync(mls => mls.Ml == ml);
        }
        public async Task EditarMlAsync(MlModel mlModel)
        {
            _db.Mls.UpdateRange(mlModel);
            await _db.SaveChangesAsync();
        }
        public async Task EditarMlIdAsync(MlModel mlModel)
        {
            _db.Mls.UpdateRange(mlModel);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirMlAsync(int ml)
        {
            var mlBusca = await BuscarMlAsync(ml);
            _db.Mls.RemoveRange(mlBusca);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirMlIdAsync(Guid id)
        {
            var mlId = await BuscarMlIdAsync(id);
            _db.Mls.RemoveRange(mlId);

            await _db.SaveChangesAsync();
        }

    }
}
