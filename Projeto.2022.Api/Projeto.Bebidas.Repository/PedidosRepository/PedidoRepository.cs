using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.PedidoBebida;
using Projeto.Bebidas.Domain.Pedidos;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.PedidosRepository
{
    public class PedidoRepository
    {
        private readonly BancoDb _db;
        public PedidoRepository(BancoDb db)
        {
            _db = db;
        }
        public async Task CadastrarPedidoAsync(PedidoModel pedidoModel)
        {
            await _db.Pedidos.AddAsync(pedidoModel);
            await _db.SaveChangesAsync();
        }
        public async Task<List<PedidoModel>> BuscarTodosPedidosAsync()
        {
            return await _db.Pedidos.ToListAsync();
        }
        public async Task<PedidoModel> BuscarPedidoIdAsync(Guid id)
        {
            return await _db.Pedidos.FirstOrDefaultAsync(pedido => pedido.Id == id);
        }
        public async Task<PedidoModel> BuscarPedidoDataAsync(DateTime data)
        {
            return await _db.Pedidos.FirstOrDefaultAsync(pedido => pedido.Data == data);
        }
        public async Task<PedidoModel> BuscarPedidoClienteAsync(string nome)
        {
            return await _db.Pedidos.FirstOrDefaultAsync(pedido => pedido.ClienteModel.Nome.Contains(nome));
        }
        public async Task EditarPedidoAsync(PedidoModel pedidoModel)
        {
            _db.Pedidos.UpdateRange(pedidoModel);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirPedidoIdAsyn(Guid id)
        {
            var pedidoIdExcluir = await BuscarPedidoIdAsync(id);
            _db.Pedidos.RemoveRange(pedidoIdExcluir);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirPedidoDataAsyn(DateTime data)
        {
            var pedidoDataExcluir = await BuscarPedidoDataAsync(data);
            _db.Pedidos.RemoveRange(pedidoDataExcluir);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirPedidoNomeClienteAsyn(string nome)
        {
            var pedidoNomeExcluir = await BuscarPedidoClienteAsync(nome);
            _db.Pedidos.RemoveRange(pedidoNomeExcluir);
            await _db.SaveChangesAsync();
        }
    }
}
