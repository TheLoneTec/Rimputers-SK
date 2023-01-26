using Rimputers.Harmony;
using Verse;

namespace Rimputers
{
    [StaticConstructorOnStartup]
    public class Bootstrap
    {
        static Bootstrap()
        {
            HarmonyBase.ApplyPatches();
            Log.Message("[Rimputers] Initalization done !");
        }
    }
}