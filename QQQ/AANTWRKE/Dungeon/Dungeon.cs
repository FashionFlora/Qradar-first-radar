using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.Dungeons
{
    public class Dungeon
    {



        int id;
        Single posX;
        Single posY;

        string name;
        int enchant;

        int type =0;


   

        public Dungeon(int id, float posX, float posY, string name, int enchant1)
        {
            this.id = id;
            this.posX = posX;
            this.posY = posY;
            this.name = name;
            this.enchant = enchant1;

            if (name.ToLower().Contains("solo"))
            {
                this.Type = 0;

            }
            else
            {
                this.Type = 1;

            }


        }

        public int Id { get => id; set => id = value; }
        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }
        public string Name { get => name; set => name = value; }
        public int Enchant { get => enchant; set => enchant = value; }
        public int Type { get => type; set => type = value; }
    }
}
