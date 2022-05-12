using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Funcionario
{
    public class FuncionarioModel : DadosPessoa
    {
        public EnderecoFuncionario EnderecoModel { get; private set; }
        public FuncionarioModel()
        {
        }
        public FuncionarioModel(Guid id, string nome, string chaveAcesso, string sobrenome, string email, string telefone, string cpf, DateTime dataNascimento, EnderecoFuncionario enderecoModel) : base(id, nome, chaveAcesso, sobrenome, email, telefone, cpf, dataNascimento)
        {
            EnderecoModel = enderecoModel;
        }
        public void Editar(string nome, string chaveAcesso, string sobrenome, string email, string telefone, string cpf, DateTime dataNascimento, EnderecoFuncionario enderecoModel)
        {
            Nome = nome;
            ChaveAcesso = chaveAcesso;
            Sobrenome = sobrenome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            EnderecoModel = enderecoModel;
        }
    }
}
