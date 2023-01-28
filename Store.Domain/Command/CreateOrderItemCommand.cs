using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Command.Intefaces;
using System;

namespace Store.Domain.Command
{
    public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
    {
        public CreateOrderItemCommand() { }

        public CreateOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; }
        public int Quantity { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                 .Requires()
                 .IsGreaterThan(Product.ToString(), 32, "Product", "Produto inválido")
                 .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade inválida")
             );
        }
    }
}
