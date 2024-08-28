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
using System.Collections.Generic;
namespace LogicLyric.RestEventsHandlers
{
    public class EnterMistOperationHandler : RequestPacketHandler<EnterMistOperation>
    {
        private PlayerHandler playerHandler;
        private MobsHandler mobsHandler;
        private ChestHandler chestHandler;
        private DungeonHandler dungeonHandler;
        private MistHandler mistHandler;
        private HarvestableHandler harvestableHandler;

        public EnterMistOperationHandler() : base(OperationCodes.EnterMist) { }
 

        public EnterMistOperationHandler(PlayerHandler playerHandler, MobsHandler mobsHandler, ChestHandler chestHandler, DungeonHandler dungeonHandler, MistHandler mistHandler, HarvestableHandler harvestableHandler) : base(OperationCodes.EnterVillage)
        {
            this.playerHandler = playerHandler;
            this.mobsHandler = mobsHandler;
            this.chestHandler = chestHandler;
            this.dungeonHandler = dungeonHandler;
            this.mistHandler = mistHandler;
            this.harvestableHandler = harvestableHandler;
        }

        protected override Task OnActionAsync(EnterMistOperation value)
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
