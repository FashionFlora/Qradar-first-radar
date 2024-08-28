using LogicLyrico;
using LogicLyrico.Mobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogicLyric.Core;

namespace LogicLyric.HarvestableCodes
{
    public class JoinFinishedEventHandler : EventPacketHandler<JoinFinishedEvent>
    {
        MobsHandler mobsHandler;
        HarvestableHandler harvestableHandler;
        public JoinFinishedEventHandler() : base(EventCodes.JoinFinished) { }
        public JoinFinishedEventHandler(HarvestableHandler  harvestableHandler, MobsHandler mobsHandler) : base(EventCodes.JoinFinished)
        {

            this.mobsHandler = mobsHandler;
            this.harvestableHandler = harvestableHandler;
        }
        protected override Task OnActionAsync(JoinFinishedEvent value)
        {

            lock(StaticLocks.mobsLock)
            {
                mobsHandler.MobList.Clear();
            }
            lock (StaticLocks.harvestLock)
            {
                harvestableHandler.HarvestableList.Clear();
            }

            return Task.CompletedTask;
        }
    }
}
