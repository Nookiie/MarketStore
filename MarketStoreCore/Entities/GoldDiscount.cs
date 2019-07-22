using MarketStoreCore.Common.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore.Entities
{
    public class GoldDiscount : BaseDiscount
    {
        public GoldDiscount(decimal turnover)
            : base(turnover)
        {
        }

        public override decimal GetNewRate(decimal turnover)
        {
            decimal rate = GlobalConstants.DEFAULT_PREMIUM_RATE;
            rate = turnover / 100 + rate;

            if (rate < GlobalConstants.DEFAULT_PREMIUM_RATE) 
                rate = GlobalConstants.DEFAULT_PREMIUM_RATE;

            return rate > GlobalConstants.MAX_RATE ? GlobalConstants.MAX_RATE : rate;
        }
    }
}
