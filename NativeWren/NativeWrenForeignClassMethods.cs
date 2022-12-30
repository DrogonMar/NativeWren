using System.Runtime.InteropServices;

namespace NativeWren;

[StructLayout(LayoutKind.Sequential)]
public struct NativeWrenForeignClassMethods
{
    public IntPtr pfnAllocate; // WrenForeignMethodFn
    public IntPtr pfnFinalize; // WrenFinalizerFn

    public NativeWrenForeignClassMethods SetAllocateFn(WrenDelegates.WrenForeignMethodFn fn)
    {
        pfnAllocate = Wren.DelegateToPtr(fn);
        return this;
    }

    public NativeWrenForeignClassMethods SetFinalizeFn(WrenDelegates.WrenFinalizerFn fn)
    {
        pfnFinalize = Wren.DelegateToPtr(fn);
        return this;
    }
}