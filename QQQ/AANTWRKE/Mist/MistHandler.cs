using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace LogicLyric.Mists
{
    public class MistHandler
    {
        public List<Mist> mistList;

        public MistHandler()
        {
            mistList = new List<Mist>();
        }

        public void addMist(int id, Single posX, Single posY, string name, int enchant)
        {

            Mist d = new Mist(id, posX, posY, name, enchant);


            if (!mistList.Contains(d))
            {
                mistList.Add(d);

            }
        }
        public bool RemoveMob(int id)
        {
            return mistList.RemoveAll(x => x.id == id) > 0;
        }

        public List<Mist> MistList
        {
            get { return mistList; }
        }

        internal void UpdateMobPosition(int id, float posX, float posY)
        {
            mistList.ForEach(p =>
            {
                if (p.id == id)
                {
                    p.posX = posX;
                    p.posY = posY;
                }
            });

        }


        internal void UpdateMobEnchantmentLevel(int mobId, byte enchantmentLevel)
        {
            mistList.First(x => x.id == mobId).enchant = enchantmentLevel;
        }
    }

}
