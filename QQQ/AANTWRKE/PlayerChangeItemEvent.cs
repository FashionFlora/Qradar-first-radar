using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLyric
{

   
    public class PlayerChangeItemEvent : BaseEvent
    {
        public PlayerChangeItemEvent(Dictionary<byte, object> parameters) : base(parameters)
        {



            Id = parameters[0].ToString();

            InitialHealth = (float)parameters[3];
            try
            {

                InitialHealth = (float)parameters[3];
                CurrentHealth = (float)parameters[2];
      
            }
            catch
            {

                CurrentHealth = InitialHealth;

            }

        }


        public String Id { get; }

        public Single CurrentHealth { get; }

        public Single InitialHealth { get; }


    }
}
