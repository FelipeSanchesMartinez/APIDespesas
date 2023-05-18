using despesas.Models;

namespace Despesas.Models
{
    public class Banco : Entidade
    {
        public string Nome { get; set; }
        
        // Entity Framework (nesse caso banco pode estar em varias carteira )
        public List <Carteira> Carteiras { get; set; }
    }
}
