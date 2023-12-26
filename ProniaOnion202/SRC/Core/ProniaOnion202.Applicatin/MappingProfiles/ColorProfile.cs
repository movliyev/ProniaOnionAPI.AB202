using AutoMapper;
using ProniaOnion202.Applicatin.DTOs.Colors;
using ProniaOnion202.Applicatin.DTOs.Products;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.MappingProfiles
{
    public class ColorProfile:Profile
    {
        public ColorProfile()
        {
            CreateMap<Color, ColorItemDto>().ReverseMap();
            CreateMap<GetColorDto, Color>().ReverseMap();
            CreateMap<ColorCreateDto, Color>();
        }
    }
}
