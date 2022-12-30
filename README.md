# NativeWren
Low level Wren bindings for C#.

This project aims to be pretty much the C equivalent of the C API for Wren, but in C#.


## Usage
```csharp
using NativeWren;

// Create a config
var config = new NativeWrenConfig();
Wren.InitConfig(ref config);
config.SetWriteFn((vmPtr, text) => Console.Write(text));

// Create a VM instance from the config
var vm = Wren.NewVM(ref config);
Wren.Interpret(vm, "main", "System.print(\"Hello, world!\")");
Wren.FreeVM(vm);
```

NativeWrenConfig.SetWriteFn internally uses Wren.DelegateToPtr to convert your function to a pointer,
just in case you want to use that for other things.