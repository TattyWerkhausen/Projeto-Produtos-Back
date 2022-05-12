using Projeto.Bebidas.Domain.Acrescento;
using Projeto.Bebidas.Domain.Bebida;
using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Domain.Mls;
using Projeto.Bebidas.Domain.Pedidos;
using Projeto.Bebidas.Domain.Sabor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.PedidoBebida
{
    public class PedidoBebidaModel
    {
        protected PedidoBebidaModel()
        {

        }

        public Guid Id { get; private set; }
        public BebidaModel BebidaModel { get; private set; }
        public Guid BebidaId { get; private set; }
        public MlModel MlModel { get; private set; }
        public Guid MlId { get; private set; }
        public AcrescentoModel AcrescentoModel { get; private set; }
        public Guid AcrescentoId { get; private set; }
        public PedidoModel PedidoModel { get; private set; }
        public Guid PedidoId { get; private set; }
        public double ValorSubTotal { get; private set; }
        public SaborModel SaborModel { get; private set; }
        public Guid SaborId { get;private set; }

        public PedidoBebidaModel(Guid id, Guid bebidaId, Guid mlId, Guid acrescentoId, Guid pedidoId, double valorSubTotal, Guid saborId)
        {
            Id = id;
            BebidaId = bebidaId;
            MlId = mlId;
            AcrescentoId = acrescentoId;
            PedidoId = pedidoId;
            ValorSubTotal = valorSubTotal;
            SaborId = saborId;
        }

        public void Editar(Guid bebidaId, Guid mlId, Guid acrescentoId, Guid pedidoId, double valorSubTotal, Guid saborId)
        {
            BebidaId = bebidaId;
            MlId = mlId;
            AcrescentoId = acrescentoId;
            PedidoId = pedidoId;
            ValorSubTotal = valorSubTotal;
            SaborId = saborId;
        }
    }
}
