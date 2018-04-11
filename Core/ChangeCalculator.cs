using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class ChangeCalculator: IChangeCalculator
    {
        public Change GetChange(double amount)
        {
            var cents = (int) (amount * 100);
            var change = new Change();

            var numQuarters = cents/25;
            
            for(int i =0 ;i<numQuarters;i++){
                change.Add(Coin.Quarter);
            }

            return change;
        }
    }
}