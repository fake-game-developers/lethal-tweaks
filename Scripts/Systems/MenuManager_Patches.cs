using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using LethalTweaks.Scripts.Networking;

namespace LethalTweaks.Scripts.Systems
{
    [HarmonyPatch(typeof(MenuManager))]
    public class MenuManager_Patches
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        private static void MenuManager_Start(MenuManager __instance)
        {
            LethalTweaks.Instance.LoadConfigs();
            CustomNetworking.Instance.UnregisterChannels();
        }
    }
}
