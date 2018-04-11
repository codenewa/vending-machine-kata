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
            vendingMachine.CurrentTransaction.ShouldBeNull();
        }

        [Fact]
        public void WhenCoinIsAddedToVendingMachineItStartsATransaction()
        {
            var coin = new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight);
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight));

            vendingMachine.CurrentTransaction.ShouldNotBeNull();
        }


        [Fact]
        public void WhenAValidCoinIsAddedToVendingMachineATransactionIsStartedWithBalanceOfCoinValue()
        {
            var coin = new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight);
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight));

            vendingMachine.CurrentTransaction.ShouldNotBeNull();
            vendingMachine.CurrentTransaction.Balance.ShouldBe(Coin.QuarterValue);
        }

        [Fact]
        public void WhenAnInvalidCoinIsAddedToVendingMachineNoTransactionShouldBeStarted()
        {
            var coin = new Coin(Coin.QuarterDiameter, Coin.DimeWidth, Coin.NickelWeight);
            var vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(coin);

            vendingMachine.CurrentTransaction.ShouldBeNull();
        }
    }
}
