using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric.Mists
{
    public class Mist
    {
        public  int id;
        public float posX;
        public float posY;
        public string name;
        public int enchant;

        public int type = 0;

        public Mist(int id, float posX, float posY, string name, int enchant)
        {
            this.id = id;
            this.posX = posX;
            this.posY = posY;
            this.name = name;
            this.enchant = enchant;

            if(name.ToLower().Contains("solo"))
            {
                this.type = 0;

            }
            else
            {
                this.type = 1;

            }
           
        }


    
    }
}
