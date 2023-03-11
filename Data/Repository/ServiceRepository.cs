using DotAgroAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotAgroAPI.Data.Repository
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly DataContext _context;

        public ServiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Service?> Delete(int id)
        {
            var rep = await _context.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (rep == null)
                return null;

            _context.Services.Remove(rep);
            await _context.SaveChangesAsync();

            return rep;
        }

        public async Task<List<Service>> Get()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<Service> Post(Service entity)
        {
            _context.Services.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Service?> Put(int id, Service entity)
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
