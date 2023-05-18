using despesas.Enums;
using Despesas.Models;

namespace despesas.Models
{
    public class Transacao: Entidade
    {
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public long TransacaoCategoriaId { get; set; }
        public long CarteiraId { get; set; }
        public TransacaoTipo Tipo { get; set; }

        public TransacaoCategoria Categoria { get; set; }
        public Carteira Carteira { get; set; }

     

    }
}
