using HarmonyLib;

namespace CurseWhenFriendDies.Patches;

[HarmonyPatch(typeof(Character))]
[HarmonyPatch("RPCA_Die")]
public class PlayerDeathPatch
{
    static void Postfix(Character __instance)
    {
        foreach (Character character in Character.AllCharacters)
        {
            if (character != __instance)
            {
                character.refs.afflictions.AddStatus(CharacterAfflictions.STATUSTYPE.Curse, 0.05f);
            }
        }

        Plugin.Log.LogInfo("Applied 0.05 Curse to all players after death of: " + __instance.characterName);

    }
}
