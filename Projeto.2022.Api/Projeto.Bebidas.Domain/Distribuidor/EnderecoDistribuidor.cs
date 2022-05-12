using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Distribuidor
{
    public class EnderecoDistribuidor: EnderecoModelBase
    {
        public EnderecoDistribuidor(EnderecoViewModel endereco) : base(endereco)
        {
        }
        public EnderecoDistribuidor()
        {

        }
    }
}
