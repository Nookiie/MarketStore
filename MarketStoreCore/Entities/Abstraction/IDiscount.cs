using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore.Entities
{
    public interface IDiscount
    {
        decimal DiscountRate { get; }

        decimal GetDiscount(decimal purchaseValue);

        decimal GetTotal(decimal purchaseValue);

        bool HasNoErrors(decimal purchaseValue);
    }
}
