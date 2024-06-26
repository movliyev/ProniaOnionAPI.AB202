﻿using ProniaOnion202.Applicatin.DTOs.Categories;
using ProniaOnion202.Applicatin.DTOs.Colors;
using ProniaOnion202.Applicatin.DTOs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.Abstractions.Services
{
    public interface ITagService
    {
        Task<ICollection<TagItemDto>> GetAllAsync(int page, int take);
        Task<GetTagDto> GetByIdAsync(int id);

        Task CreateAsync(TagCreateDto dto);
        Task UpdateAsync(int id, string dto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task ReverseAsync(int id);

    }
}
