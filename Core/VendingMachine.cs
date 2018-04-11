using System;

namespace Core
{
    public class VendingMachine
    {
        public Transaction CurrentTransaction { get; set; }

        public void InsertCoin(Coin coin){
            if(coin.Value != CoinValue.Invalid){
                CurrentTransaction = new Transaction(coin);
            }
        }
    }
}
