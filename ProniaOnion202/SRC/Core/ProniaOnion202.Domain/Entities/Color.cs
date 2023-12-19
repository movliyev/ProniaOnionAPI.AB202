using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Domain.Entities
{
    public class Color:BaseNameable
    {
        //Reletional Proporties

        public ICollection<ProductColor> ProductColors { get; set; }

    }
}
