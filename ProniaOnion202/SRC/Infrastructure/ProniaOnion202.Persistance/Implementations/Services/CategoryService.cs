﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Categories;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _map;

        public CategoryService(ICategoryRepository repo,IMapper map)
        {
            _repo = repo;
            _map = map;
        }



        public async Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> category = await _repo.GetAll(skip: (page - 1) * take, take: take).ToListAsync();
            return _map.Map<ICollection<CategoryItemDto>>(category);
        }

        //public async Task<CategoryItemDto> GetByIdAsync(int id)
        //{
        //    Category category = await _repo.GetByIdAsync(id);
        //    if (category == null) throw new Exception("Not found");
        //    return new CategoryItemDto
        //    {
        //        Id = category.Id,
        //        Name = category.Name,
        //    };
        //}
        public async Task CreateAsync(CategoryCreateDto dto)
        {
            await _repo.AddAsync(_map.Map<Category>(dto));
           
            await _repo.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, string dto)
        {
            Category exist = await _repo.GetByIdAsync(id);


            exist.Name = dto;
            _repo.Update(exist);

            await _repo.SaveChangesAsync();
        }

        //public async Task DeleteAsync(int id)
        //{
        //    Category exist = await _repo.GetByIdAsync(id);


        //    _repo.Delete(exist);
        //    await _repo.SaveChangesAsync();
        //}


    }
}