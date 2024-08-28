
using LogicLyrico.Mobs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogicLyric.Core;
using LogicLyric.Mists;

namespace LogicLyric.HarvestableCodes
{
    public class NewMobEventHandler : EventPacketHandler<NewMobEvent>
    {
        MobsHandler mobsHandler;
        MistHandler mistHandler;
        public NewMobEventHandler() : base(EventCodes.NewMob) { }
        public NewMobEventHandler(MobsHandler mobsHandler, MistHandler mistHandler) : base(EventCodes.NewMob)
        {

            this.mistHandler = mistHandler;

            this.mobsHandler = mobsHandler;
        }
        protected override Task OnActionAsync(NewMobEvent value)
        {


      

            if(value.Name!=null)
            {
                lock (StaticLocks.mistsLock)
                {

                    Console.WriteLine(value.Name);


                      Console.WriteLine(value.Name + " " + value.posX + " " + value.posY + " " + int.Parse(value.Enchant)); ;
                    mistHandler.addMist(value.id, value.posX, value.posY, value.Name, int.Parse(value.Enchant));
                }
                return Task.CompletedTask;
            }

            
                lock (StaticLocks.mobsLock)
                {

                    mobsHandler.AddMob(value.id, value.typeId, value.posX, value.posY, value.health, 0, value.rarity, (int)value.Exp);

            
                }

                return Task.CompletedTask;
            
        }
    }
}
