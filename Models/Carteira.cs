using Despesas.Models;

namespace despesas.Models
{
    public class Carteira : Entidade
    {
       
        public long BancoId { get; set; }
        public string Nome { get; set; }    
        public double Saldo { get; set; }

        //Entity framerork (carteira pode ter 1 banco)
        public Banco Banco { get; set; }
        public List<Transacao> Transacao { get; set; }
    }

}
