using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Colors;

namespace ProniaOnion202.AB202API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _ser;

        public ColorsController(IColorService ser)
        {


            _ser = ser;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _ser.GetAllAsync(page, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK, await _ser.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ColorCreateDto tdto)
        {
            await _ser.CreateAsync(tdto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);


            await _ser.UpdateAsync(id, name);
            return NoContent();

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _ser.SoftDeleteAsync(id);
            return NoContent();
        }

    }
}
