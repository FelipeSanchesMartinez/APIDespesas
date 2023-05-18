using Despesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Despesas.Data.Maps
{
    public class TransacaoCategoriaMap : IEntityTypeConfiguration<TransacaoCategoria>
    {
        public void Configure(EntityTypeBuilder<TransacaoCategoria> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.Deletado).IsRequired();
        }
    }
}
