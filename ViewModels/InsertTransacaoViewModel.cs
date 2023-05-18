using despesas.Enums;

namespace despesas.ViewModels
{
    public class InsertTransacaoViewModel
    {
        public double Valor { get; set; }
        public long TransacaoCategoriaId { get; set; }
        public long CarteiraId { get; set; }
        public TransacaoTipo Tipo { get; set; }
    }
}
