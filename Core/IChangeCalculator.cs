using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public interface IChangeCalculator
    {
        Change GetChange(double amount);
    }
}