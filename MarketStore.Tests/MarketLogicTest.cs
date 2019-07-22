using MarketStore.Entities;
using MarketStore.Logic;
using MarketStoreCore.Common.Enums;
using MarketStoreCore.Common.Shared.Constants;
using System;
using Xunit;

namespace MarketStore.MarketLogicTest
{
    public static class MarketLogicTest
    {
        [Fact]
        public static void AssertTotalIsProperlyCalculated()
        {
            DiscountType discountTypes = new DiscountType();

            IDiscount goldDiscount = new GoldDiscount(120);
            IDiscount silverDiscount = new SilverDiscount(220);
            IDiscount bronzeDiscount = new BronzeDiscount(220);
            IDiscount noDiscount = new NoDiscount(220);

            var defaultPurchaseValue = 320;
            var expectedGoldTotal = 20;
            var expectedSilverTotal = 20;
            var expectedBronzeTotal = 20;
            var expectedNoTotal = 20;

            switch (discountTypes)
            {
                case DiscountType.Bronze:
                    Assert.Equal(expectedGoldTotal, goldDiscount.GetTotal(defaultPurchaseValue));
                    break;
                case DiscountType.Silver:
                    Assert.Equal(expectedSilverTotal, silverDiscount.GetTotal(defaultPurchaseValue));
                    break;
                case DiscountType.Gold:
                    Assert.Equal(expectedBronzeTotal, bronzeDiscount.GetTotal(defaultPurchaseValue));
                    break;
                default:
                    Assert.Equal(expectedNoTotal, noDiscount.GetTotal(defaultPurchaseValue));
                    break;
            }
        }

        [Fact]
        public static void AssertDiscountRateIsCorrect()
        {
            DiscountType discountTypes = new DiscountType();

            IDiscount goldDiscount = new GoldDiscount(220);
            IDiscount silverDiscount = new SilverDiscount(420);
            IDiscount bronzeDiscount = new BronzeDiscount(220);
            IDiscount noDiscount = new NoDiscount(220);

            var expectedGoldDiscountRate = 4;
            var expectedSilverDiscountRate = 3.5M;
            var expectedBronzeDiscountRate = 1;
            var expecteNoDiscountRate = GlobalConstants.DEFAULT_RATE;

            switch (discountTypes)
            {
                case DiscountType.Bronze:
                    Assert.Equal(expectedBronzeDiscountRate, bronzeDiscount.DiscountRate);
                    break;
                case DiscountType.Silver:
                    Assert.Equal(expectedSilverDiscountRate, silverDiscount.DiscountRate);
                    break;
                case DiscountType.Gold:
                    Assert.Equal(expectedGoldDiscountRate, goldDiscount.DiscountRate);
                    break;
                default:
                    Assert.Equal(expecteNoDiscountRate, noDiscount.DiscountRate);
                    break;
            }
        }

        [Fact]
        public static void AssertRateIsNotAboveMax()
        {
            var maxValue = decimal.MaxValue;

            IDiscount goldDiscount = new GoldDiscount(maxValue);
            IDiscount silverDiscount = new SilverDiscount(maxValue);
            IDiscount bronzeDiscount = new BronzeDiscount(maxValue);
            IDiscount noDiscount = new NoDiscount(maxValue);

            Assert.True(goldDiscount.DiscountRate <= GlobalConstants.MAX_RATE);
            Assert.True(silverDiscount.DiscountRate <= GlobalConstants.MAX_RATE);
            Assert.True(bronzeDiscount.DiscountRate <= GlobalConstants.MAX_RATE);
            Assert.True(noDiscount.DiscountRate <= GlobalConstants.MAX_RATE);
        }

        [Fact]
        public static void AssertRateIsNotBelowDefault()
        {
            var minValue = decimal.MinValue;

            IDiscount goldDiscount = new GoldDiscount(minValue);
            IDiscount silverDiscount = new SilverDiscount(minValue);
            IDiscount bronzeDiscount = new BronzeDiscount(minValue);
            IDiscount noDiscount = new NoDiscount(minValue);

            Assert.True(goldDiscount.DiscountRate >= GlobalConstants.DEFAULT_PREMIUM_RATE);
            Assert.True(silverDiscount.DiscountRate >= GlobalConstants.DEFAULT_PREMIUM_RATE);
            Assert.True(bronzeDiscount.DiscountRate >= GlobalConstants.DEFAULT_RATE);
            Assert.True(noDiscount.DiscountRate >= GlobalConstants.DEFAULT_RATE);
        }
    }
}
