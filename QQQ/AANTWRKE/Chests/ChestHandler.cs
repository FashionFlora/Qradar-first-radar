using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLyric.Chests
{
    public class ChestHandler
    {
        public List<Chest> chestsList;

        public ChestHandler()
        {
            chestsList = new List<Chest>();
        }




        public void addChest(int id, Single posX, Single posY, string name)
        {

            Chest h = new Chest(id, posX, posY, name);
            if (!chestsList.Contains(h))
            {
                chestsList.Add(h);
          
            }
        

        }

        public bool RemoveChest(int id)
        {
            return chestsList.RemoveAll(x => x.Id == id) > 0;
        }
    }
}
