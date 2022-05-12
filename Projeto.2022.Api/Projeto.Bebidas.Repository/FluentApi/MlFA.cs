using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Mls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
  public class MlFA: IEntityTypeConfiguration<MlModel>
    {
        public void Configure(EntityTypeBuilder<MlModel> builder)
        {
            builder.HasKey(ml => ml.Id);
            builder.Property(ml => ml.Ml).IsRequired();
            builder.Property(ml => ml.ValorCusto).IsRequired();
            builder.Property(ml => ml.ValorVenda).IsRequired();
        }
    }
}
