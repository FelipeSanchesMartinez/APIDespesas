using despesas.Data.Maps;
using despesas.Models;
using Despesas.Data.Maps;
using Despesas.Models;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Quic;
using Microsoft.EntityFrameworkCore;

namespace Despesas.Data
{
    public class SqlContext : DbContext //Ao criar uzar (crlt .) para intalar a versão mais recente do pacote 
    {
        IConfiguration _configuration;

        public SqlContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<TransacaoCategoria> TransacaoCategoria { get; set; } //Reprsenta a tabela no banco de dados no <>, e apos o nome que queira utilizar.
        public DbSet<Banco> Banco { get; set; }
        public DbSet<Carteira> Carteira { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionstring = _configuration.GetConnectionString("SqLite");
            optionsBuilder.UseSqlite(connectionstring);
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransacaoCategoriaMap());
            modelBuilder.ApplyConfiguration(new BancoMap());
            modelBuilder.ApplyConfiguration(new CarteiraMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());

            base.OnModelCreating(modelBuilder);
        }


    }
}
