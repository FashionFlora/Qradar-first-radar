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
    public class MobChangeStateEventHandler : EventPacketHandler<MobChangeStateEvent>
    {
        MobsHandler mobsHandler;
        HarvestableHandler harvestableHandler;
        public MobChangeStateEventHandler() : base(EventCodes.MobChangeState) { }
        public MobChangeStateEventHandler(MobsHandler mobsHandler, HarvestableHandler harvestableHandler) : base(EventCodes.MobChangeState)
        {

            this.harvestableHandler = harvestableHandler;
            this.mobsHandler = mobsHandler;
        }
        protected override Task OnActionAsync(MobChangeStateEvent value)
        {



            lock (StaticLocks.mobsLock)
            {

                mobsHandler.UpdateMobEnchantmentLevel(value.mobId, value.enchantmentLevel);
            }
            


            return Task.CompletedTask;
        }
    }
}
