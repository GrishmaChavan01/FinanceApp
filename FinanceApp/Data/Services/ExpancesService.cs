using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Services
{
    public class ExpancesService : IExpancesService
    {
        private readonly FinanceAppContext _context;
        public ExpancesService(FinanceAppContext context)
        {
            _context = context;
        }

        public async Task Add(Expances expances)
        {
            _context.Expances.Add(expances);
            await _context.SaveChangesAsync();
             
        }

        public async Task<IEnumerable<Expances>> GetAll()
        {
            var expanses = await _context.Expances.ToListAsync();
            return  expanses;
        }

        public IQueryable GetChartData()
        {
            var data = _context.Expances
                               .GroupBy(e => e.Category)
                               .Select(g => new
                               {
                                   Category = g.Key,
                                   Total = g.Sum(e => e.Amount)
                               });
            return data;
        }
    }
}
