using System;
using System.Collections.Generic;
using System.Text;
using LogicLyric.AAParser;

namespace LogicLyric.HarvestableCodes
{
    public class NewMobEvent : BaseEvent
    {

        public NewMobEvent(Dictionary<byte, object> parameters) : base(parameters)
        {



            id = int.Parse(parameters[0].ToString());

            typeId = int.Parse(parameters[1].ToString());

            try
            {
                Exp = float.Parse(parameters[13].ToString());
            }
            catch
            {
                Exp = 0;

            }
        


            try
            {


                Name = parameters[32].ToString();
            }
            catch
            {

                Name = null;
            }

            try
            {


                Enchant = parameters[33].ToString();
            }
            catch
            {

                Enchant = null;
            }



            if (Name==null)
            {

                try
                {
                    Name = parameters[29].ToString();
                }
                catch
                {

                    Name = null;
                }

            }





       
            Single[] loc = ObjectConverter.ConvertArray<float>((object[]) parameters[7]);

            posX = (Single)loc[0];
            posY = (Single)loc[1];

  

            try {

                rarity = (byte)byte.Parse(parameters[19].ToString());

            }
            catch
            {
                rarity = 1;


            }



        

        }

        public int typeId { get; }
        public int health { get; }
        public byte rarity { get; }
        public int id { get; }


        public float Exp { get; }

        public Single posX { get; }

        public Single posY { get; }



        public String Id { get; }

        public String Name { get; }

        public Single[] Position { get; }


        public string Enchant { get; }



    }
}