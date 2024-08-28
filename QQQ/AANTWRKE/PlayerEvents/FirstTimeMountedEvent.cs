using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
namespace LogicLyric.PlayerEvents
{


    public class FirstTimeMountedEvent : BaseEvent
    {
        public FirstTimeMountedEvent(Dictionary<byte, object> parameters) : base(parameters)
        {



            Id = parameters[0].ToString();



            try
            {
                Ten = parameters[10].ToString();
            }
            catch
            {
                Ten = "2";
            }
            try
            {

                Mounted11 = (bool)parameters[11];
            }
            catch
            {
                Mounted11 = false;
            }



         









        }


        public String Id { get; }

        public bool Mounted11 { get; }

        public String Ten { get; }

    }
}
