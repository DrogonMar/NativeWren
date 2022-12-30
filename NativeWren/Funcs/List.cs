using System.Runtime.InteropServices;
using static NativeWren.WrenDelegates;

namespace NativeWren;

public partial class Wren
{
    private static WrenGetListCountDelegate _getListCount;
    private static WrenGetListElementDelegate _getListElement;
    private static WrenSetListElementDelegate _setListElement;
    private static WrenInsertInListDelegate _insertInList;

    private static void InitListFunctions()
    {
        _getListCount = GetExport<WrenGetListCountDelegate>("wrenGetListCount");
        _getListElement = GetExport<WrenGetListElementDelegate>("wrenGetListElement");
        _setListElement = GetExport<WrenSetListElementDelegate>("wrenSetListElement");
        _insertInList = GetExport<WrenInsertInListDelegate>("wrenInsertInList");
    }


    public static int GetListCount(IntPtr vm, int slot)
    {
        return _getListCount(vm, slot);
    }

    public static void GetListElement(IntPtr vm, int listSlot, int index, int elementSlot)
    {
        _getListElement(vm, listSlot, index, elementSlot);
    }

    public static void SetListElement(IntPtr vm, int listSlot, int index, int elementSlot)
    {
        _setListElement(vm, listSlot, index, elementSlot);
    }

    public static void InsertInList(IntPtr vm, int listSlot, int index, int elementSlot)
    {
        _insertInList(vm, listSlot, index, elementSlot);
    }
}