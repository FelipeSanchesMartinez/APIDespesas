using despesas.Models;
using despesas.ViewModels;
using Despesas.Data;

namespace despesas.Services
{
    public class CarteiraService : ICarteiraService
    {
        SqlContext _sqlContext;
        public CarteiraService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;

        }
        public void Insert(InsertCarteiraViewModel viewModel)
        {
            Carteira carteiraNova = new Carteira()
            {
                BancoId = viewModel.BancoId,
                Nome = viewModel.Nome,
                Saldo = viewModel.Saldo




            };
            carteiraNova.CriadoEm = DateTime.Now;
            _sqlContext.Carteira.Add(carteiraNova);
            _sqlContext.SaveChanges();
        }

    }
}
