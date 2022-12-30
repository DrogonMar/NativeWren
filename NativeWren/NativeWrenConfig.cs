using System.Runtime.InteropServices;

namespace NativeWren;

[StructLayout(LayoutKind.Explicit, Size = 88)]
public struct NativeWrenConfig
{
    [FieldOffset(0)] public IntPtr pfnReallocateFn; // WrenReallocateFn
    [FieldOffset(8)] public IntPtr pfnResolveModuleFn; // WrenResolveModuleFn
    [FieldOffset(16)] public IntPtr pfnLoadModuleFn; // WrenLoadModuleFn
    [FieldOffset(24)] public IntPtr pfnBindForeignMethodFn; // WrenBindForeignMethodFn
    [FieldOffset(32)] public IntPtr pfnBindForeignClassFn; // WrenBindForeignClassFn
    [FieldOffset(40)] public IntPtr pfnWriteFn; // WrenWriteFn
    [FieldOffset(48)] public IntPtr pfnErrorFn; // WrenErrorFn
    [FieldOffset(56)] public ulong initalHeapSize;
    [FieldOffset(64)] public ulong minHeapSize;
    [FieldOffset(72)] public ulong heapGrowthPercent;
    [FieldOffset(80)] public IntPtr userData;

    public NativeWrenConfig SetReallocateFn(WrenDelegates.WrenReallocateFn fn)
    {
        pfnReallocateFn = Wren.DelegateToPtr(fn);
        return this;
    }

    public NativeWrenConfig SetResolveModuleFn(WrenDelegates.WrenResolveModuleFn fn)
    {
        pfnResolveModuleFn = Wren.DelegateToPtr(fn);
        return this;
    }

    public NativeWrenConfig SetLoadModuleFn(WrenDelegates.WrenLoadModuleFn fn)
    {
        pfnLoadModuleFn = Wren.DelegateToPtr(fn);
        return this;
    }

    public NativeWrenConfig SetBindForeignMethodFn(WrenDelegates.WrenBindForeignMethodFn fn)
    {
        pfnBindForeignMethodFn = Wren.DelegateToPtr(fn);
        return this;
    }

    public NativeWrenConfig SetBindForeignClassFn(WrenDelegates.WrenBindForeignClassFn fn)
    {
        pfnBindForeignClassFn = Wren.DelegateToPtr(fn);
        return this;
    }

    public NativeWrenConfig SetWriteFn(WrenDelegates.WrenWriteFn fn)
    {
        pfnWriteFn = Wren.DelegateToPtr(fn);
        return this;
    }

    public NativeWrenConfig SetErrorFn(WrenDelegates.WrenErrorFn fn)
    {
        pfnErrorFn = Wren.DelegateToPtr(fn);
        return this;
    }
}