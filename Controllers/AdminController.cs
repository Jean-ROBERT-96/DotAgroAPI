using DotAgroAPI.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotAgroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _repo;

        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{mail}/{password}")]
        public async Task<ActionResult<bool>> Get(string mail, string password)
        {
            return Ok(await _repo.Get(mail, password));
        }
    }
}
