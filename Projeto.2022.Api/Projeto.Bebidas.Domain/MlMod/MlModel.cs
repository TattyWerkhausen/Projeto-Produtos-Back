using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Mls
{
    public class MlModel
    {
        public MlModel()
        {
        }

        public Guid Id { get; private set; }
        public int Ml { get; private set; }
        public double ValorCusto { get; private set; }
        public double ValorVenda { get; private set; }

        public MlModel(Guid id, int ml, double valorCusto, double valorVenda)
        {
            Id = id;
            Ml = ml;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }
        public void Editar(int ml, double valorCusto, double valorVenda)
        {
            Ml = ml;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }
    }
}
