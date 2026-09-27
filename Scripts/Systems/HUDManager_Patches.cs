using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using LethalTweaks.Scripts.Inventory;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace LethalTweaks.Scripts.Systems
{
    [HarmonyPatch(typeof(HUDManager))]
    public class HUDManager_Patches
    {
        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        public static void Awake(HUDManager __instance)
        {
            if (!NetworkManager.Singleton.IsServer)
                return;
            if (LethalTweaks.Compatibility.ReservedSlotCoreCompat || LethalTweaks.Compatibility.LethalThingsCompat)
                return;

            InventoryTweaks.ChangeItemSlotsAmountUI();
        }
    }
}
