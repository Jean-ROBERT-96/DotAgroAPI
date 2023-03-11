using DotAgroAPI.Data.Models;
using DotAgroAPI.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotAgroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadquarterController : ControllerBase
    {
        private readonly IRepository<Headquarter> _repo;

        public HeadquarterController(IRepository<Headquarter> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Headquarter>>> Get()
        {
            return Ok(await _repo.Get());
        }

        [HttpPost]
        public async Task<ActionResult<Headquarter>> Post(Headquarter item)
        {
            return CreatedAtAction("Post", await _repo.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Headquarter>> Put(int id, Headquarter item)
        {
            return Ok(await _repo.Put(id, item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Headquarter>> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
