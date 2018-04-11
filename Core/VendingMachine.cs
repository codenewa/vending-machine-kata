using System;

namespace Core
{
    public class VendingMachine
    {
        public Transaction CurrentTransaction { get; set; }

        public void InsertCoin(Coin coin)
        {
            if (coin.Value == CoinValue.Invalid)
                throw new Exception("InvalidCoin");
            if (CurrentTransaction == null)
                CurrentTransaction = new Transaction(coin);
            else
                CurrentTransaction.AddBalance(coin.MonetaryValue);
        }
    }
}
