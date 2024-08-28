using LogicLyric.AAParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLyric.HarvestableCodes
{
    public class NewHarvestableObjectEvent : BaseEvent
    {

        public NewHarvestableObjectEvent(Dictionary<byte, object> parameters) : base(parameters)
        {





     



            object enchant = "";
            parameters.TryGetValue((byte)11, out enchant);
            enchantment  = enchant == null ? (byte)0 : (byte)enchant;


            

            id = int.Parse(parameters[0].ToString());
            type = byte.Parse(parameters[5].ToString()); 
            tier = byte.Parse(parameters[7].ToString()); 
            Single[] location = ObjectConverter.ConvertArray<Single>((object[])parameters[8]);
            posX = location[0];
            posY = location[1];
        

     

            

            byte charges = 0;
            byte size = 0;
            try
            {
                byte.TryParse(parameters[10].ToString(), out size) ;
            }
            catch
            {
                size = 0;
            }

            try {

                byte.TryParse(parameters[11].ToString(), out charges);
            }
            catch

            {
                charges = 0;
            }

            this.chargesEvent = enchantment;
            this.sizeEvent = size;




 

        }

        public int id { get; }

        public byte type { get; }
        public byte tier { get; }
        public Single posX { get; }
        public Single posY { get; }

        public byte enchantment {get;}

        public byte chargesEvent { get; }
        public byte sizeEvent { get; }

    }
}