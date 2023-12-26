using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Products;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _catrep;
        private readonly IColorRepository _colrepo;
        private readonly IMapper _map;

        public ProductService(IProductRepository repo,ICategoryRepository catrep ,IColorRepository colrepo,IMapper map)
        {
            _repo = repo;
            _catrep = catrep;
            _colrepo = colrepo;
            _map = map;
        }
        public async Task <IEnumerable<ProductItemDto>> GetAllAsync(int page ,int take)
        {
           
            return _map.Map<IEnumerable<ProductItemDto>>(await _repo.GetAllWhere(skip: (page - 1) * take, take: take).ToListAsync());
        }
        public async Task<ProductGetDto> GetByIdAsync(int id)
        {
            Product product=await _repo.GetByIdAsync(id,includes:nameof(Product.Category));
            if (product is null) throw new Exception("Not Found");
           
            return _map.Map<ProductGetDto>(product);
        }
        public async Task CreateAsync(ProductCreateDto dto)
        {

            if (await _repo.IsExistAsync(p => p.Name == dto.Name)) throw new Exception("Same");
            if (!await _catrep.IsExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("Dont");
            Product product=_map.Map<Product>(dto);
            product.ProductColors=new List<ProductColor>();
            if(dto.Colorids is not null)
            {
                foreach (var item in dto.Colorids)
                {
                    if (!await _colrepo.IsExistAsync(c => c.Id == item)) throw new Exception("Dont");
                    product.ProductColors.Add(new ProductColor { ColorId = item });
                }
            }
            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();
            
        }
        public async Task UpdateAsync(int id,ProductPutDto dto)
        {
            Product exist = await _repo.GetByIdAsync(id, true,includes:nameof(Product.ProductColors));
            if (exist.Name!=dto.Name)
                 if (await _repo.IsExistAsync(p => p.Name == dto.Name)) throw new Exception("Same");

            if (dto.CategoryId != exist.CategoryId)
                if (!await _catrep.IsExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("Dont");
            exist =_map.Map(dto,exist);
           
            if(dto.Colorids is not null)
            {
                foreach (var item in dto.Colorids)
                {
                    if (!exist.ProductColors.Any(p => p.ColorId == item))
                    {
                        if (!await _catrep.IsExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("Dont");
                        exist.ProductColors.Add(new ProductColor { ColorId = item });
                    }

                }
                exist.ProductColors = exist.ProductColors.Where(p => dto.Colorids.Any(colid => p.ColorId == colid)).ToList();
            }
            else
            {
                exist.ProductColors=new List<ProductColor>();
            }
           
            _repo.Update(exist);
            await _repo.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            Product exist = await _repo.GetByIdAsync(id);


            _repo.Delete(exist);
            await _repo.SaveChangesAsync();
        }
    }
}
