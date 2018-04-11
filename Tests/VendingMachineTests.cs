using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void VendingMachineExists()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.ShouldNotBeNull();
        }

        [Fact]
        public void WhenCoinIsAddedToVendingMachineItStartsATransaction()
        {
            var coin = new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight);
            var vendingMachine = new VendingMachine();

        }

    }
}
