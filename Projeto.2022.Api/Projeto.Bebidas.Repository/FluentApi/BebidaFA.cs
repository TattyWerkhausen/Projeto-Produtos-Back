using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Bebida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
   public class BebidaFA:IEntityTypeConfiguration<BebidaModel>
    {
        public void Configure(EntityTypeBuilder<BebidaModel> builder)
        {
            builder.HasKey(bebida => bebida.Id);
            builder.Property(bebida => bebida.Nome).HasMaxLength(10).IsRequired();
            builder.Property(bebida => bebida.TeorAlcoolico).IsRequired();
            builder.Property(bebida => bebida.ValorCusto).IsRequired();
            builder.Property(bebida => bebida.ValorVenda).IsRequired();
          
        }
    }
}
