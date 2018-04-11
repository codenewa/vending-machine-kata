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

    }
}
