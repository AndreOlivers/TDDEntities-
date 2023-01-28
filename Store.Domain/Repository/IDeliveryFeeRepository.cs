namespace Store.Domain.Repository
{
    public interface IDeliveryFeeRepository
    {
        decimal Get(string zipCode);
    }
}
