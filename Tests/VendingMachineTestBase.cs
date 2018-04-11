using System;
using Core;

public class VendingMachineTestBase : IDisposable
{
    protected VendingMachine VendingMachine{get;set;}
    public VendingMachineTestBase()
    {
        VendingMachine = new VendingMachine();
    }
    public void Dispose()
    {
        VendingMachine = null;
    }
}