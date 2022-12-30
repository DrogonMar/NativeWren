using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenGetUserDataDelegate _getUserDataFn;
    private static WrenSetUserDataDelegate _setUserDataFn;

    private static void InitUserdataFunctions()
    {
        _getUserDataFn = GetExport<WrenGetUserDataDelegate>("wrenGetUserData");
        _setUserDataFn = GetExport<WrenSetUserDataDelegate>("wrenSetUserData");
    }

    public static IntPtr GetUserData(IntPtr vm)
    {
        return _getUserDataFn(vm);
    }

    public static void SetUserData(IntPtr vm, IntPtr userData)
    {
        _setUserDataFn(vm, userData);
    }
}