using HarmonyLib;
using Photon.Pun;

namespace CurseWhenFriendDies.Patches;

[HarmonyPatch(typeof(Character), "RPCA_Die")]
public class RPCA_DiePatch
{
    static void Postfix(Character __instance)
    {
        var clientCharacter = Character.localCharacter;
        if (clientCharacter != __instance)
        {
            clientCharacter.refs.afflictions.AddStatus(CharacterAfflictions.STATUSTYPE.Curse, Plugin.curseAmount.Value / 100f);
            Plugin.Log.LogInfo("Applied " + Plugin.curseAmount.Value / 100f + " curse to " + clientCharacter.characterName + " after death of " + __instance.characterName);
        }
        else
        {
            Plugin.Log.LogInfo("Applied curse to other players with CurseWhenFriendDies Mod");
        }
    }
}
