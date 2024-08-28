using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLyrico
{
    public  class Harvestable
    {
        public int id;
        public byte type;
        public byte tier;
     
        public Single posX;
        public Single posY;
        public byte charges;
        public int size;
    
        public string enchant;



        public Harvestable(int id, byte type, byte tier, Single posX, Single posY, byte charges, int size)
        {
            this.id = id;
            this.type = type;
            this.tier = tier;
            this.posX = posX;
            this.posY = posY;
            this.charges = charges;
            this.size = size;
        }


    }
}
