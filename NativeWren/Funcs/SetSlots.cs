using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenSetSlotBoolDelegate _setSlotBoolFn;
    private static WrenSetSlotBytesDelegate _setSlotBytesFn;
    private static WrenSetSlotDoubleDelegate _setSlotDoubleFn;
    private static WrenSetSlotNewForeignDelegate _setSlotNewForeignFn;
    private static WrenSetSlotNewListDelegate _setSlotNewListFn;
    private static WrenSetSlotNewMapDelegate _setSlotNewMapFn;
    private static WrenSetSlotNullDelegate _setSlotNullFn;
    private static WrenSetSlotStringDelegate _setSlotStringFn;
    private static WrenSetSlotHandleDelegate _setSlotHandleFn;

    private static void InitSetSlotsFunctions()
    {
        _setSlotBoolFn = GetExport<WrenSetSlotBoolDelegate>("wrenSetSlotBool");
        _setSlotBytesFn = GetExport<WrenSetSlotBytesDelegate>("wrenSetSlotBytes");
        _setSlotDoubleFn = GetExport<WrenSetSlotDoubleDelegate>("wrenSetSlotDouble");
        _setSlotNewForeignFn = GetExport<WrenSetSlotNewForeignDelegate>("wrenSetSlotNewForeign");
        _setSlotNewListFn = GetExport<WrenSetSlotNewListDelegate>("wrenSetSlotNewList");
        _setSlotNewMapFn = GetExport<WrenSetSlotNewMapDelegate>("wrenSetSlotNewMap");
        _setSlotNullFn = GetExport<WrenSetSlotNullDelegate>("wrenSetSlotNull");
        _setSlotStringFn = GetExport<WrenSetSlotStringDelegate>("wrenSetSlotString");
        _setSlotHandleFn = GetExport<WrenSetSlotHandleDelegate>("wrenSetSlotHandle");
    }

    public static void SetSlotBool(IntPtr vm, int slot, bool value)
    {
        _setSlotBoolFn(vm, slot, value);
    }

    public static void SetSlotBytes(IntPtr vm, int slot, byte[] bytes)
    {
        unsafe
        {
            //Convert bytes array to a pointer
            var ptr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, ptr, bytes.Length);
            _setSlotBytesFn(vm, slot, (byte*)ptr, (nuint)bytes.Length);
            //In the wren header file it says that the bytes are copied, so we can free the pointer.
            Marshal.FreeHGlobal(ptr);
        }
    }

    public static void SetSlotDouble(IntPtr vm, int slot, double value)
    {
        _setSlotDoubleFn(vm, slot, value);
    }

    public static IntPtr SetSlotNewForeign(IntPtr vm, int slot, int classSlot, nuint size)
    {
        return _setSlotNewForeign.Invoke(vm, slot, classSlot, size);
    }

    public static void SetSlotNewList(IntPtr vm, int slot)
    {
        _setSlotNewListFn(vm, slot);
    }

    public static void SetSlotNewMap(IntPtr vm, int slot)
    {
        _setSlotNewMapFn(vm, slot);
    }

    public static void SetSlotNull(IntPtr vm, int slot)
    {
        _setSlotNullFn(vm, slot);
    }

    public static void SetSlotString(IntPtr vm, int slot, string value)
    {
        _setSlotStringFn(vm, slot, value);
    }

    public static void SetSlotHandle(IntPtr vm, int slot, IntPtr value)
    {
        _setSlotHandleFn(vm, slot, value);
    }
}