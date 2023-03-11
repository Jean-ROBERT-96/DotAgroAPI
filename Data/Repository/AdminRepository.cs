using Microsoft.EntityFrameworkCore;

namespace DotAgroAPI.Data.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Get(string mail, string password)
        {
            var rep = await _context.Admins.Where(x => x.Mail == mail && x.Password == password).FirstOrDefaultAsync();
            if (rep == null)
                return false;

            return true;
        }
    }
}
