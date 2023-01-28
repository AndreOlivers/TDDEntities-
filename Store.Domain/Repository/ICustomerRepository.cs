using Store.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Repository
{
    public interface ICustomerRepository
    {
        Customer Get(string document);
    }
}
