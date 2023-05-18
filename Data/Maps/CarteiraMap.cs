using Despesas.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using despesas.Models;

namespace Despesas.Data.Maps

{
    public class CarteiraMap : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Saldo).IsRequired();
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.Deletado).IsRequired();
            builder.HasOne(x => x.Banco).WithMany(x => x.Carteiras).HasForeignKey(x => x.BancoId).IsRequired();
        }
    }
}

