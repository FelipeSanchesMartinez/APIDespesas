using despesas.Models;
using despesas.ViewModels;
using Despesas.Data;
using Despesas.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace despesas.Services
{
    public class BancoService : IBancoService
    {
        SqlContext _sqlContext;
        public BancoService(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Insert(InsertBancoViewModel viewModel)
        {
            Banco bancoNovo = new Banco()
            {
                Nome = viewModel.Nome
             
            };

            bancoNovo.CriadoEm = DateTime.Now;
            _sqlContext.Banco.Add(bancoNovo);
            _sqlContext.SaveChanges();

        }


    }
}
