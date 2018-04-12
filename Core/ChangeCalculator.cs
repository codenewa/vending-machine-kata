using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class ChangeCalculator : IChangeCalculator
    {
        public Change GetChange(double amount)
        {
            var change = new Change();
            var cents = (int)(amount * 100);

            var numQuarters = cents / 25;

            cents = cents - numQuarters * 25;
            var numDimes = cents / 10;

            cents = cents - numDimes * 10;
            var numNickels = cents / 5;

            for (int i = 0; i < numQuarters; i++)
                change.Add(Coin.Quarter);

            for (int i = 0; i < numDimes; i++)
                change.Add(Coin.Dime);

            for (int i = 0; i < numNickels; i++)
                change.Add(Coin.Nickel);

            return change;
        }
    }
}