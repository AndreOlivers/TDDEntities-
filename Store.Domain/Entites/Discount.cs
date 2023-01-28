using System;

namespace Store.Domain.Entites
{
    public class Discount : EntityBase
    {
        public Discount(decimal amount, DateTime expiraData)
        {
            Amount = amount;
            ExpiraData = expiraData;
        }
    
        public decimal Amount { get; set; }
        public DateTime ExpiraData{ get; set; }

        public bool Valid()
        {
            return DateTime.Compare(DateTime.Now, ExpiraData) < 0;
        }

        public decimal Value()
        {
            if (Valid())
                return Amount;
            else
                return 0;
        }
    }
}
