using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Domain.Entities
{
    public class Tag : BaseNameable
    {
        //Reletional Proporties

        public ICollection<ProductTag> ProductTags { get; set; }

    }
}
