using Projeto.Bebidas.Domain.Endereço;
using Projeto.Bebidas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Distribuidor
{
    public class DistribuidorModel : DadosJuridicos
    {
        public DistribuidorModel()
        {
        }
        public EnderecoDistribuidor EnderecoModel { get; private set; }
        public DistribuidorModel(Guid id, string nome, string chaveAcesso, string cnpj, string email, string telefone, EnderecoDistribuidor enderecoModel) : base(id, nome, chaveAcesso, cnpj, email, telefone)
        {
            EnderecoModel = enderecoModel;
        }
        public void Editar(string nome, string chaveAcesso, string cnpj, string email, string telefone, EnderecoDistribuidor enderecoModel)
        {
            Nome = nome;
            ChaveAcesso = chaveAcesso;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
            EnderecoModel = enderecoModel;

        }
    }
}
