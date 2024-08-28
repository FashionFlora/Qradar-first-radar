using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
namespace LogicLyric
{


    public class PlayerRegenEvent : BaseEvent
    {
        public PlayerRegenEvent(Dictionary<byte, object> parameters) : base(parameters)
        {


          
              Id = parameters[0].ToString();
            
       
            try
            {

                HealthRegen = (float)parameters[4];
                CurrentHealth = (float)parameters[2];
                InitialHealth = (float)parameters[3];
            }
            catch
            {
                HealthRegen = -10;
            }
   
        }


        public String Id { get; }

        public Single HealthRegen { get; }
        public Single CurrentHealth { get; }
        public Single InitialHealth { get; }


    }
}
