using System;
using Xunit;
using Shouldly;

using Core;
using System.Linq;

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

        [Fact]
        public void WhenCurrentBalanceIsRequestedItReturnsTheCurrentBalance()
        {
            VendingMachine.InsertCoin(TestHelpers.Quarter);
            VendingMachine.GetCurrentBalance().ShouldBe("$0.25");
        }

        [Fact]
        public void VendingMachineShouldHaveSelectableProducts()
        {
            VendingMachine.Products.ShouldNotBeNull();
            VendingMachine.Products.ShouldNotBeEmpty();
            VendingMachine.Products.Where(p => p.Name.Equals("Cola")).ToList().ShouldNotBeEmpty();
            VendingMachine.Products.Where(p => p.Name.Equals("Chips")).ToList().ShouldNotBeEmpty();
            VendingMachine.Products.Where(p => p.Name.Equals("Candy")).ToList().ShouldNotBeEmpty();
        }


        [Fact]
        public void WhenProductIsSelectedAndThereIsEnoughBalanceItReturnsProductAndThankYouMessage()
        {
            VendingMachine.InsertCoin(TestHelpers.Quarter);
            VendingMachine.InsertCoin(TestHelpers.Quarter);
            VendingMachine.InsertCoin(TestHelpers.Quarter);
            VendingMachine.InsertCoin(TestHelpers.Quarter);

            var response = VendingMachine.SelectProduct(ProductCode.Cola);
            response.Product.ShouldNotBeNull();
            response.Product.Code.ShouldBe(ProductCode.Cola);
            response.Message.ShouldBe("THANK YOU");

        }
    }
}
