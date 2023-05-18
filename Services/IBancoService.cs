using despesas.ViewModels;
using Despesas.Models;

namespace despesas.Services
{
    public interface IBancoService
    {
        void Insert(InsertBancoViewModel viewModel);
    }
}