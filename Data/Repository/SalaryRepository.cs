using DotAgroAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotAgroAPI.Data.Repository
{
    public class SalaryRepository : IRepository<Salary>
    {
        private readonly DataContext _context;

        public SalaryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Salary?> Delete(int id)
        {
            var rep = await _context.Salaries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep == null)
                return null;

            _context.Salaries.Remove(rep);
            await _context.SaveChangesAsync();

            return rep;
        }

        public async Task<List<Salary>> Get()
        {
            return await _context.Salaries.ToListAsync();
        }

        public async Task<Salary> Post(Salary entity)
        {
            _context.Salaries.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Salary?> Put(int id, Salary entity)
        {
            var rep = _context.Salaries.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep == null)
                return null;

            _context.Attach(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
