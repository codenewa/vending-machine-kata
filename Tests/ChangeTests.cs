using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public class ChangeTests
    {
        [Fact]
        public void ChangeTotalIsSumOfAllCoins()
        {
            var change = new Change();
            change.Add(TestHelpers.Quarter);
            change.Add(TestHelpers.Quarter);
            change.Add(TestHelpers.Dime);

            change.Value.ShouldBe(TestHelpers.Quarter.MonetaryValue * 2 + TestHelpers.Dime.MonetaryValue);
        }
    }
}
