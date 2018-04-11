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
            CurrentTransaction = new Transaction(coin);
        }
    }
}
