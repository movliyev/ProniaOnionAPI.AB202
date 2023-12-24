using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Applicatin.DTOs.Products
{
    public record ProductItemDto(int Id,string Name,decimal Price,string SKU);
    
}
