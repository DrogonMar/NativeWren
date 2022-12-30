using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenInitConfigurationDelegate _initConfigurationFn;

    private static void InitConfigFunctions()
    {
        _initConfigurationFn = GetExport<WrenInitConfigurationDelegate>("wrenInitConfiguration");
    }

    /// <summary>
    /// Get the initial config.
    /// </summary>
    /// <returns></returns>
    public static void InitConfig(ref NativeWrenConfig config)
    {
        CheckInit();
        var handle = GCHandle.Alloc(config, GCHandleType.Pinned);
        unsafe
        {
            fixed (NativeWrenConfig* pin = &config)
            {
                _initConfigurationFn.Invoke(pin);
            }

            handle.Free();
        }
    }
}