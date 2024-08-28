using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLyric.Mobs;
using LogicLyric.Repositories;

namespace LogicLyrico.Mobs
{



    public class MobsHandler
    {
        public List<Mob> mobsList;
  


        public Dictionary<int, MobsInfo> mobinfo = new Dictionary<int, MobsInfo>();


        public MobsHandler()
        {
            mobsList = new List<Mob>();

            UserRepository userRepository = new UserRepository();

            mobinfo = userRepository.getMobs();
                
        

        }

        public void AddMob(int id, int typeId, Single posX, Single posY, int health, byte enchant, byte rarity, int exp)
        {


            Mob h = new Mob(id, typeId, posX, posY, health, enchant, rarity, exp);

            if (mobinfo.ContainsKey(typeId))
            {

                h.tier = mobinfo[typeId].tier;
                h.type = mobinfo[typeId].type;
                h.name = mobinfo[typeId].localization;

            }
            if (!mobsList.Contains(h))
            {
                mobsList.Add(h);
     
            }
        }
        public void RemoveMob(int id)
        {
            mobsList.RemoveAll(x => x.id == id);
        }

        public List<Mob> MobList
        {
            get { return mobsList; }
        }

        internal void UpdateMobPosition(int id, float posX, float posY)
        {
            mobsList.ForEach(position =>
            {
                if (position.id == id)
                {
                    position.posX = posX;
                    position.posY = posY;
                }
            });

        }


        internal void UpdateMobEnchantmentLevel(int mobId, byte enchantmentLevel)
        {
            mobsList.First(x => x.id == mobId).enchantmentLevel = enchantmentLevel;
        }
    }
}
