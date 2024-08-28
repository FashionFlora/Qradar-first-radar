using LogicLyrico;
using LogicLyrico.Mobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLyric.Core;

namespace LogicLyric.HarvestableCodes
{
    public class NewSimpleHarvestableObjectListEventHandler : EventPacketHandler<NewSimpleHaverstableObjectListEvent>
    {
        HarvestableHandler harvestableHandler;
        public NewSimpleHarvestableObjectListEventHandler() : base(EventCodes.NewSimpleHarvestableObjectList) { }
        public NewSimpleHarvestableObjectListEventHandler(HarvestableHandler harvestableHandler) : base(EventCodes.NewSimpleHarvestableObjectList)
        {

            this.harvestableHandler = harvestableHandler;
        }
        protected override Task OnActionAsync(NewSimpleHaverstableObjectListEvent value)
        {

            
         
            

                    for (int i = 0; i < value.a0.Count; i++)
                    {
                       Single posX = (Single)value.a3[i * 2];
                        int id = (int)value.a0.ElementAt(i);
                        byte type = (byte)value.a1[i];
                          Byte count = (byte)value.a4[i];
                        byte tier = (byte)value.a2[i];
                
                        Single posY = (Single)value.a3[i * 2 + 1];
                     

           

                    lock (StaticLocks.harvestLock)
                    {


              
                        harvestableHandler.AddHarvestable(id, type, tier, posX, posY, 0, count);

                    }

                    }
                
                

            
        
            return Task.CompletedTask;
            
        }
    }
}
