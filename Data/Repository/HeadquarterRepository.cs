using DotAgroAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotAgroAPI.Data.Repository
{
    public class HeadquarterRepository : IRepository<Headquarter>
    {
        private readonly DataContext _context;

        public HeadquarterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Headquarter?> Delete(int id)
        {
            var rep = await _context.Headquarters.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep == null)
                return null;

            _context.Headquarters.Remove(rep);
            await _context.SaveChangesAsync();

            return rep;
        }

        public async Task<List<Headquarter>> Get()
        {
            return await _context.Headquarters.ToListAsync();
        }

        public async Task<Headquarter> Post(Headquarter entity)
        {
            _context.Headquarters.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Headquarter?> Put(int id, Headquarter entity)
        {
            var rep = _context.Headquarters.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep == null)
                return null;

            _context.Attach(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
