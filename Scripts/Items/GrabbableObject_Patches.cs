using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using LethalTweaks.Scripts.Configs;
using LethalTweaks.Scripts.Inventory;
using LethalTweaks.Scripts.Networking;
using LethalTweaks.Scripts.World;
using Unity.Netcode;

namespace LethalTweaks.Scripts.Items
{
    [HarmonyPatch(typeof(GrabbableObject))]
    public class GrabbableObject_Patches
    {
        [HarmonyPatch(nameof(GrabbableObject.Start))]
        [HarmonyPostfix]
        public static void ChangeTerminalItemWeights(GrabbableObject __instance)
        {
            if (LethalTweaks.DebugMode)
                LethalTweaks.Log.LogInfo($"{__instance.itemProperties.name}: {__instance.itemProperties.weight}");

            if (!NetworkManager.Singleton.IsServer && !ConfigsSynchronizer.ConfigsReceived)
                return;

            InventoryTweaks.ModifyItemWeight(__instance);
        }
    }
}
