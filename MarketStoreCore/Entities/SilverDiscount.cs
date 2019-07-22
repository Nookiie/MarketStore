using MarketStoreCore.Common.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore.Entities
{
    public class SilverDiscount : BaseDiscount
    {
        public SilverDiscount(decimal turnover) 
            : base(turnover)
        {

        }

        public override decimal GetNewRate(decimal turnover)
        {
            return turnover >= 300 ? 3.5M : GlobalConstants.DEFAULT_PREMIUM_RATE;
        }
    }
}
