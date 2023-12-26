using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Colors;
using ProniaOnion202.Applicatin.DTOs.Products;
using ProniaOnion202.Applicatin.DTOs.Tags;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Services
{
    public class ColorService:IColorService
    {
        private readonly IColorRepository _repo;
        private readonly IMapper _map;

        public ColorService(IColorRepository repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }



        public async Task<ICollection<ColorItemDto>> GetAllAsync(int page, int take)
        {
            ICollection<Color> color = await _repo.GetAllWhere(skip: (page - 1) * take, take: take, ignorQuery: true).ToListAsync();
            return _map.Map<ICollection<ColorItemDto>>(color);
        }

        public async Task<GetColorDto> GetByIdAsync(int id)
        {
            Color color = await _repo.GetByIdAsync(id);
            if (color is null) throw new Exception("Not Found");

            return _map.Map<GetColorDto>(color);
        }
        public async Task CreateAsync(ColorCreateDto dto)
        {
            await _repo.AddAsync(_map.Map<Color>(dto));

            await _repo.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id, string name)
        {
            Color exist = await _repo.GetByIdAsync(id);


            exist.Name = name;
            _repo.Update(exist);

            await _repo.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {

            Color color = await _repo.GetByIdAsync(id, true);
            if (color == null) throw new Exception("Not Found:)");
            _repo.SoftDelete(color);
            await _repo.SaveChangesAsync();

        }
        public async Task DeleteAsync(int id)
        {
            Color exist = await _repo.GetByIdAsync(id);


            _repo.Delete(exist);
            await _repo.SaveChangesAsync();
        }

       
    }
}
