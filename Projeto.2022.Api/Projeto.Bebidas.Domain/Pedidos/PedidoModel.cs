using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Domain.PedidoBebida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Pedidos
{
    public class PedidoModel
    {
        public PedidoModel()
        {
        }
        public Guid Id { get; private set; }
        public ClienteModel ClienteModel { get; private set; }
        public Guid ClienteModelId { get; private set; }
        public PedidoEnderecoModel PedidoEndereco { get; private set; }
        public List<PedidoBebidaModel> ListaPedidoBebida { get; private set; }
        public DateTime Data { get; private set; }
        public double ValorTotal { get; private set; }

        public PedidoModel(Guid id, Guid clienteModelId, PedidoEnderecoModel pedidoEndereco, List<PedidoBebidaModel> listaPedidoBebida, DateTime data, double valorTotal)
        {
            Id = id;
            ClienteModelId = clienteModelId;
            PedidoEndereco = pedidoEndereco;
            ListaPedidoBebida = listaPedidoBebida;
            Data = data;
            ValorTotal = valorTotal;
        }

        public void Editar(Guid clienteModelId, PedidoEnderecoModel pedidoEndereco, List<PedidoBebidaModel> listaPedidoBebida, DateTime data, double valorTotal)
        {
            ClienteModelId = clienteModelId;
            PedidoEndereco = pedidoEndereco;
            ListaPedidoBebida = listaPedidoBebida;
            Data = data;
            ValorTotal = valorTotal;
        }
    }
}
