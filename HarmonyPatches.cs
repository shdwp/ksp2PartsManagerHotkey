using HarmonyLib;
using KSP.Game;
using KSP.OAB;

namespace PartsManagerHotkey;

[HarmonyPatch(typeof(UIManager))]
[HarmonyPatch("OnMouseSecondaryTapPerformed")]
static class Patch1
{
    static bool Prefix()
    {
        return PartsManagerHotkeyPlugin.Instance.IsMouseHotkeyDown();
    }
}
[HarmonyPatch(typeof(ObjectAssemblyPlacementTool))]
[HarmonyPatch("SelectPartInPartsManager")]
static class Patch2
{
    static bool Prefix()
    {
        return PartsManagerHotkeyPlugin.Instance.IsMouseHotkeyDown();
    }
}