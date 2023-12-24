using ProniaOnion202.Applicatin.Abstractions.Repositories;
using ProniaOnion202.Domain.Entities;
using ProniaOnion202.Persistance.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion202.Persistance.Implementations.Repositories
{
    internal class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
    }
}
