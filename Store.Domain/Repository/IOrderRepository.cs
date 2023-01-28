using Store.Domain.Entites;
using System;


namespace Store.Domain.Repository
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
