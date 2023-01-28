using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Entites
{
    public class OrderItem : EntityBase
    {
        public OrderItem(Product product, int quantity)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(product, "Product", "Product invadlid")
                .IsGreaterThan(quantity, 0, "Quantity", "must be greater than zero"));

            Product = product;
            Price = Product != null ? product.Price : 0; 
            Quantity = quantity;
        }

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

       

        public decimal Total()
        {
            return Price * Quantity;    
        }
    }
}
