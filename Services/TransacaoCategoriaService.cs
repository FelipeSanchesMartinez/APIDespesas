using despesas.ViewModels;
using Despesas.Data;
using Despesas.Models;

namespace despesas.Services
{
    public class TransacaoCategoriaService : ITransacaoCategoriaService
    {
        SqlContext _sqlContext;
        public TransacaoCategoriaService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }
        public void Insert( InsertTransacaoCategoriaViewModel viewModel)
        {
            TransacaoCategoria novaTransacaoCategoria = new TransacaoCategoria()
            {
               Nome = viewModel.Nome,
            };
            novaTransacaoCategoria.CriadoEm = DateTime.Now;
            _sqlContext.TransacaoCategoria.Add(novaTransacaoCategoria);
            _sqlContext.SaveChanges();
        }
    }

}
