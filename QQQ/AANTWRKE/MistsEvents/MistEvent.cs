using LogicLyric.AAParser;
using System;
using System.Collections.Generic;

namespace LogicLyric
{
    public class MistEvent : BaseEvent
    {
        public MistEvent(Dictionary<byte, object> parameters) : base(parameters)
        {




            try
            {

                Position = ObjectConverter.ConvertArray<float>((object[])parameters[7]);
         

                Id = parameters[0].ToString();
         
                Name = parameters[32].ToString();
        
         
                Enchant = parameters[33].ToString();
    

            }
            catch
            {

                Name = null;
            }

            if (Name == null)
            {


                try
                {
                    Name = parameters[31].ToString();
                }
                catch
                {
                    Name = null;
                }
            }
        



        }

        public String Id { get; }

        public String Name { get; }

        public Single[]  Position { get; }


        public string Enchant { get; }

    }
}
