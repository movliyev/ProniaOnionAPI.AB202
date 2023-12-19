using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Domain.Entities
{
    public class Category:BaseNameable
    {
        //Reletional Proporties
        public ICollection<Product>? Products { get; set; }

    }
}
