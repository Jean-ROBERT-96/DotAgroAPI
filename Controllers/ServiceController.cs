using DotAgroAPI.Data.Models;
using DotAgroAPI.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotAgroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Service> _repo;

        public ServiceController(IRepository<Service> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Service>>> Get()
        {
            return Ok(await _repo.Get());
        }

        [HttpPost]
        public async Task<ActionResult<Service>> Post(Service item)
        {
            return CreatedAtAction("Post", await _repo.Post(item));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> Put(int id, Service item)
        {
            return Ok(await _repo.Put(id, item));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> Delete(int id)
        {
            return Ok(await _repo.Delete(id));
        }
    }
}
