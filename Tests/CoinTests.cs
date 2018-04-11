using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public class CoinTests
    {
        [Fact]
        public void CoinNeedsToHaveDiameterWidthAndWeight()
        {
            var coin = new Coin(24.26, 1.75, 5.67);
            coin.Diameter.ShouldBe(24.26);
            coin.Width.ShouldBe(1.75);
            coin.Weight.ShouldBe(5.67);
        }

        [Theory]
        [InlineData(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight, CoinValue.Quarter)]
        [InlineData(Coin.NickelDiameter, Coin.NickelWidth, Coin.NickelWeight, CoinValue.Nickel)]
        [InlineData(Coin.DimeDiameter, Coin.DimeWidth, Coin.DimeWeight, CoinValue.Dime)]
        [InlineData(Coin.QuarterDiameter, Coin.DimeWidth, Coin.NickelWeight, CoinValue.Invalid)]
        public void CoinReturnsValueForValidCoid(double diameter, double width, double weight, CoinValue coinValue)
        {
            var coin = new Coin(diameter, width, weight);
            coin.Value.ShouldBe(coinValue);
        }

        [Theory]
        [InlineData(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight, 0.25d)]
        [InlineData(Coin.NickelDiameter, Coin.NickelWidth, Coin.NickelWeight, 0.05d)]
        [InlineData(Coin.DimeDiameter, Coin.DimeWidth, Coin.DimeWeight, 0.1d)]
        [InlineData(Coin.QuarterDiameter, Coin.DimeWidth, Coin.NickelWeight, 0d)]
        public void CoinReturnsMonetaryValueForValidCoid(double diameter, double width, double weight, double moneyValue)
        {
            var coin = new Coin(diameter, width, weight);
            coin.MonetaryValue.ShouldBe(moneyValue);
        }
    }
}
