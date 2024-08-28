using LogicLyrico;
using LogicLyrico.Mobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogicLyric.Core;
using LogicLyric;

namespace LogicLyric.HarvestableCodes
{
    public class HarvestFinishedEventHandler : EventPacketHandler<HarvestFinishedEvent>
    {
        HarvestableHandler harvestableHandler;
        public HarvestFinishedEventHandler() : base(EventCodes.HarvestFinished) { }
        public HarvestFinishedEventHandler(HarvestableHandler harvestableHandler) : base(EventCodes.HarvestFinished)
        {

            this.harvestableHandler = harvestableHandler;
        }
        protected override Task OnActionAsync(HarvestFinishedEvent value)
        {


            lock (StaticLocks.harvestLock)
            {


                harvestableHandler.UpdateHarvestable(value.harvestableId, value.count);
            }
            


            return Task.CompletedTask;
        }
    }
}
