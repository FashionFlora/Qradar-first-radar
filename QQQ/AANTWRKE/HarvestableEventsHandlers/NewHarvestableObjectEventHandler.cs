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
    public class NewHarvestableObjectEventHandler : EventPacketHandler<NewHarvestableObjectEvent>
    {
        HarvestableHandler harvestableHandler;
        public NewHarvestableObjectEventHandler() : base(EventCodes.NewHarvestableObject) { }
        public NewHarvestableObjectEventHandler(HarvestableHandler harvestableHandler) : base(EventCodes.NewHarvestableObject)
        {

            this.harvestableHandler = harvestableHandler;
        }
        protected override Task OnActionAsync(NewHarvestableObjectEvent value)
        {

            lock (StaticLocks.harvestLock)
            {
          
                harvestableHandler.AddHarvestable(value.id, value.type, value.tier, value.posX, value.posY, value.chargesEvent, value.sizeEvent);
            }

    

            return Task.CompletedTask;
        }
    }
}
