using LogicLyric.Chests;
using LogicLyrico;
using LogicLyrico.Mobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogicLyric;


namespace LogicLyric.HarvestableCodes
{
    public class AvalonEventHandler : EventPacketHandler<AvalonEvent>
    {
        ChestHandler chestHandler;
        public AvalonEventHandler() : base(EventCodes.ChestType) { }
        public AvalonEventHandler(ChestHandler chestHandler) : base(EventCodes.ChestType)
        {

            this.chestHandler = chestHandler;
        }
        protected override Task OnActionAsync(AvalonEvent value)
        {



            chestHandler.addChest(int.Parse(value.ChestId) ,value.ChestsPosition[0], value.ChestsPosition[1], value.ChestName);
            return Task.CompletedTask;
        }
    }
}
