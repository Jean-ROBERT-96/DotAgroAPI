using DotAgroAPI.Data.Models;

namespace DotAgroAPI.Data.Repository
{
    public interface IAdminRepository
    {
        Task<bool> Get(string mail, string password);
    }
}
