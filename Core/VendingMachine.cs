﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class VendingMachine
    {
        private readonly IChangeCalculator _changeCalculator;
        public VendingMachine(IChangeCalculator changeCalculator)
        {
            _changeCalculator = changeCalculator;
            Products = new List<Product>();
            InitializeMachineWithProducts();
        }
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
            var message = this.CurrentTransaction?.Balance.ToString("C2") ?? "INSERT COIN";

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
            if (this.Products.Count(p => p.Code == code) > 0)
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
                    response.Change = _changeCalculator.GetChange(CurrentTransaction.Balance - product.Cost);
                }

                this.Products.Remove(product);

                this.CurrentTransaction = null;
                this.CurrentSelectedProduct = null;

                return response;
            }
            else
            {
                var response = new VendingMachineResponse()
                {
                    Message = "SOLD OUT",
                    Product = null
                };
                return response;
            };
        }

        public VendingMachineResponse ReturnCoins()
        {
            var response = new VendingMachineResponse();
            response.Product = null;
            response.Change = _changeCalculator.GetChange(this.CurrentTransaction.Balance);

            this.CurrentTransaction = null;
            this.CurrentSelectedProduct = null;
            return response;
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
