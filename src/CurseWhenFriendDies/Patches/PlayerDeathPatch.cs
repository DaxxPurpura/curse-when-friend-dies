using HarmonyLib;
using Photon.Pun;

namespace CurseWhenFriendDies.Patches;

[HarmonyPatch(typeof(Character))]
[HarmonyPatch("RPCA_Die")]
public class PlayerDeathPatch
{
    static void Postfix(Character __instance)
    {
        var clientCharacter = Character.localCharacter;
        if (clientCharacter != __instance)
        {
            clientCharacter.refs.afflictions.AddStatus(CharacterAfflictions.STATUSTYPE.Curse, 0.05f);
            Plugin.Log.LogInfo("Applied 0.05 Curse to " + clientCharacter.characterName + " after death of " + __instance.characterName);
        }
        else
        {
            Plugin.Log.LogInfo("Applied 0.05 Curse to other players with CurseWhenFriendDies Mod");
        }

    }
}
