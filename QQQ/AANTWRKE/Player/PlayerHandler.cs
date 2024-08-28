using LogicLyric.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace LogicLyric
{
    public class PlayerHandler
    {
        public List<Player> playersInRange;
        public  Player localPlayer;
        public bool invalidate;

        public PlayerHandler()
        {
            playersInRange = new List<Player>();
            localPlayer = new Player();
        }


        public void AddPlayer(Single posX, Single posY,int id , string nickname , Single currentHealth , Single initialHeatlh , Int16[] items, string guildname)
        {



            foreach(Player player in playersInRange)
            {
                if(player.id == id)
                {
                    return;
                }
            }

            Player playerOne = new Player(posX, posY, id, nickname, currentHealth, initialHeatlh, items  , guildname);
            playersInRange.Add(playerOne);

   
         
            
     
        }



        internal void UpdatePlayerMounted(int id, bool mounted)
        {

            
            playersInRange.ForEach(player =>
            {
                if (player.id == id)
                {

                    player.mounted = mounted;


                }
            });
        }

        public  bool ReturnCanGo(int id)
        {

            bool can = false;

            playersInRange.ForEach(p =>
            {
                if (p.id == id)
                {


                    can = p.firstMount;

                }
            });
            return can;
        }


        internal void UpdatePlayerItem(int id, short[] items)
        {
            playersInRange.ForEach(playerOne =>
            {
                if (playerOne.id == id)
                {
                    playerOne.items = items;

                }
            });

        }

        public void RemovePlayer(int id)
        {
    
                playersInRange.RemoveAll(playerOne => playerOne.id == id);
            
        
        }
        internal List<Player> PlayersInRange
        {
            get { return playersInRange; }
        }
        public void UpdateLocalPlayerPosition(Single posX, Single posY)
        {

   

            localPlayer.posX = posX;
            localPlayer.posY = posY;

   
        }

        internal void UpdatePlayerPosition(int id, float posX, float posY)
        {
            playersInRange.ForEach(playerOne =>
            {
                if (playerOne.id == id)
                {
                    playerOne.posX = posX;
                    playerOne.posY = posY;
                }
            });
        }


        internal void UpdatePlayerHealth(int id, Single currentHealh)
        {
            playersInRange.ForEach(playerOne =>
            {
                if (playerOne.id == id)
                {
                    playerOne.currentHealth = currentHealh;

                }
            });

        }



        internal void UpdatePlayerInitialHealth(int id, Single currentHealh , Single initialHealth)
        {
            playersInRange.ForEach(playerOne =>
            {
                if (playerOne.id == id)
                {
                    playerOne.currentHealth = currentHealh;
                    playerOne.initialHealth = initialHealth;

                }
            });

        }
        public Single localPlayerPosX()
        {
            return localPlayer.posX;

        }
        public Single localPlayerPosY()
        {
            return localPlayer.posY;
        }
    }
}
