using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public class ChangeCalculatorTests : VendingMachineTestBase
    {
        [Fact]
        public void ChangeCalculatorReturnsAQuarterFor25()
        {
            var change = ChangeCalculator.GetChange(0.25d);
            change.Coins.ShouldNotBeEmpty();
            change.Value.ShouldBe(0.25d);
            change.Coins.Count.ShouldBe(1);
        }

        [Fact]
        public void ChangeCalculatorReturnsThreeQuartersFor75cents()
        {
            var change = ChangeCalculator.GetChange(0.75d);
            change.Coins.ShouldNotBeEmpty();
            change.Value.ShouldBe(0.75d);
            change.Coins.Count.ShouldBe(3);
        }
    }
}