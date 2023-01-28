using System;
using Store.Domain.Entites;
using System.Collections.Generic;

namespace Store.Domain.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get(IEnumerable<Guid> ids);
    }
}
