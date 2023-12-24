using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion202.Applicatin.Abstractions.Services;

namespace ProniaOnion202.AB202API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICategoryService _ser;

        public ProductsController(ICategoryService ser)
        {
            _ser = ser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page ,int take)
        {
            return Ok(await _ser.GetAllAsync(page, take));
        }
    }
}
