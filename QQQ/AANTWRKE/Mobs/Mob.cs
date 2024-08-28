using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyrico.Mobs
{
    public class Mob
    {
        public int id;
        public int typeId;
        public Single posX;
        public Single posY;
        public int health;
        public byte enchantmentLevel;

        public byte rarity;
        public int tier;
        public int type =2;
        public string name;
        public int exp = 0;


        public Mob(int id, int typeId, Single posX, Single posY, int health, byte enchantmentLevel , byte rarity , int exp)
        {
            this.id = id;
            this.typeId = typeId;
            this.posX = posX;
            this.posY = posY;
            this.health = health;
            this.rarity = rarity;
            this.enchantmentLevel = enchantmentLevel;
            this.exp = exp;

        //    mobInfo = MobInfo.getMobInfo(typeId);
        }


        


    }
}
