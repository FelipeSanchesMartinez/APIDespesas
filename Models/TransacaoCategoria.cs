using despesas.Models;

namespace Despesas.Models
{
    public class TransacaoCategoria: Entidade
    {
        public string Nome { get; set; }
        public List<Transacao> Trasacoes { get; set; }
    }
}
