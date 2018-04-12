using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Change
    {
        public Change()
        {
            this.Coins = new List<Coin>();
        }
        public IList<Coin> Coins { get; private set; }
        public double Value => Coins.Select(c=>c.MonetaryValue).Sum();

        public void Add(Coin coin){
            this.Coins.Add(coin);
        }
    }
}