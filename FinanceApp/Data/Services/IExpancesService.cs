using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpancesService
    {
        Task<IEnumerable<Expances>> GetAll();
        Task Add(Expances expances);

        IQueryable GetChartData();
    }
}
