using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLyric.HarvestableCodes
{
    public class HarvestFinishedEvent : BaseEvent
    {

        public HarvestFinishedEvent(Dictionary<byte, object> parameters) : base(parameters)
        {

             harvestableId = int.Parse(parameters[3].ToString());
            count = int.Parse(parameters[5].ToString());

        }

        public int harvestableId { get; }
        public int count { get; }




    }
}
