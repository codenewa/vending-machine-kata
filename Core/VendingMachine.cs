using System;
using System.Collections.Generic;

namespace Core
{
    public class VendingMachine
    {
        public Transaction CurrentTransaction { get; set; }

        public IList<Product> Products { get; set; }

        public VendingMachine()
        {
            Products = new List<Product>();
            InitializeMachineWithProducts();
        }
        public void InsertCoin(Coin coin)
        {
            if (coin.Value == CoinValue.Invalid)
                throw new Exception("InvalidCoin");
            if (CurrentTransaction == null)
                CurrentTransaction = new Transaction(coin);
            else
                CurrentTransaction.AddBalance(coin.MonetaryValue);
        }

        public string GetCurrentBalance()
        {
            return this.CurrentTransaction.Balance.ToString("C2");
        }


        private void InitializeMachineWithProducts()
        {
            for (var i = 0; i < 5; i++)
            {
                this.Products.Add(new Product() { Cost = 1d, Name = "Cola" });
            }
            for (var i = 0; i < 6; i++)
            {
                this.Products.Add(new Product() { Cost = 0.5d, Name = "Chips" });
            }

            for (var i = 0; i < 6; i++)
            {
                this.Products.Add(new Product() { Cost = 0.65d, Name = "Candy" });
            }
        }
    }
}
