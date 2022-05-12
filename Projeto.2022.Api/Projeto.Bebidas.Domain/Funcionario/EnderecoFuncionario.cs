using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Funcionario
{
   public class EnderecoFuncionario: EnderecoModelBase
    {
        public EnderecoFuncionario(EnderecoViewModel endereco) : base(endereco)
        {
        }
        public EnderecoFuncionario()
        {

        }
    }
}
