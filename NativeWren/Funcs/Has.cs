using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenHasVariableDelegate _hasVariable;
    private static WrenHasModuleDelegate _hasModule;

    private static void InitHasFunctions()
    {
        _hasVariable = GetExport<WrenHasVariableDelegate>("wrenHasVariable");
        _hasModule = GetExport<WrenHasModuleDelegate>("wrenHasModule");
    }

    public static bool HasVariable(IntPtr vm, string module, string name)
    {
        return _hasVariable.Invoke(vm, module, name);
    }

    public static bool HasModule(IntPtr vm, string module)
    {
        return _hasModule.Invoke(vm, module);
    }
}