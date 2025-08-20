using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace CurseWhenFriendDies;

[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;

    internal static ConfigEntry<int> curseAmount;
    internal static ConfigEntry<int> reviveRewardAmount;

    private void Awake()
    {
        Log = Logger;
        Log.LogInfo($"Plugin CurseWhenFriendDies is loaded!");
        new Harmony("com.github.DaxxPurpura.CurseWhenFriendDies").PatchAll();

        curseAmount = Config.Bind("General", "Curse Amount", 5, "Amount of curse applied per death (1 unit = 2.5).");
        reviveRewardAmount = Config.Bind("General", "Revive Reward Amount", 5, "Amount of curse removed per revive (1 unit = 2.5).");
    }
}
