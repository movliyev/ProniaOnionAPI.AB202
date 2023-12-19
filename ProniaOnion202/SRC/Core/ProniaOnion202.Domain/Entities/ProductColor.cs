using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Domain.Entities
{
    public class ProductColor:BaseEntity
    {
        //Reletional Proporties
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;
    }
}
