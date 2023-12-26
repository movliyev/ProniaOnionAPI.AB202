using ProniaOnion202.Applicatin.DTOs.Categories;
using ProniaOnion202.Applicatin.DTOs.Colors;
using ProniaOnion202.Applicatin.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Abstractions.Services
{
    public interface IColorService
    {
        Task<ICollection<ColorItemDto>> GetAllAsync(int page, int take);
        Task<GetColorDto> GetByIdAsync(int id);
        Task CreateAsync(ColorCreateDto dto);
        Task UpdateAsync(int id, string dto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);

    }
}
