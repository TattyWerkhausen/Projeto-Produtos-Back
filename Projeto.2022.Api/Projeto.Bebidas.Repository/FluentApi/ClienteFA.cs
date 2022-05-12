using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
    public class ClienteFA : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(cliente => cliente.Id);
            builder.Property(cliente => cliente.Nome).HasMaxLength(10).IsRequired();
            builder.Property(cliente => cliente.Sobrenome).HasMaxLength(20).IsRequired();
            builder.Property(cliente => cliente.Email).IsRequired();
            builder.Property(cliente => cliente.Telefone).IsRequired();
            builder.Property(cliente => cliente.Cpf).IsRequired();
            builder.Property(cliente => cliente.DataNascimento).IsRequired();
            builder.OwnsOne(cliente => cliente.EnderecoModel, enderecoBuilder =>
            {
                enderecoBuilder.Property(clienteEndere => clienteEndere.Uf).HasMaxLength(100);
                enderecoBuilder.Property(clienteEndere => clienteEndere.Cep).HasMaxLength(100);
                enderecoBuilder.Property(clienteEndere => clienteEndere.Cidade).HasMaxLength(100);
                enderecoBuilder.Property(clienteEndere => clienteEndere.Bairro).HasMaxLength(100);
                enderecoBuilder.Property(clienteEndere => clienteEndere.Rua).HasMaxLength(100);
                enderecoBuilder.Property(clienteEndere => clienteEndere.Numero).HasMaxLength(100);
                enderecoBuilder.Property(clienteEndere => clienteEndere.Complemento).HasMaxLength(100);
            });
        }
    }
}
