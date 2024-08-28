using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.Dungeons

{
    

        public class DungeonHandler
        {
            public List<Dungeon> dungeonList;

            public DungeonHandler()
            {
                dungeonList = new List<Dungeon>();
            }

            public void addDungeon(int id, Single posX, Single posY,  string  name , int enchant)
            {

              Dungeon d = new Dungeon(id, posX, posY, name, enchant);

               
               if (!dungeonList.Contains(d))
                {
                    dungeonList.Add(d);
             
                }
            }
            public bool RemoveMob(int id)
            {
                return dungeonList.RemoveAll(x => x.Id == id) > 0;
            }

            public List<Dungeon> DungeonList
              {
                get { return dungeonList; }
            }

            internal void UpdateMobPosition(int id, float posX, float posY)
            {
                dungeonList.ForEach(p =>
                {
                    if (p.Id == id)
                    {
                        p.PosX = posX;
                        p.PosY = posY;
                    }
                });

            }


            internal void UpdateMobEnchantmentLevel(int mobId, byte enchantmentLevel)
            {
                dungeonList.First(x => x.Id == mobId).Enchant = enchantmentLevel;
            }
        }
    
}
