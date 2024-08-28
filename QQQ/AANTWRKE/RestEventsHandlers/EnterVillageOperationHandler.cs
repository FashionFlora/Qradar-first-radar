using LogicLyric;
using LogicLyric;
using LogicLyric.Chests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLyric.RestEvents;
using LogicLyrico;
using LogicLyrico.Mobs;
using LogicLyric.Mists;
using LogicLyric.Dungeons;

namespace LogicLyric.RestEventsHandlers
{
    public class EnterVillageOperationHandler : RequestPacketHandler<EnterVillageOperation>
    {
        private PlayerHandler playerHandler;
        private MobsHandler mobsHandler;
        private ChestHandler chestHandler;
        private DungeonHandler dungeonHandler;
        private MistHandler mistHandler;
        private HarvestableHandler harvestableHandler;

        public EnterVillageOperationHandler() : base(OperationCodes.EnterVillage) { }
 

        public EnterVillageOperationHandler(PlayerHandler playerHandler, MobsHandler mobsHandler, ChestHandler chestHandler, DungeonHandler dungeonHandler, MistHandler mistHandler, HarvestableHandler harvestableHandler) : base(OperationCodes.EnterVillage)
        {
            this.playerHandler = playerHandler;
            this.mobsHandler = mobsHandler;
            this.chestHandler = chestHandler;
            this.dungeonHandler = dungeonHandler;
            this.mistHandler = mistHandler;
            this.harvestableHandler = harvestableHandler;
        }

        protected override Task OnActionAsync(EnterVillageOperation value)
        {

            playerHandler.playersInRange.Clear();
            mobsHandler.mobsList.Clear();
            chestHandler.chestsList.Clear();
            dungeonHandler.dungeonList.Clear();
            mistHandler.mistList.Clear();
            harvestableHandler.harvestableList.Clear();





            return Task.CompletedTask;
        }


    }
}
