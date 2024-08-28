using LogicLyric.AAParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLyric.HarvestableCodes
{
    public class AvalonEvent : BaseEvent
    {

        public AvalonEvent(Dictionary<byte, object> parameters) : base(parameters)
        {


   
             ChestId = parameters[0].ToString();
           
   
           
            ChestsPosition = ObjectConverter.ConvertArray<Single>((object[])parameters[1]);
            ChestName = (String)parameters[3].ToString();

            if(ChestName.ToLower().Contains("mist"))
            {
                ChestName = (String)parameters[4].ToString();
            }
        }

        public Single[] ChestsPosition { get; set; }
        public String ChestName { get; set; }

        public String ChestId { get; set; }



    }
}
