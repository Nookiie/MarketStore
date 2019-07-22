using MarketStore.Entities;
using MarketStoreCore.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore.Logic
{
    public class PayDesk
    {
        #region Solution

        public static void GenerateDiscount(decimal turnover, decimal purchaseValue, DiscountType discountType)
        {
            if (purchaseValue < 0)
                throw new ArgumentException("Purchase Value needs to be positive"); // Needs to be replaced later on to coincide with the principles of Defensive Programming

            IDiscount discount;
            switch (discountType)
            {
                case DiscountType.NoDiscount:
                    discount = new NoDiscount(turnover);
                    break;
                case DiscountType.Bronze:
                    discount = new BronzeDiscount(turnover);
                    break;
                case DiscountType.Silver:
                    discount = new SilverDiscount(turnover);
                    break;
                case DiscountType.Gold:
                    discount = new GoldDiscount(turnover);
                    break;
                default:
                    discount = new NoDiscount(turnover);
                    break;
            }

            if (discount.HasNoErrors(turnover))
                PrintInfo(purchaseValue, discount.DiscountRate, discount.GetDiscount(purchaseValue), discount.GetTotal(purchaseValue));
            else
                throw new ArgumentException("All MarketStore Parameters need to be positive");
        } // With Discount

        public static void GenerateDiscount(decimal turnover, decimal purchaseValue)
        {
            IDiscount discount = new NoDiscount(turnover);

            if (purchaseValue < 0)
                throw new ArgumentException("Incorrect Purchase Value");

            if (discount.HasNoErrors(turnover))
                PrintInfo(purchaseValue, discount.DiscountRate, discount.GetDiscount(purchaseValue), discount.GetTotal(purchaseValue));
            else
                throw new ArgumentException("Incorrect MarketStore Parameters");
        } // Without Discount

        #endregion

        #region Helpers

        private static string ToString(decimal purchaseValue, decimal discountRate, decimal discount, decimal total)
        {
            return string.Format("Purchase Value: $" + purchaseValue + "\n" + "Discount Rate: " + discountRate + "%" +
                "\n" + "Discount: $" + discount + "\n" + "Total: $" + total);
        }

        private static void PrintInfo(decimal purchaseValue, decimal discountRate, decimal discount, decimal total)
        {
            Console.WriteLine(ToString(purchaseValue, discountRate, discount, total));
        }

        #endregion
    }
}
