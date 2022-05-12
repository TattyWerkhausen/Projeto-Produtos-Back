using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Distribuidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
   public class DistribuidorFA: IEntityTypeConfiguration<DistribuidorModel>
    {
        public void Configure(EntityTypeBuilder<DistribuidorModel> builder)
        {
            builder.HasKey(distribuidor => distribuidor.Id);
            builder.Property(distribuidor => distribuidor.Nome).HasMaxLength(20).IsRequired();
            builder.Property(distribuidor => distribuidor.Email).IsRequired();
            builder.Property(distribuidor => distribuidor.Telefone).IsRequired();
            builder.Property(distribuidor => distribuidor.Cnpj).IsRequired();
            builder.OwnsOne(distri => distri.EnderecoModel, enderecoBuilder =>
            {
                enderecoBuilder.Property(distriEndere => distriEndere.Uf).HasMaxLength(100);
                enderecoBuilder.Property(distriEndere => distriEndere.Cep).HasMaxLength(100);
                enderecoBuilder.Property(distriEndere => distriEndere.Cidade).HasMaxLength(100);
                enderecoBuilder.Property(distriEndere => distriEndere.Bairro).HasMaxLength(100);
                enderecoBuilder.Property(distriEndere => distriEndere.Rua).HasMaxLength(100);
                enderecoBuilder.Property(distriEndere => distriEndere.Numero).HasMaxLength(100);
                enderecoBuilder.Property(distriEndere => distriEndere.Complemento).HasMaxLength(100);
            });
        }
    }
}
