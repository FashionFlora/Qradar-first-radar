using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicLyrico
{
    public class HarvestableHandler
    {
        public List<Harvestable> harvestableList;

        public HarvestableHandler()
        {
            harvestableList = new List<Harvestable>();
        }

        public void AddHarvestable(int id, byte type, byte tier, Single posX, Single posY, byte charges, byte size)
        {
        

                Harvestable h = new Harvestable(id, type, tier, posX, posY, charges, size);
                if (!harvestableList.Contains(h))
                {
                    harvestableList.Add(h);
          
                }
                else
                {
                    h.charges = charges;
                }
            
    
 
        }

   
        public bool RemoveHarvestable(int id)
        {
            //return false;
            return harvestableList.RemoveAll(x => x.id == id) > 0;
        }
        internal List<Harvestable> HarvestableList
        {
            get { return harvestableList; }
        }


        internal void UpdateHarvestable(int harvestableId, int count)
        {
            harvestableList.ForEach(h =>
            {
                if (h.id == harvestableId)
                {
    
                    int  size  = h.size - count;
                    if(size <= 0)
                    {
                        RemoveHarvestable(harvestableId);
                    }
                    else
                    {
                        h.size = size;

                    }

                }
            });


        }

    }
}
