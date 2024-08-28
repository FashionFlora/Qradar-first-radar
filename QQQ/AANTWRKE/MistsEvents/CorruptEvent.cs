using System;
using System.Collections.Generic;
using System.Collections.Generic;
namespace LogicLyric
{
    public class CorruptEvent : BaseEvent
    {
        public CorruptEvent(Dictionary<byte, object> parameters) : base(parameters)
        {



            Id = parameters[0].ToString();



        }

        public String Id { get; }

        public Single CurrentHealth { get; }

    }
}
