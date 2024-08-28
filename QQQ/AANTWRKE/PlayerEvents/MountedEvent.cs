using System;
using System.Collections.Generic;
using System.Linq;

namespace LogicLyric.PlayerEvents
{


    public class MountedEvent : BaseEvent
    {
        public MountedEvent(Dictionary<byte, object> parameters) : base(parameters)
        {



            Id = parameters[0].ToString();

  
     
            try
            {

                Mounted = (bool)parameters[3];



            }
            catch
            {
                Mounted = false;

            }

 



        }


        public String Id { get; }
        public bool Mounted { get; }



    }
}
