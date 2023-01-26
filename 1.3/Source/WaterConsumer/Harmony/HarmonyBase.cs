namespace Rimputers.Harmony
{
    public class HarmonyBase
    {
        private static HarmonyLib.Harmony harmonyInstance = new HarmonyLib.Harmony("com.rimputers.patch");
        public static void ApplyPatches()
        {
            harmonyInstance.PatchAll();
        }
    }
}