using Store.Domain.Entites;

namespace Store.Domain.Repository
{
    public interface IDiscountRepository
    {
        Discount Get(string code);
    }
}
