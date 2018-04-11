using System;

namespace Core
{
    public class Transaction
    {
        public double Balance { get; private set; }
        public Transaction(Coin coin)
        {
            this.Balance = coin.MonetaryValue;
        }
    }
}