using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Bebidas.Domain.PedidoBebida;

namespace Projeto.Bebidas.Repository.FluentApi
{
    class PedidoBebidaFA : IEntityTypeConfiguration<PedidoBebidaModel>
    {
        public void Configure(EntityTypeBuilder<PedidoBebidaModel> builder)
        {
            builder.HasKey(pedidoBebida => pedidoBebida.Id);
        }
           
    }
}
