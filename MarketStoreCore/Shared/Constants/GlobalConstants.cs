using System;
using System.Collections.Generic;
using System.Text;

namespace MarketStoreCore.Common.Shared.Constants
{
    /// <summary>
    /// Shared usually needs a dedicated Project but since this is small, I decided to put everything in Common
    /// </summary>
    public static class GlobalConstants
    {
        public static readonly decimal DEFAULT_RATE = 0;

        public static readonly decimal DEFAULT_PREMIUM_RATE = 2;

        public static readonly decimal MAX_RATE = 10;
    }
}
