using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Pedidos
{
    public class PedidoEnderecoModel : EnderecoModelBase
    {
        public PedidoEnderecoModel()
        {
        }
        public PedidoEnderecoModel(EnderecoViewModel endereco) : base(endereco)
        {
        }

    }
}
