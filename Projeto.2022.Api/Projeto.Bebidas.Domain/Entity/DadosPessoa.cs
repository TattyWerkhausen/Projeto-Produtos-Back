using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Entity
{
    public class DadosPessoa:EntityBasic
    {
        public string ChaveAcesso { get;  set; }
        public string Sobrenome { get; set; }
        public string Email { get;set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get;set; }

        public DadosPessoa(Guid id, string nome, string chaveAcesso, string sobrenome, string email, string telefone, string cpf, DateTime dataNascimento):base(id, nome)
        {
            ChaveAcesso = chaveAcesso;
            Sobrenome = sobrenome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
        public DadosPessoa()
        {
        }
    }

}
