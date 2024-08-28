using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
namespace LogicLyric
{


    public class PlayerNewItemEvent : BaseEvent
    {
        public PlayerNewItemEvent(Dictionary<byte, object> parameters) : base(parameters)
        {



            Id = parameters[0].ToString();

            try
            {
                Items = (Int16[])parameters[2];
            }
            catch
            {
                Items = null;
            }
     




        }


        public String Id { get; }
        public Int16[] Items { get; }



    }
}
