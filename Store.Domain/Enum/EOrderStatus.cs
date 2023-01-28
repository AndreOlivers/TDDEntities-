using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Enum
{
    public enum EOrderStatus
    {
        WaitingPayment = 0,
        WaitingDelivery = 1,
        Canceled = 2,
    }
}
