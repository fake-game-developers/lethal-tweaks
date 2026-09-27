using System;
using System.Collections.Generic;
using System.Text;
using GameNetcodeStuff;
using HarmonyLib;
using LethalTweaks.Scripts.World;

namespace LethalTweaks.Scripts.Environment
{
    [HarmonyPatch(typeof(EntranceTeleport))]
    public class EntranceTeleport_Patches
    {
        [HarmonyPatch("TeleportPlayerClientRpc")]
        [HarmonyPostfix]
        private static void TeleportPlayerClientRpc(int playerObj)
        {
            if (!WorldTweaks.CanInteractWithTerminal(WorldTweaks.TerminalInteractTriggerInstance) && playerObj != 0)
                return;

            WorldTweaks.MakeTerminalUnusableForAnyoneButHost();
            WorldTweaks.ResetValues(WorldTweaks.TerminalInteractTriggerInstance);
        }
    }
}
