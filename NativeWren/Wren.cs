using System.Reflection;
using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    public static IntPtr NativeHandle => _internalWrenLibPtr;

    private static IntPtr _internalWrenLibPtr = IntPtr.Zero;
    private static GetVersionNumberDelegate _getVersionNumberFn;
    private static WrenInterpretDelegate _interpretFn;
    private static WrenSetSlotNewForeignDelegate _setSlotNewForeign;
    private static WrenCollectGarbageDelegate _collectGarbage;
    private static WrenEnsureSlotsDelegate _ensureSlots;
    private static WrenGetVariableDelegate _getVariable;
    private static WrenAbortFiberDelegate _abortFiber;

    public static IntPtr DelegateToPtr<T>(T dele) where T : notnull
    {
        return Marshal.GetFunctionPointerForDelegate(dele);
    }

    public static T GetExport<T>(string name)
    {
        return Marshal.GetDelegateForFunctionPointer<T>
            (NativeLibrary.GetExport(_internalWrenLibPtr, name));
    }

    private static void CheckInit()
    {
        if (_internalWrenLibPtr != IntPtr.Zero)
            return;

        var nativeFolder = "";
        var libraryName = "";

        if (OperatingSystem.IsLinux())
        {
            nativeFolder = $"linux-" + RuntimeInformation.ProcessArchitecture.ToString().ToLower();
            libraryName = "libwren.so";
        }
        else
        {
            throw new Exception("Unknown operating system.");
        }

        var libPath = Path.Combine(
            Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location)!,
            "native",
            nativeFolder,
            libraryName);

        if (!NativeLibrary.TryLoad(libPath, out _internalWrenLibPtr))
            throw new Exception($"Failed to load wren library at path \"{libPath}\"");

        _getVersionNumberFn = GetExport<GetVersionNumberDelegate>("wrenGetVersionNumber");
        _interpretFn = GetExport<WrenInterpretDelegate>("wrenInterpret");
        _setSlotNewForeign = GetExport<WrenSetSlotNewForeignDelegate>("wrenSetSlotNewForeign");
        _collectGarbage = GetExport<WrenCollectGarbageDelegate>("wrenCollectGarbage");
        _getVariable = GetExport<WrenGetVariableDelegate>("wrenGetVariable");
        _ensureSlots = GetExport<WrenEnsureSlotsDelegate>("wrenEnsureSlots");
        _abortFiber = GetExport<WrenAbortFiberDelegate>("wrenAbortFiber");

        InitCallFunctions();
        InitConfigFunctions();
        InitGetSlotsFunctions();
        InitHasFunctions();
        InitListFunctions();
        InitMapFunctions();
        InitSetSlotsFunctions();
        InitUserdataFunctions();
        InitVmFunctions();
    }

    public static int ToVersionNumber(int major, int minor, int patch)
    {
        return major * 1000000 + minor * 1000 + patch;
    }

    /// <summary>
    /// Get the current wren version number.
    ///
    /// Can be used to range checks over versions.
    /// Major * 1000000 + Minor * 1000 + Patch
    /// </summary>
    /// <returns>Version</returns>
    public static int GetVersionNumber()
    {
        CheckInit();
        return _getVersionNumberFn.Invoke();
    }

    public static WrenInterpretResult Interpret(IntPtr vm, string module, string source)
    {
        return _interpretFn.Invoke(vm, module, source);
    }

    public static void CollectGarbage(IntPtr vm)
    {
        _collectGarbage.Invoke(vm);
    }

    public static void EnsureSlots(IntPtr vm, int numSlots)
    {
        _ensureSlots.Invoke(vm, numSlots);
    }

    public static void GetVariable(IntPtr vm, string module, string name, int slot)
    {
        _getVariable.Invoke(vm, module, name, slot);
    }

    public static void AbortFiber(IntPtr vm, int slot)
    {
        _abortFiber.Invoke(vm, slot);
    }
}