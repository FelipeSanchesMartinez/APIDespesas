using despesas.Migrations;
using despesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace despesas.Data.Maps
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
      

        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.Deletado).IsRequired();
            builder.Property(x => x.Valor).IsRequired();
            builder.Property(x=> x.Data).IsRequired();
            builder.Property(x => x.TransacaoCategoriaId).IsRequired(); 
            builder.Property(x => x.Tipo).HasConversion<string>().HasMaxLength(20).IsRequired();
            builder.HasOne(transacao => transacao.Categoria)
                .WithMany(transacaoCategoria => transacaoCategoria.Trasacoes)
                .HasForeignKey(transacao => transacao.TransacaoCategoriaId)
                .IsRequired();
            builder.HasOne(trasacao => trasacao.Carteira).WithMany(carteira => carteira.Transacao)
                .HasForeignKey(transacao => transacao.CarteiraId)
                .IsRequired();   

        }
    }
}
