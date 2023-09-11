using ApiDapper.Entities;
using ApiDapper.Interfaces.Repositories;
using ApiDapper.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CosaController : Controller
    {
        private readonly ICosaService _cosaService;
        public CosaController(ICosaService cosaRepository)
        {
            _cosaService = cosaRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cosaService.GetAll();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _cosaService.GetById(id);
            if(result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Insert(Cosa entity)
        {
            var result = await _cosaService.Insert(entity);
            if(result == 1) return Ok(new { created=true});
            return Ok(new { created = false });
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, Cosa entity)
        {
            var result = await _cosaService.Update(id, entity);
            if (result == 1) return Ok(new { updated = true });
            return Ok(new { updated = false });
        }
        [HttpDelete]
        public async Task<IActionResult> delete(int id)
        {
            var result = await _cosaService.DeleteById(id);
            if (result == 1) return Ok(new { deleted = true });
            return Ok(new { deleted = false });
        }
    }
}
