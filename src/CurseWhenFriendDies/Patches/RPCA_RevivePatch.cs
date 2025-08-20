using HarmonyLib;
using Photon.Pun;

namespace CurseWhenFriendDies.Patches;

[HarmonyPatch(typeof(Character), "RPCA_Revive")]
public class RPCA_RevivePatch
{
    static void Postfix(Character __instance)
    {
        var clientCharacter = Character.localCharacter;
        if (clientCharacter != __instance)
        {
            clientCharacter.refs.afflictions.SubtractStatus(CharacterAfflictions.STATUSTYPE.Curse, Plugin.reviveRewardAmount.Value / 100f);
            Plugin.Log.LogInfo("Removed " + Plugin.reviveRewardAmount.Value / 100f + " curse to " + clientCharacter.characterName + " after revival of " + __instance.characterName);
        }
        else
        {
            Plugin.Log.LogInfo("Removed curse to other players with CurseWhenFriendDies Mod");
        }
    }
}
