using AutoMapper;
using ProniaOnion202.Applicatin.DTOs.Products;
using ProniaOnion202.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductItemDto, Product>().ReverseMap();

        }
    }
}
