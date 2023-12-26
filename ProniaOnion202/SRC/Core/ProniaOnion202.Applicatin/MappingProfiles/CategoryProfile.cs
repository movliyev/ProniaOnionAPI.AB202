using AutoMapper;
using ProniaOnion202.Applicatin.DTOs.Categories;
using ProniaOnion202.Applicatin.DTOs.Tags;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.MappingProfiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category,CategoryItemDto>().ReverseMap();
            CreateMap<GetCategoryDto, Tag>().ReverseMap();

            CreateMap<Category,IncludeCategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>();

        }
    }
}
