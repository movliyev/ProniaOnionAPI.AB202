using ProniaOnion202.Applicatin.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryItemDto>> GetAllAsync(int page, int take);
        Task<GetCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CategoryCreateDto dto);
        Task UpdateAsync(int id, string dto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
