using DubsBadHygiene;
using RimWorld;
using Verse;

namespace Rimputers
{
    public class CompWaterPowerTrader : CompPowerTrader
    {
        private CompWaterConsumer _waterConsumer;

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            this._waterConsumer = this.parent.TryGetComp<CompWaterConsumer>();
        }

        public bool HasEnoughWater() => _waterConsumer is null || _waterConsumer.HasEnoughWater();
    }
}