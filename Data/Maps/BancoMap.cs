using Despesas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Despesas.Data.Maps

{
    public class BancoMap : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.Deletado).IsRequired();
        }
    }
}

