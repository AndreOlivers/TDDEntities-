using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Store.Domain.Command.Intefaces
{
    public class CreateOrderCommand : Notifiable<Notification>, ICommand
    {
        public CreateOrderCommand()
        {
            Items = new<CreateOrderItemCommand>();
        }

        public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
        {
            Customer = customer;
            ZipCode = zipCode;
            PromoCode = promoCode;
            Items = items;
        }

        public string Customer { get; set; }
        public string ZipCode { get; set; }
        public string PromoCode { get; set; }
        public IList<CreateOrderItemCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Customer, 11, "Customer", "Cliente inválido")
                .IsGreaterThan(ZipCode, 8, "ZipCode", "CEP inválido")
            );
        }
    }
}
