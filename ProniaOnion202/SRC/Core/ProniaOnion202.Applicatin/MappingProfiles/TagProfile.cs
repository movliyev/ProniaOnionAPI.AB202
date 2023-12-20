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
    public class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagItemDto>().ReverseMap();
            CreateMap<TagCreateDto, Tag>();

        }
    }
}
