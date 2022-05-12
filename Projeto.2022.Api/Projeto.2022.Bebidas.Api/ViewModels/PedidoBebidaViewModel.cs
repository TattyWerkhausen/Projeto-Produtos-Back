using Projeto.Bebidas.Domain.Acrescento;
using Projeto.Bebidas.Domain.Bebida;
using Projeto.Bebidas.Domain.Mls;
using Projeto.Bebidas.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.ViewModels
{
    public class PedidoBebidaViewModel
    {
        public Guid Id { get; set; }
        public Guid BebidaId { get; set; }
        public Guid MlId { get; set; }
        public Guid AcrescentoId { get; set; }
        public double ValorSubTotal { get; set; }
        public Guid PedidoId { get; set; }
        public Guid SaborId { get; set; }
    }
}
