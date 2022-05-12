using Projeto.Bebidas.Domain.Cliente;
using Projeto.Bebidas.Domain.PedidoBebida;
using Projeto.Bebidas.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.ViewModels
{
    public class PedidoViewModel
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public EnderecoViewModel EnderecoPedido { get; set; }
        public List<PedidoBebidaViewModel> ListaPedidoBebida { get; set; }
        public DateTime Data { get; set; }
        public double ValorTotal { get; set; }
    }
}
