using Projeto.Bebidas.Domain.Entity;
using Projeto.Bebidas.Domain.PedidoBebida;
using Projeto.Bebidas.Domain.Sabor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Bebida
{
   public class BebidaModel:EntityBasic
    {
        public double TeorAlcoolico { get; private set; }
        public double ValorCusto { get; private set; }
        public double ValorVenda { get; private set; }
        public List<PedidoBebidaModel> PedidosBebidasModel { get; set; }

        public BebidaModel(Guid id, string nome, double teorAlcoolico, double valorCusto, double valorVenda):base(id, nome)
        {
            TeorAlcoolico = teorAlcoolico;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }

        public BebidaModel()
        {
        }
        public void Editar(string nome, double teorAlcoolico, double valorCusto, double valorVenda)
        {
            Nome = nome;
            TeorAlcoolico = teorAlcoolico;
            ValorCusto = valorCusto;
            ValorVenda = valorVenda;
        }
    }
}
