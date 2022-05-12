using Projeto.Bebidas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Sabor
{
    public class SaborModel : EntityBasic
    {
        public double ValorCusto { get; private set; }
        public double ValorVenda { get; private set; }
        public SaborModel()
        {
        }

        public SaborModel(Guid id, string nome, double valorCusto, double valorVenda) : base(id, nome)
        {
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }
        public void Editar(string nome, double valorCusto, double valorVenda)
        {
            Nome = nome;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }
    }
}
