using Microsoft.EntityFrameworkCore;
using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.Clientes
{
   public  class ClienteRepository
    {
        private readonly BancoDb _db;
       public ClienteRepository(BancoDb db)
        {
            _db = db;
        }

        public async Task RegistrarClienteAsync(ClienteModel cliente)
        {
            try
            {
                await _db.Clientes.AddAsync(cliente);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw;
            }
        
        }
        public async Task<ClienteModel> BuscarClienteIdAsync(Guid id)
        {
          return  await _db.Clientes.FirstOrDefaultAsync(cliente => cliente.Id == id);
        }
        public async Task<List<ClienteModel>> BuscarTodosClientesAsync()
        {
           return await _db.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> BuscarClienteChaveAsync(string chaveAcesso)
        {
            return await _db.Clientes.FirstOrDefaultAsync(cliente => cliente.ChaveAcesso == chaveAcesso);
        }
        public async Task<ClienteModel> BuscarClienteNomeAsync(string nome)
        {
            return await _db.Clientes.FirstOrDefaultAsync(cliente => cliente.Nome == nome);
        }
        public async Task EditarClienteAsync(ClienteModel cliente)
        {
             _db.Clientes.UpdateRange(cliente);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirClienteAsync(Guid id)
        {
            var clienteId = await BuscarClienteIdAsync(id);
            _db.Clientes.RemoveRange(clienteId);
            await _db.SaveChangesAsync();
        }
        public async Task ExcluirClienteNomeAsync(string nome)
        {
            var cliente = await BuscarClienteNomeAsync(nome);
            _db.Clientes.RemoveRange(cliente);
            await _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<ClienteModel>> BuscarPorEndereco(string rua)
        {
            return await _db.Clientes.Where(cliente => cliente.EnderecoModel.Rua == rua).ToListAsync();
        }
        public async Task EditarEnderecoClienteAsync(ClienteModel clienteModel)
        {
            _db.Clientes.UpdateRange(clienteModel);
            await _db.SaveChangesAsync();
        }
    }
}
