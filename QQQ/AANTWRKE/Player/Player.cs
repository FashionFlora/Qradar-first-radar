using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
namespace LogicLyric
{
    public class Player
    {
        public Single posX;
        public Single posY;
        public string nickname;
        public string guildName;
        public string alliance;
        public int id;
        public int health;

        public Single currentHealth;
        public Int16[] items;
        public Single initialHealth;
        public  bool mounted;
        public bool firstMount = false;
        public bool invalidate = false;

        public Player()
        {
            posX = 0;
            posY = 0;
            nickname = "";
            guildName = "";
            alliance = "";
            id = 0;
        }

        public Player(Single posX, Single posY, int id, String nickname, Single currentHealth, Single initialHealth, Int16[] items , string guildname )
        {
            this.posX = posX;
            this.posY = posY;
            this.id = id;
            this.nickname = nickname;
            this.items = items;
            this.guildName = guildname;




            this.currentHealth = currentHealth;
            this.initialHealth = initialHealth;
        }
 


    }
}
