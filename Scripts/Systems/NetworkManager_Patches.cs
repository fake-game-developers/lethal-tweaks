using HarmonyLib;
using LethalTweaks.Scripts.Networking;
using Unity.Netcode;

namespace LethalTweaks.Scripts.Systems;

[HarmonyPatch(typeof(NetworkManager))]
public static class NetworkManager_Patches
{
    [HarmonyPatch("StartHost")]
    [HarmonyPostfix]
    private static void StartHost_Post(GameNetworkManager __instance)
    {
        ConfigsSynchronizer.Instance.RegisterMessages();
    }

    [HarmonyPatch("StartClient")]
    [HarmonyPostfix]
    private static void StartClient_Post(GameNetworkManager __instance)
    {
        ConfigsSynchronizer.Instance.RegisterMessages();
    }
}