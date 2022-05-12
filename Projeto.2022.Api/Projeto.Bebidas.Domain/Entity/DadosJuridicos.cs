using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Entity
{
    public class DadosJuridicos : EntityBasic
    {
        public DadosJuridicos()
        {
        }

        public DadosJuridicos(Guid id, string nome, string chaveAcesso, string cnpj, string email, string telefone) : base(id, nome)
        {

            ChaveAcesso = chaveAcesso;
            Cnpj = cnpj;
            Email = email;
            Telefone = telefone;
        }

        public string ChaveAcesso { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}