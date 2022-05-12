using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Acrescento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
    public class AcrescentoFA:IEntityTypeConfiguration<AcrescentoModel>
    {
        public void Configure(EntityTypeBuilder<AcrescentoModel> builder)
        {
            builder.HasKey(acre => acre.Id);
        }
    }
}
