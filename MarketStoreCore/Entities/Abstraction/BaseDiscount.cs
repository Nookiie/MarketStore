using MarketStoreCore.Common.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore.Entities
{
    /// <summary>
    /// Използването на IDisposable за сигурно изчистване на ресурси след изпълнение
    /// </summary>
    public abstract class BaseDiscount : IDiscount, IDisposable
    {
        public BaseDiscount(decimal turnover)
        {
            DiscountRate = GetNewRate(turnover);

            Dispose();
        }

        public virtual decimal DiscountRate { get; } 

        public virtual decimal GetNewRate(decimal turnover)
        {
            return GlobalConstants.DEFAULT_RATE;
        }

        public virtual decimal GetDiscount(decimal purchaseValue)
        {
            return Math.Round(((DiscountRate / 100) * purchaseValue), 2);
        }

        public virtual decimal GetTotal(decimal purchaseValue)
        {
            return Math.Round(purchaseValue - ((DiscountRate / 100) * purchaseValue), 2);
        }

        public virtual bool HasNoErrors(decimal turnover)
        {
            return GetNewRate(turnover) > 0 && GetDiscount(turnover) > 0 && GetTotal(turnover) > 0;
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
