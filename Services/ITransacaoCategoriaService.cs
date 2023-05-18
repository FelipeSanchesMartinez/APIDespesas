using despesas.Models;
using despesas.ViewModels;

namespace despesas.Services
{
    public interface ITransacaoCategoriaService
    {
        void Insert(InsertTransacaoCategoriaViewModel viewModel );
    }
}