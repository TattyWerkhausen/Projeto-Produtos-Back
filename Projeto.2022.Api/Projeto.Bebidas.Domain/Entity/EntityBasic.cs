using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Domain.Entity
{
   public class EntityBasic
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public EntityBasic(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public EntityBasic()
        {
        }
    }
}
