using LogicLyric.AAParser;
using System;
using System.Collections.Generic;

namespace LogicLyric
{
    public class DungeonEvent : BaseEvent
    {
        public DungeonEvent(Dictionary<byte, object> parameters) : base(parameters)
        {



            Id = parameters[0].ToString();
            Position = ObjectConverter.ConvertArray<float>((object[])parameters[1]);
            Name = parameters[3].ToString();
            Enchant = parameters[6].ToString();


            



        }

        public String Id { get; }

        public Single[] Position{ get; }


        public String Name { get; }


        public string Enchant { get; }
    }
}
