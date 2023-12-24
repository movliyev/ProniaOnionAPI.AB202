using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Applicatin.Abstractions.Services;
using ProniaOnion202.Applicatin.DTOs.Products;
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
        private readonly IMapper _map;

        public ProductService(IProductRepository repo,IMapper map)
        {
            _repo = repo;
            _map = map;
        }
        public async Task <IEnumerable<ProductItemDto>> GetAllAsync(int page ,int take)
        {
           
            return _map.Map<IEnumerable<ProductItemDto>>(await _repo.GetAllWhere(skip: (page - 1) * take, take: take).ToListAsync());
        }
    }
}
