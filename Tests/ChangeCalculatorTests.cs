using System;
using Xunit;
using Shouldly;

using Core;
using System.Linq;

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
            change.Coins.Count(c => c.MonetaryValue == 0.25).ShouldBe(3);
        }

        [Fact]
        public void ChangeCalculatorReturnsThreeQuartersAndADimeFor85Cents()
        {
            var change = ChangeCalculator.GetChange(0.85d);
            change.Coins.Count.ShouldBe(4);
            change.Coins.Count(c => c.MonetaryValue == 0.25).ShouldBe(3);
            change.Coins.Count(c => c.MonetaryValue == 0.1).ShouldBe(1);
        }

        [Fact]
        public void ChangeCalculatorReturnsTwoQuartersAndANickelFor55Cents()
        {
            var change = ChangeCalculator.GetChange(0.55d);
            change.Coins.Count.ShouldBe(3);
            change.Coins.Count(c => c.MonetaryValue == 0.25).ShouldBe(2);
            change.Coins.Count(c => c.MonetaryValue == 0.05).ShouldBe(1);
        }
    }
}