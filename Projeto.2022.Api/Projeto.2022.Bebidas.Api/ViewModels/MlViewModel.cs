using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.ViewModels
{
    public class MlViewModel
    {
        public Guid Id { get; set; }
        public int Ml { get; set; }
        public double ValorCusto { get; set; }
        public double ValorVenda { get; set; }
    }
}
