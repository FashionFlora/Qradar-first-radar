using System;
using System.Collections.Generic;

namespace LogicLyric
{
    public class LeaveEvent : BaseEvent
    {
        public LeaveEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            Id = parameters[0].ToString();
        }

        public string Id { get; }

    }
}
