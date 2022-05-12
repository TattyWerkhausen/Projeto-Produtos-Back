using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Bebidas.Repository.FluentApi
{
  public class PedidoFA:IEntityTypeConfiguration<PedidoModel>
    {
        public void Configure(EntityTypeBuilder<PedidoModel> builder)
        {
            //tenho uma chave principal (Id)
            builder.HasKey(pedido => pedido.Id);
            //tenho varios pedidos bebidas (ListaPedidoBebida), que tem um pedido (PedidoModel)
            builder.HasMany(pedido => pedido.ListaPedidoBebida).WithOne(pedidoBebida => pedidoBebida.PedidoModel)
                //que tem uma chave extrangera (PedidoId)
                .HasForeignKey(pedidoBebida => pedidoBebida.PedidoId);

            //tenho um cliente (ClienteModel), que tem varios pedidos (ListaPedidos),
            builder.HasOne(pedido => pedido.ClienteModel).WithMany(cliente => cliente.ListaPedidos)
                // que tenho uma chave extrangera (clienteModelId)
                .HasForeignKey(pedidos => pedidos.ClienteModelId);
            builder.OwnsOne(pedido => pedido.PedidoEndereco, enderecoBuilder =>
            {
                enderecoBuilder.Property(pedidoEndere => pedidoEndere.Uf).HasMaxLength(100);
                enderecoBuilder.Property(pedidoEndere => pedidoEndere.Cep).HasMaxLength(100);
                enderecoBuilder.Property(pedidoEndere => pedidoEndere.Cidade).HasMaxLength(100);
                enderecoBuilder.Property(pedidoEndere => pedidoEndere.Bairro).HasMaxLength(100);
                enderecoBuilder.Property(pedidoEndere => pedidoEndere.Rua).HasMaxLength(100);
                enderecoBuilder.Property(pedidoEndere => pedidoEndere.Numero).HasMaxLength(100);
                enderecoBuilder.Property(pedidoEndere => pedidoEndere.Complemento).HasMaxLength(100);
            });


        }

    }
}
