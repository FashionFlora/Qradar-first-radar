using LogicLyric.Chests;

using LogicLyric.Interfaces;

using LogicLyrico;
using LogicLyrico.Mobs;
using System;
using System.Threading.Tasks;
using LogicLyric.Core;
using LogicLyric;
using LogicLyric.Dungeons;
using LogicLyric.Mists;
using System.Collections.Generic;
namespace LogicLyric
{
    public class LeaveEventHandler : EventPacketHandler<LeaveEvent>
    {

        PlayerHandler playerHandler;
        MobsHandler mobsHandler;
        ChestHandler ChestHandler;
        DungeonHandler dungeonHandler;
        MistHandler mistHandler;
    
        HarvestableHandler harvestableHandler;

        public LeaveEventHandler(PlayerHandler playerHandler, MobsHandler mobsHandler, ChestHandler chestHandler , DungeonHandler dungeonHandler , MistHandler mistHandler, HarvestableHandler harvestableHandler) : base(EventCodes.Leave) {

            this.playerHandler = playerHandler;
            this.mobsHandler = mobsHandler;
            this.ChestHandler = chestHandler;
            this.dungeonHandler = dungeonHandler;
            this.mistHandler = mistHandler;
    
            this.harvestableHandler = harvestableHandler;









        }
        protected override Task OnActionAsync(LeaveEvent value)
        {



            int id = int.Parse(value.Id);

         




           
  
           
            lock(StaticLocks.playersLock)
            {
                playerHandler.RemovePlayer(id);
            }
        
            lock(StaticLocks.mobsLock)
            {
                mobsHandler.RemoveMob(id);
            }
            lock (StaticLocks.mistsLock)
            {
                mistHandler.RemoveMob(id);
            }
            lock(StaticLocks.harvestLock)
            {
                harvestableHandler.RemoveHarvestable(id);
            }


    
           ChestHandler.RemoveChest(id);
            dungeonHandler.RemoveMob(id);









            return Task.CompletedTask;
        }
    }
}
