using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public class VendingMachineTests : VendingMachineTestBase
    {

        [Fact]
        public void VendingMachineExists()
        {
            VendingMachine.ShouldNotBeNull();
            VendingMachine.CurrentTransaction.ShouldBeNull();
        }

        [Fact]
        public void WhenCoinIsAddedToVendingMachineItStartsATransaction()
        {
            var coin = new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight);
            var vendingMachine = new VendingMachine();
            VendingMachine.InsertCoin(new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight));

            VendingMachine.CurrentTransaction.ShouldNotBeNull();
        }


        [Fact]
        public void WhenAValidCoinIsAddedToVendingMachineATransactionIsStartedWithBalanceOfCoinValue()
        {
            var coin = new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight);
            var vendingMachine = new VendingMachine();
            VendingMachine.InsertCoin(new Coin(Coin.QuarterDiameter, Coin.QuarterWidth, Coin.QuarterWeight));

            VendingMachine.CurrentTransaction.ShouldNotBeNull();
            VendingMachine.CurrentTransaction.Balance.ShouldBe(Coin.QuarterValue);
        }

        [Fact]
        public void WhenAnInvalidCoinIsAddedToVendingMachineNoTransactionShouldBeStarted()
        {
            var vendingMachine = new VendingMachine();
            try
            {
                var coin = new Coin(Coin.QuarterDiameter, Coin.DimeWidth, Coin.NickelWeight);

                VendingMachine.InsertCoin(coin);
            }
            catch (Exception ex)
            {
                ex.Message.ShouldBe("InvalidCoin");
            }
            VendingMachine.CurrentTransaction.ShouldBeNull();
        }

        [Fact]
        public void WhenAValidCoinIsAddedToVendingMachineSecondTimeItIncreasesBalance()
        {
            VendingMachine.InsertCoin(TestHelpers.Quarter);
            VendingMachine.CurrentTransaction.Balance.ShouldBe(Coin.QuarterValue);

            VendingMachine.InsertCoin(TestHelpers.Quarter);
            VendingMachine.CurrentTransaction.Balance.ShouldBe(Coin.QuarterValue + Coin.QuarterValue);
        }

        [Fact]
        public void WhenAnInvalidCoinIsAddedToVendingMachineSecondTimeItDoesNotIncreaseBalance()
        {
            VendingMachine.InsertCoin(TestHelpers.Quarter);
            VendingMachine.CurrentTransaction.Balance.ShouldBe(Coin.QuarterValue);
            try
            {
                VendingMachine.InsertCoin(TestHelpers.InvalidCoin);
            }
            catch (Exception ex)
            {
                ex.Message.ShouldBe("InvalidCoin");
            }
            VendingMachine.CurrentTransaction.Balance.ShouldBe(Coin.QuarterValue);
        }
    }
}
