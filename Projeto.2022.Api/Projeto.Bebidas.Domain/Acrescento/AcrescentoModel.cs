using Projeto.Bebidas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Acrescento
{
    public class AcrescentoModel : EntityBasic
    {
        public AcrescentoModel()
        {
        }

        public AcrescentoModel(Guid id, string nome, double valorCusto, double valorVenda, string gramagem) : base(id, nome)
        {
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
            Gramagem = gramagem;
        }

        public double ValorCusto { get; private set; }
        public double ValorVenda { get; private set; }
        public string Gramagem { get; private set; }
        public void Editar(string nome, double valorCusto, double valorVenda, string gramagem)
        {
            Nome = nome;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
            Gramagem = gramagem;
        }

    }

}
