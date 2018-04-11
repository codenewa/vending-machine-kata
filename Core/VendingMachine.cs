using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class VendingMachine
    {
        public Transaction CurrentTransaction { get; set; }
        private Product CurrentSelectedProduct { get; set; }
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

        public VendingMachineResponse GetCurrentState()
        {
            var message = this.CurrentTransaction.Balance.ToString("C2");
            if (this.CurrentSelectedProduct != null)
                message = $"PRICE: {CurrentSelectedProduct.Cost.ToString("C2")}. INSERT COIN.";

            return new VendingMachineResponse
            {
                Product = CurrentSelectedProduct,
                Message = message
            };
        }


        public VendingMachineResponse SelectProduct(ProductCode code)
        {
            if (this.Products.Select(p => p.Code).Count() > 0)
            {
                var product = this.Products.First(p => p.Code == code);
                CurrentSelectedProduct = product;

                if (product.Cost > this.CurrentTransaction.Balance)
                {
                    var errorResponse = new VendingMachineResponse()
                    {
                        Message = $"PRICE: {product.Cost.ToString("C2")}. INSERT COIN.",
                        Product = product
                    };
                    return errorResponse;
                }

                var response = new VendingMachineResponse()
                {
                    Message = "THANK YOU",
                    Product = product,
                };

                if (product.Cost < this.CurrentTransaction.Balance)
                {
                    response.Change = new Change();
                    response.Change.Add(Coin.Quarter);
                }

                this.Products.Remove(product);

                this.CurrentTransaction = null;
                this.CurrentSelectedProduct = null;

                return response;
            }
            else
                return null;
        }


        private void InitializeMachineWithProducts()
        {
            for (var i = 0; i < 5; i++)
            {
                this.Products.Add(new Product() { Cost = 1d, Name = "Cola", Code = ProductCode.Cola });
            }
            for (var i = 0; i < 6; i++)
            {
                this.Products.Add(new Product() { Cost = 0.5d, Name = "Chips", Code = ProductCode.Chips });
            }

            for (var i = 0; i < 6; i++)
            {
                this.Products.Add(new Product() { Cost = 0.65d, Name = "Candy", Code = ProductCode.Candy });
            }
        }
    }
}
