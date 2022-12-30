using NUnit.Framework;

namespace NativeWren.Tests;

public class Simple
{
    [Test]
    public void Test1()
    {
        var config = new NativeWrenConfig();
        Wren.InitConfig(ref config);
        config.SetWriteFn((ptr, text) =>
        {
            //Wren will call this twice, one with the wanted string and the other a new line.
            if (text is not ("Hello, world!" or "\n"))
                Assert.Fail();
        });
        var vm = Wren.NewVm(ref config);
        Wren.Interpret(vm, "main", "System.print(\"Hello, world!\")");
        Wren.FreeVm(vm);
    }
}