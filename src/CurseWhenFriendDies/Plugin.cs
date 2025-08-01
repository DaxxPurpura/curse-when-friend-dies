using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace CurseWhenFriendDies;

[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;

    private void Awake()
    {
        Log = Logger;
        Log.LogInfo($"Plugin CurseWhenFriendDies is loaded!");
        new Harmony("com.github.DaxxPurpura.CurseWhenFriendDies").PatchAll();

    }
}
