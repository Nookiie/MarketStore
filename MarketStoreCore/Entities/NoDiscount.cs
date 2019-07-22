using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore.Entities
{
    public class NoDiscount : BaseDiscount
    {
        public NoDiscount(decimal turnover) : base(turnover)
        {

        }
    }
}
