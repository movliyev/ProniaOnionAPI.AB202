using ProniaOnion202.Applicatin.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllAsync(int page, int take);
        Task<ProductGetDto> GetByIdAsync(int id);
        Task CreateAsync(ProductCreateDto dto);
        Task UpdateAsync(int id, ProductPutDto dto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseAsync(int id);
    }
}
