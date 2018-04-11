using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public class TransactionTests
    {
        [Fact]
        public void WhenTransactionIsCreatedItHasBalanceOfCoinUsed()
        {
            var transaction = new Transaction(TestHelpers.Quarter);
            transaction.Balance.ShouldBe(Coin.QuarterValue);
        }

        [Fact]
        public void WhenBalanceIsAddedToTransactionItIncreasesBalanceBySameValue()
        {
            var transaction = new Transaction(TestHelpers.Quarter);

            transaction.AddBalance(Coin.QuarterValue);
            transaction.Balance.ShouldBe(Coin.QuarterValue * 2);
        }
    }
}
