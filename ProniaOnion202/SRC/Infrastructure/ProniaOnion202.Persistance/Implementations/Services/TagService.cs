using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Categories;
using ProniaOnion202.Applicatin.DTOs.Tags;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repo;
        private readonly IMapper _map;

        public TagService(ITagRepository repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }



        public async Task<ICollection<TagItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> Tag = await _repo.GetAllWhere(skip: (page - 1) * take, take: take,ignorQuery:true).ToListAsync();
            return _map.Map<ICollection<TagItemDto>>(Tag);
        }

        //public async Task<TagItemDto> GetByIdAsync(int id)
        //{
        //    Tag Tag = await _repo.GetByIdAsync(id);
        //    if (Tag == null) throw new Exception("Not found");
        //    return new TagItemDto
        //    {
        //        Id = Tag.Id,
        //        Name = Tag.Name,
        //    };
        //}
        public async Task CreateAsync(TagCreateDto dto)
        {
            await _repo.AddAsync(_map.Map<Tag>(dto));

            await _repo.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, string dto)
        {
            Tag exist = await _repo.GetByIdAsync(id);


            exist.Name = dto;
            _repo.Update(exist);

            await _repo.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {

            Tag tag = await _repo.GetByIdAsync(id,true);
            if (tag == null) throw new Exception("Not Found:)");
            _repo.SoftDelete(tag);
            await _repo.SaveChangesAsync();

        }

    }
}   
