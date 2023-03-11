using DotAgroAPI.Data.Models;
using DotAgroAPI.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotAgroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly IRepository<Salary> _repo;

        public SalaryController(IRepository<Salary> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Salary>>> Get()
        {
            return Ok(await _repo.Get());
        }

        [HttpPost]
        public async Task<ActionResult<Salary>> Post(Salary item)
        {
            return CreatedAtAction("Post", await _repo.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Salary>> Put(int id, Salary item)
        {
            return Ok(await _repo.Put(id, item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Salary>> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
