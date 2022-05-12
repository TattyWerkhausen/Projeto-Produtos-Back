using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Sabor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
   public class SaborFA : IEntityTypeConfiguration<SaborModel>
    {
        public void Configure(EntityTypeBuilder<SaborModel> builder)
        {
            builder.HasKey(sabor => sabor.Id);
   

        }
    }
}
