using System;
using Core;

public class VendingMachineTestBase : IDisposable
{
    protected VendingMachine VendingMachine { get; set; }
    protected IChangeCalculator ChangeCalculator { get; set; }
    public VendingMachineTestBase()
    {
        VendingMachine = new VendingMachine();
        ChangeCalculator = new ChangeCalculator();
    }
    public void Dispose()
    {
        VendingMachine = null;
        ChangeCalculator = null;
    }

}