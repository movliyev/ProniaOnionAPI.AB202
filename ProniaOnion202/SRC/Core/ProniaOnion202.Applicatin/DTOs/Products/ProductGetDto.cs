using ProniaOnion202.Applicatin.DTOs.Categories;
using ProniaOnion202.Applicatin.DTOs.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.DTOs.Products
{
    public record ProductGetDto(int Id, string Name, decimal Price, string SKU,string? Description,int CategoryId,IncludeCategoryDto Category);

}
