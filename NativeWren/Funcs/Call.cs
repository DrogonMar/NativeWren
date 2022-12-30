using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenMakeCallHandleDelegate _makeCallHandleFn;
    private static WrenCallDelegate _callFn;
    private static WrenReleaseHandleDelegate _releaseHandleFn;

    private static void InitCallFunctions()
    {
        _makeCallHandleFn = GetExport<WrenMakeCallHandleDelegate>("wrenMakeCallHandle");
        _callFn = GetExport<WrenCallDelegate>("wrenCall");
        _releaseHandleFn = GetExport<WrenReleaseHandleDelegate>("wrenReleaseHandle");
    }

    public static IntPtr MakeCallHandle(IntPtr vm, string signature)
    {
        return _makeCallHandleFn(vm, signature);
    }

    public static void Call(IntPtr vm, IntPtr callHandle)
    {
        _callFn(vm, callHandle);
    }

    public static void ReleaseHandle(IntPtr vm, IntPtr callHandle)
    {
        _releaseHandleFn(vm, callHandle);
    }
}