using System;
using System.Collections.Generic;
using System.Collections.Generic;
namespace LogicLyric
{
    public class PlayerAttackEvent : BaseEvent
    {
        public PlayerAttackEvent(Dictionary<byte, object> parameters) : base(parameters)
        {


        
            Id = parameters[0].ToString();
    
            try
            {
                CurrentHealth = (Single)parameters[3];
            }

            catch
            {

                CurrentHealth = -1000000000;
            }
           

   

        }

        public String Id { get; }

        public Single CurrentHealth { get; }

    }
}
