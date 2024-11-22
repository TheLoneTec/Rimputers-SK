using DubsBadHygiene;
using RimWorld;
using System;
using System.Text;
using UnityEngine;
using Verse;

namespace Rimputers
{
     //Adapted from https://github.com/joeyjoejoeshabidoo/Alternative-Power-Solutions-for-RW/blob/main/1.3/Source/AlternativePowerSolutions/CompWaterConsumer.cs
    public class CompProperties_WaterConsumer : CompProperties
    {
        public CompProperties_WaterConsumer()
        {
            base.compClass = typeof(CompWaterConsumer);
        }

        public float waterPerTick;
    }
    public class CompWaterConsumer : ThingComp
    {
        private CompPipe compPipe;

        private CompPowerTrader compPower;
        public CompProperties_WaterConsumer Props => base.props as CompProperties_WaterConsumer;
        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            compPipe = this.parent.GetComp<CompPipe>();
            compPower = this.parent.GetComp<CompPowerTrader>();
        }
        public override void CompTick()
        {
            base.CompTick();
            if (compPower.PowerOn && HasEnoughWater())
            {
                compPipe.pipeNet.PullWater(Props.waterPerTick, out _);
            }
        }

        public override string CompInspectStringExtra()
        {
            StringBuilder sb = new StringBuilder(base.CompInspectStringExtra());
            sb.AppendLine("APSW.WaterConsumptionPerSecond".Translate(Props.waterPerTick * 60));
            return sb.ToString().TrimEndNewlines();
        }

        public bool HasEnoughWater()
        {
            return compPipe.pipeNet.WaterStorage >= Props.waterPerTick;
        }
    }
}
