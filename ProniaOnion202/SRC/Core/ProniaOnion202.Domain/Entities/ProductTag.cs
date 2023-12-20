using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Domain.Entities
{
    public class ProductTag : BaseEntity
    {
        //Reletional Proporties
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }
}
