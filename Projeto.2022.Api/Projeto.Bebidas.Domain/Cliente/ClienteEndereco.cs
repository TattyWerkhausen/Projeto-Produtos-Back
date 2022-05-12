using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Shared.ViewModels;

namespace Projeto.Bebidas.Domain.Cliente
{
    public class ClienteEndereco: EnderecoModelBase
    {
        public ClienteEndereco(EnderecoViewModel endereco): base(endereco)
        {
        }
        public ClienteEndereco()
        {

        }
    }
}
