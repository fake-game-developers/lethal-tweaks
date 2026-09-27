using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using LethalTweaks.Scripts.Inventory;
using LethalTweaks.Scripts.Moons;
using LethalTweaks.Scripts.World;
using Unity.Netcode;

namespace LethalTweaks.Scripts.Items
{
    [HarmonyPatch(typeof(Terminal))]
    public class Terminal_Patches
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void Start(Terminal __instance)
        {
            if (!NetworkManager.Singleton.IsServer)
                return;

            MoonTweaks.ReapplyConfigs(__instance);
            InventoryTweaks.ApplyItemPrices(__instance);
        }
    }
}
