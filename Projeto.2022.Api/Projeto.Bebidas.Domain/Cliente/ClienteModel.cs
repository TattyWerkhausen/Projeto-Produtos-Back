using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Entity;
using Projeto.Bebidas.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Cliente
{
    public class ClienteModel : DadosPessoa
    {
        public ClienteEndereco EnderecoModel { get; private set; }
        public List<PedidoModel> ListaPedidos { get; private set; }
        public ClienteModel()
        {
        }

        public ClienteModel(Guid id, string nome, string chaveAcesso, string sobrenome, string email, string telefone, string cpf, DateTime dataNascimento, ClienteEndereco enderecoModel, List<PedidoModel> listaPedidos) : base(id, nome, chaveAcesso, sobrenome, email, telefone, cpf, dataNascimento)
        {
            EnderecoModel = enderecoModel;
            ListaPedidos = listaPedidos;
        }

        public void Editar(string nome, string chaveAcesso, string sobrenome, string email, string telefone, string cpf, DateTime dataNascimento, ClienteEndereco enderecoModel, List<PedidoModel> listaPedidos)
        {
            Nome = nome;
            ChaveAcesso = chaveAcesso;
            Sobrenome = sobrenome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            EnderecoModel = enderecoModel;
            ListaPedidos = listaPedidos;
        }

    }
}
