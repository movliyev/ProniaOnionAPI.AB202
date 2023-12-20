﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Categories;

namespace ProniaOnion202.AB202API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _ser;

        public CategoriesController(ICategoryService ser)
        {
            _ser = ser;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _ser.GetAllAsync(page, take));
        }
       

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto cdto)
        {
            await _ser.CreateAsync(cdto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);


            await _ser.UpdateAsync(id, name);
            return NoContent();

        }
       
    }
}
