using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLyric.Chests
{
    public class Chest
    {

       private  Single posX;
       private Single posY;

       private string name;
        private int id;


        public Chest(int id , float posX, float posY, string name)
        {
            this.posX = posX;
            this.posY = posY;
            this.name = name;
            this.id = id;
        }

        public string Name { get => name; set => name = value; }
        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }
        public int Id { get => id; set => id = value; }
    }
}
