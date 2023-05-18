using despesas.Models;
using despesas.ViewModels;

namespace despesas.Services
{
    public interface ICarteiraService
    {
        void Insert(InsertCarteiraViewModel viewModel);
    }
}