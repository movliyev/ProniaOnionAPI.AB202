using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Products;

namespace ProniaOnion202.AB202API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ser;

        public ProductsController(IProductService ser)
        {
            _ser = ser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page=1 ,int take=10)
        {
            return Ok(await _ser.GetAllAsync(page, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status200OK,await _ser.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult>Post([FromForm]ProductCreateDto dto)
        {
            await _ser.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id,ProductPutDto dto)
        {
            await _ser.UpdateAsync(id, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _ser.DeleteAsync(id);
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _ser.SoftDeleteAsync(id);
            return NoContent();
        }
        [HttpPatch("{id}/reverse delete")]
        public async Task<IActionResult> ReverseDelete(int id)
        {
            await _ser.ReverseAsync(id);
            return NoContent();
        }
    }
}
