
using LogicLyrico.Mobs;
using System;
using System.Threading.Tasks;
using LogicLyric.Core;
using LogicLyric.Mists;
using System.Collections.Generic;
namespace LogicLyric
{
    public class MoveEventHandler : EventPacketHandler<MoveEvent>
    {

        PlayerHandler playerHandler;
        MobsHandler mobsHandler;
        MistHandler mistEvent;
        public MoveEventHandler(PlayerHandler playerHandler , MobsHandler mobsHandler , MistHandler mistEvent) : base(EventCodes.Move) {

            this.playerHandler = playerHandler;
            this.mobsHandler = mobsHandler;
            this.mistEvent = mistEvent;


        
        }
        protected override Task OnActionAsync(MoveEvent value)
        {



            int id = int.Parse(value.Id);




            lock (StaticLocks.playersLock)
            {
                playerHandler.UpdatePlayerPosition(id, value.Position[0], value.Position[1]);
            }

            lock(StaticLocks.mobsLock)
            {
                mobsHandler.UpdateMobPosition(id, value.Position[0], value.Position[1]);
            }


            lock (StaticLocks.mistsLock)
            {
                mistEvent.UpdateMobPosition(int.Parse(value.Id), value.Position[0], value.Position[1]);
            }





            return Task.CompletedTask;
        }
    }
}
