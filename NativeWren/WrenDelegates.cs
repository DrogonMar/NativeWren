using System.Runtime.InteropServices;

namespace NativeWren;

public class WrenDelegates
{
    #region Callbacks

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenForeignMethodFn(IntPtr vm);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenFinalizerFn(IntPtr data);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr WrenReallocateFn(IntPtr memory, int newSize, IntPtr userData);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate string WrenResolveModuleFn(IntPtr vm, [MarshalAs(UnmanagedType.LPStr)] string importer,
        [MarshalAs(UnmanagedType.LPStr)] string name);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate NativeWrenLoadModuleResult WrenLoadModuleFn(IntPtr vm, string name);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate WrenForeignMethodFn WrenBindForeignMethodFn(IntPtr vm, string module, string className,
        bool isStatic,
        string signature);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate NativeWrenForeignClassMethods WrenBindForeignClassFn(IntPtr vm, string module, string className);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenWriteFn(IntPtr vm, string text);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenErrorFn(IntPtr vm, WrenErrorType type, string module, int line, string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenLoadModuleCompleteFn(IntPtr vm, string name, NativeWrenLoadModuleResult result);

    #endregion

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int GetVersionNumberDelegate();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void WrenInitConfigurationDelegate(NativeWrenConfig* config);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate IntPtr WrenNewVmDelegate(NativeWrenConfig* config);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenFreeVmDelegate(IntPtr vm);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenCollectGarbageDelegate(IntPtr vm);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate WrenInterpretResult WrenInterpretDelegate(IntPtr vm, string module, string source);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr WrenMakeCallHandleDelegate(IntPtr vm, string signature);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate WrenInterpretResult WrenCallDelegate(IntPtr vm, IntPtr method);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenReleaseHandleDelegate(IntPtr vm, IntPtr handle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int WrenGetSlotCountDelegate(IntPtr vm);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenEnsureSlotsDelegate(IntPtr vm, int numSlots);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate WrenType WrenGetSlotTypeDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool WrenGetSlotBoolDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate string WrenGetSlotBytesDelegate(IntPtr vm, int slot, int* length);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double WrenGetSlotDoubleDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr WrenGetSlotForeignDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //The return value is a pointer to a null-terminated string.
    //Use Marshal.PtrToStringAnsi to convert it to a C# string.
    public delegate IntPtr WrenGetSlotStringDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr WrenGetSlotHandleDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetSlotBoolDelegate(IntPtr vm, int slot, bool value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void WrenSetSlotBytesDelegate(IntPtr vm, int slot, byte* bytes, nuint length);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetSlotDoubleDelegate(IntPtr vm, int slot, double value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr WrenSetSlotNewForeignDelegate(IntPtr vm, int slot, int classSlot, nuint size);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetSlotNewListDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetSlotNewMapDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetSlotNullDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetSlotStringDelegate(IntPtr vm, int slot, string text);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetSlotHandleDelegate(IntPtr vm, int slot, IntPtr handle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int WrenGetListCountDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenGetListElementDelegate(IntPtr vm, int listSlot, int index, int elementSlot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetListElementDelegate(IntPtr vm, int listSlot, int index, int elementSlot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenInsertInListDelegate(IntPtr vm, int listSlot, int index, int elementSlot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int WrenGetMapCountDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool WrenGetMapContainsKeyDelegate(IntPtr vm, int mapSlot, int keySlot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenGetMapValueDelegate(IntPtr vm, int mapSlot, int keySlot, int valueSlot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetMapValueDelegate(IntPtr vm, int mapSlot, int keySlot, int valueSlot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenRemoveMapValueDelegate(IntPtr vm, int mapSlot, int keySlot, int removedValueSlot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenGetVariableDelegate(IntPtr vm, string module, string name, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool WrenHasVariableDelegate(IntPtr vm, string module, string name);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool WrenHasModuleDelegate(IntPtr vm, string module);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenAbortFiberDelegate(IntPtr vm, int slot);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr WrenGetUserDataDelegate(IntPtr vm);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WrenSetUserDataDelegate(IntPtr vm, IntPtr userData);
}