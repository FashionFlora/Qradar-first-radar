
using System.Collections.Generic;

using System.Text;
using System.Collections.Generic;
using LogicLyric.Repositories;

namespace LogicLyric
{
    public class PlayerItemHandler
    {


        private Dictionary<int, string> items;

        public Dictionary<int, string> Items { get => items; set => items = value; }

        public  void addItem(int code, string itemName)
        {

            // items.Add(code, itemName);

            code = code - 1;

            StringBuilder itemNameBuilder = new StringBuilder(itemName);

            int counter = 0;



            for (int i = 4; i <= 8; i++)
            {


                counter++;
                itemNameBuilder[1] = char.Parse(i.ToString());
                Items.Add(code + counter, itemNameBuilder.ToString());


                for (int j = 1; j <= 4; j++)
                {
                    counter++;

                    itemName = itemNameBuilder + "@" + j;

         
                    Items.Add(code + counter, itemName);


                }


            }
        }




        public PlayerItemHandler()
        {

            items = new Dictionary<int, string>();
            Dictionary<int, ItemsData>  itemsData = new Dictionary<int, ItemsData>();
            UserRepository userRepository = new UserRepository();
            itemsData = userRepository.getItems();

            foreach(var playerOne in itemsData)
            {

                if(playerOne.Value.isLoop)
                {
                    addItem(playerOne.Key, playerOne.Value.name);
                }
                else
                {
                    items.Add(playerOne.Key, playerOne.Value.name);
                }
            }



        }



    }
}
