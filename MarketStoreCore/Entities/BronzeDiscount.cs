using MarketStoreCore.Common.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore.Entities
{
    public class BronzeDiscount : BaseDiscount
    {
        public BronzeDiscount(decimal turnover) 
            : base(turnover)
        {

        }

        public override decimal GetNewRate(decimal turnover)
        {
            if (turnover >= 100 && turnover <= 300)
                return 1;
            else if (turnover >= 300)
                return 2.5M;
            else
                return GlobalConstants.DEFAULT_RATE;
        }
    }
}

