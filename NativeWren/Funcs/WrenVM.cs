using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenNewVmDelegate _newVMFn;
    private static WrenFreeVmDelegate _freeVmFn;

    public static void InitVmFunctions()
    {
        _newVMFn = GetExport<WrenNewVmDelegate>("wrenNewVM");
        _freeVmFn = GetExport<WrenFreeVmDelegate>("wrenFreeVM");
    }

    public static IntPtr NewVm(ref NativeWrenConfig config)
    {
        CheckInit();
        var handle = GCHandle.Alloc(config, GCHandleType.Pinned);
        IntPtr result;
        unsafe
        {
            fixed (NativeWrenConfig* pin = &config)
            {
                result = _newVMFn.Invoke(pin);
            }

            handle.Free();
        }

        return result;
    }

    public static void FreeVm(IntPtr vm)
    {
        _freeVmFn.Invoke(vm);
    }
}