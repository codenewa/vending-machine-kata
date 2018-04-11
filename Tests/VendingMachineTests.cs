using System;
using Xunit;
using Shouldly;

using Core;

namespace Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void Test1()
        {
            var vendingMachine = new VendingMachine();
            vendingMachine.ShouldNotBeNull();
        }
    }
}
