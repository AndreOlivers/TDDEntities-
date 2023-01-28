using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Store.Domain.Entites
{
    public class Order : EntityBase
    {
        public Order(Customer customer, decimal deliveryFee, Discount discount)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(customer, "Customer", "Customer invalid"));

            Discount = discount;
            Customer = customer;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Items = new List<OrderItem>();
            DeliveryFee = deliveryFee;
            Status = EOrderStatus.WaitingPayment;
        }

        public Discount Discount { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal DeliveryFee { get; set; }
        public EOrderStatus Status { get; set; }

        public void AddItem(Product product, int quantity)
        {
            var item = new OrderItem(product, quantity);
            if (item.IsValid)
                Items.Add(item);
        }

        public void Pay(decimal amount)
        {
            if (amount == Total())
                this.Status = EOrderStatus.WaitingDelivery;
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFee;
            total -= Discount != null ? Discount.Value() : 0;

            return total;
        }
    }
}
