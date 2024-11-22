using HarmonyLib;
using RimWorld;
using Verse;

namespace Rimputers.Harmony.Patches
{
    [HarmonyPatch(typeof(CompFacility))]
    [HarmonyPatch("CanBeActive", MethodType.Getter)]
    public class PatchFacilityCanBeOn
    {
        [HarmonyPostfix]
        public static void Postfix(ref bool __result, CompFacility __instance)
        {
            if (__result)
            {
                CompWaterConsumer compWater = __instance.parent.TryGetComp<CompWaterConsumer>();
                __result = compWater == null || compWater.HasEnoughWater();
            }
        }
    }
}