using System.Runtime.InteropServices;

namespace NativeWren;

[StructLayout(LayoutKind.Sequential)]
public struct NativeWrenLoadModuleResult
{
    [MarshalAs(UnmanagedType.LPStr)] public string source;
    public IntPtr pfnOnComplete; // WrenLoadModuleCompleteFn
    public IntPtr userData;
}