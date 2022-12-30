using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenGetMapCountDelegate _getMapCount;
    private static WrenGetMapContainsKeyDelegate _getMapContainsKey;
    private static WrenGetMapValueDelegate _getMapValue;
    private static WrenSetMapValueDelegate _setMapValue;
    private static WrenRemoveMapValueDelegate _removeMapValue;


    private static void InitMapFunctions()
    {
        _getMapCount = GetExport<WrenGetMapCountDelegate>("wrenGetMapCount");
        _getMapContainsKey = GetExport<WrenGetMapContainsKeyDelegate>("wrenGetMapContainsKey");
        _getMapValue = GetExport<WrenGetMapValueDelegate>("wrenGetMapValue");
        _setMapValue = GetExport<WrenSetMapValueDelegate>("wrenSetMapValue");
        _removeMapValue = GetExport<WrenRemoveMapValueDelegate>("wrenRemoveMapValue");
    }

    public static int GetMapCount(IntPtr vm, int slot)
    {
        return _getMapCount(vm, slot);
    }

    public static bool GetMapContainsKey(IntPtr vm, int mapSlot, int keySlot)
    {
        return _getMapContainsKey(vm, mapSlot, keySlot);
    }

    public static void GetMapValue(IntPtr vm, int mapSlot, int keySlot, int valueSlot)
    {
        _getMapValue(vm, mapSlot, keySlot, valueSlot);
    }

    public static void SetMapValue(IntPtr vm, int mapSlot, int keySlot, int valueSlot)
    {
        _setMapValue(vm, mapSlot, keySlot, valueSlot);
    }

    public static void RemoveMapValue(IntPtr vm, int mapSlot, int keySlot, int removedValueSlot)
    {
        _removeMapValue(vm, mapSlot, keySlot, removedValueSlot);
    }
}