using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto._2022.Bebidas.Api.ViewModels
{
    public class AcrescentosViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double ValorCusto { get; set; }
        public double ValorVenda { get; set; }
        public string Gramagem { get; set; }
    }
}
