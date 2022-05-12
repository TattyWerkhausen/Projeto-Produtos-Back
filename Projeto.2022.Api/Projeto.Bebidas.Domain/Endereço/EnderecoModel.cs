using Projeto.Bebidas.Domain.Shared.ViewModels;

namespace Projeto.Bebidas.Domain.Endereço
{
    public class EnderecoModelBase
    {
        public EnderecoModelBase()
        {
        }
        protected EnderecoModelBase(EnderecoViewModel endereco)
        {
            Uf = endereco.Uf;
            Cep = endereco.Cep;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Rua = endereco.Rua;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
        }

        public string Uf { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }

        public EnderecoModelBase(string uf, string cep, string cidade, string bairro, string rua, int numero, string complemento)
        {
            Uf = uf;
            Cep = cep;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
        }
        public void Editar(string uf, string cep, string cidade, string bairro, string rua, int numero, string complemento)
        {
            Uf = uf;
            Cep = cep;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
        }
    }
}
