using despesas.Models;
using despesas.ViewModels;

namespace despesas.Services
{
    public interface ITransacaoService
    {
        void Insert(InsertTransacaoViewModel viewModel);
    }
}