using despesas.Models;
using despesas.ViewModels;
using Despesas.Data;

namespace despesas.Services
{
    public class TransacaoService : ITransacaoService
    {
        SqlContext _sqlContext;
        public TransacaoService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }


        public void Insert(InsertTransacaoViewModel viewModel)
        {
            Transacao transacao = new Transacao() 
            { 
                Valor = viewModel.Valor,
                CarteiraId = viewModel.CarteiraId, 
                TransacaoCategoriaId = viewModel.TransacaoCategoriaId,
                Tipo = viewModel.Tipo
            };
            Carteira transacaoCarteira = _sqlContext.Carteira.FirstOrDefault(carteira => carteira.Id == transacao.CarteiraId);
            if (transacao.Tipo == Enums.TransacaoTipo.Despesa)
            {
                transacaoCarteira.Saldo = transacaoCarteira.Saldo - transacao.Valor;
            }
            else
            {
                transacaoCarteira.Saldo = transacaoCarteira.Saldo + transacao.Valor;
            }

            transacao.CriadoEm= DateTime.Now;
            _sqlContext.Transacao.Add(transacao);
            _sqlContext.Carteira.Update(transacaoCarteira);
            _sqlContext.SaveChanges();


        }
    }
}
