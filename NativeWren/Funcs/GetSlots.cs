using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenGetSlotCountDelegate _getSlotCount;
    private static WrenGetSlotTypeDelegate _getSlotType;
    private static WrenGetSlotBoolDelegate _getSlotBool;
    private static WrenGetSlotBytesDelegate _getSlotBytes;
    private static WrenGetSlotDoubleDelegate _getSlotDouble;
    private static WrenGetSlotForeignDelegate _getSlotForeign;
    private static WrenGetSlotStringDelegate _getSlotString;
    private static WrenGetSlotHandleDelegate _getSlotHandle;

    private static void InitGetSlotsFunctions()
    {
        _getSlotCount = GetExport<WrenGetSlotCountDelegate>("wrenGetSlotCount");
        _getSlotType = GetExport<WrenGetSlotTypeDelegate>("wrenGetSlotType");
        _getSlotBool = GetExport<WrenGetSlotBoolDelegate>("wrenGetSlotBool");
        _getSlotBytes = GetExport<WrenGetSlotBytesDelegate>("wrenGetSlotBytes");
        _getSlotDouble = GetExport<WrenGetSlotDoubleDelegate>("wrenGetSlotDouble");
        _getSlotForeign = GetExport<WrenGetSlotForeignDelegate>("wrenGetSlotForeign");
        _getSlotString = GetExport<WrenGetSlotStringDelegate>("wrenGetSlotString");
        _getSlotHandle = GetExport<WrenGetSlotHandleDelegate>("wrenGetSlotHandle");
    }

    public static int GetSlotCount(IntPtr vm)
    {
        return _getSlotCount.Invoke(vm);
    }

    public static WrenType GetSlotType(IntPtr vm, int slot)
    {
        return _getSlotType.Invoke(vm, slot);
    }

    public static bool GetSlotBool(IntPtr vm, int slot)
    {
        return _getSlotBool.Invoke(vm, slot);
    }

    public static unsafe string GetSlotBytes(IntPtr vm, int slot, out int length)
    {
        var result = "";
        fixed (int* ptr = &length)
        {
            result = _getSlotBytes.Invoke(vm, slot, ptr);
        }

        return result;
    }

    public static double GetSlotDouble(IntPtr vm, int slot)
    {
        return _getSlotDouble.Invoke(vm, slot);
    }

    public static IntPtr GetSlotForeign(IntPtr vm, int slot)
    {
        return _getSlotForeign.Invoke(vm, slot);
    }

    public static string GetSlotString(IntPtr vm, int slot)
    {
        var strPtr = _getSlotString.Invoke(vm, slot);
        return Marshal.PtrToStringAnsi(strPtr);
    }

    public static IntPtr GetSlotHandle(IntPtr vm, int slot)
    {
        return _getSlotHandle.Invoke(vm, slot);
    }
}