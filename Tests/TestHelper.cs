using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public static class TestHelpers
    {
        public static Coin Quarter
        {
            get
            {
                return new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight);
            }
        }


        public static Coin Dime
        {
            get
            {
                return new Coin(Coin.DimeDiameter, Coin.DimeWidth, Coin.DimeWeight);
            }
        }

        public static Coin Nickel
        {
            get
            {
                return new Coin(Coin.NickelDiameter, Coin.NickelWidth, Coin.NickelWeight);
            }
        }

        public static Coin InvalidCoin
        {
            get
            {
                return new Coin(Coin.QuarterDiameter, Coin.DimeWidth, Coin.NickelWeight);
            }
        }
    }
}
