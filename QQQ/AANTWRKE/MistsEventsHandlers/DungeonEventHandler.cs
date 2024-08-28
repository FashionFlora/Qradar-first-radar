

using LogicLyric.Dungeons;
using LogicLyrico;
using LogicLyrico.Mobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.HarvestableCodes
{
    public class DungeonEventHandler : EventPacketHandler<DungeonEvent>
    {




        DungeonHandler dungeonHandler;
        public DungeonEventHandler(DungeonHandler dungeonHandler) : base(EventCodes.DungeonEvent) {

            this.dungeonHandler = dungeonHandler;

        
        
        
        }

        protected override Task OnActionAsync(DungeonEvent value)
        {



           
            dungeonHandler.addDungeon(int.Parse(value.Id),value.Position[0],value.Position[1], value.Name,int.Parse(value.Enchant));

            return Task.CompletedTask;
        }
    }
}
