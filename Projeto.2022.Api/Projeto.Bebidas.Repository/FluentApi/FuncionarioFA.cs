using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Funcionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
   public class FuncionarioFA:IEntityTypeConfiguration<FuncionarioModel>
    {
        public void Configure(EntityTypeBuilder<FuncionarioModel> builder)
        {
            builder.HasKey(funci => funci.Id);
            builder.Property(funci => funci.Nome).HasMaxLength(10).IsRequired();
            builder.Property(funci => funci.Sobrenome).HasMaxLength(20).IsRequired();
            builder.Property(funci => funci.Email).IsRequired();
            builder.Property(funci => funci.Telefone).IsRequired();
            builder.Property(funci => funci.Cpf).IsRequired();
            builder.Property(funci => funci.DataNascimento).IsRequired();
            builder.OwnsOne(funci => funci.EnderecoModel, enderecoBuilder =>
            {
                enderecoBuilder.Property(funciEndere => funciEndere.Uf).HasMaxLength(100);
                enderecoBuilder.Property(funciEndere => funciEndere.Cep).HasMaxLength(100);
                enderecoBuilder.Property(funciEndere => funciEndere.Cidade).HasMaxLength(100);
                enderecoBuilder.Property(funciEndere => funciEndere.Bairro).HasMaxLength(100);
                enderecoBuilder.Property(funciEndere => funciEndere.Rua).HasMaxLength(100);
                enderecoBuilder.Property(funciEndere => funciEndere.Numero).HasMaxLength(100);
                enderecoBuilder.Property(funciEndere => funciEndere.Complemento).HasMaxLength(100);
            });
        }
    }
}
