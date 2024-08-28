using LogicLyric;
using LogicLyric.Interfaces;
using LogicLyric.CanvasItems;
using LogicLyric.MVM.View;
using LogicLyric.Settings;
using LogicLyric.Utils;
using LogicLyrico.Mobs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Vector;
using Image = System.Windows.Controls.Image;
using Point = System.Windows.Point;
using LogicLyric.Dungeons;

namespace LogicLyric.CanvasDrawings
{


    public class DrawDungeons
    {


        DungeonHandler dungoenHandler;

        private Single hX;
        private Single hY;
        Canvas canva;
        public DrawDungeons() { }
        public DrawDungeons(DungeonHandler dungoenHandler, Canvas canva)
        {

            this.dungoenHandler = dungoenHandler;
            this.canva = canva;


        }



        int iconWidthChest = 30;

        public void clearAll()
        {



            foreach (KeyValuePair<int, DungeonDrawingItem> entry in CanvasDungeonItems.dungeonItems)
            {


                
                canva.Children.Remove(entry.Value.dungeon);
                CanvasDungeonItems.dungeonItems.Remove(entry.Key);
                

            }
        }


        public void invalidate(Single lpX, Single lpY, Matrix transformationMatrix)
        {


            foreach (KeyValuePair<int, DungeonDrawingItem> entry in CanvasDungeonItems.dungeonItems)
            {

                if (!dungoenHandler.dungeonList.Any(x => (x.Id == entry.Key)))
                {
                    canva.Children.Remove(entry.Value.dungeon);
                    CanvasDungeonItems.dungeonItems.Remove(entry.Key);
                }
            }
            foreach (Dungeon d in dungoenHandler.DungeonList)
            {


                string nameDungeon = d.Name.ToLower(); 
   


                if(nameDungeon.Contains("hellgate"))
                {
                    if (!Properties.Settings.Default.hellgateSetting)
                    {
                        continue;
                    }
                }
                else if(nameDungeon.Contains("corrupt"))
                {
                    if (!Properties.Settings.Default.corruptSetting)
                    {
                        continue;

                    }

                        
                    
                }
                else
                {

                    if (!RadarSettings.isInDungeonEnchant(d.Enchant))
                    {
                        continue;

                    }
               
                    if (!RadarSettings.isInDungeonType(d.Type))
                    {
                        continue;

                    }
             
                }


                hX = -1 * d.PosX + lpX;
                hY = d.PosY - lpY;



         
                Point dungeonPoint = transformationMatrix.Transform(new Point(hX, hY));

                var currentDirectory = System.IO.Directory.GetCurrentDirectory();
                if (CanvasDungeonItems.dungeonItems.ContainsKey(d.Id))
                {
                    Canvas.SetLeft(CanvasDungeonItems.dungeonItems[d.Id].dungeon, dungeonPoint.X - iconWidthChest / 2);
                    Canvas.SetTop(CanvasDungeonItems.dungeonItems[d.Id].dungeon, dungeonPoint.Y - iconWidthChest / 2);

                }
                else
                {


                    DungeonDrawingItem dungeonDrawingItem = new DungeonDrawingItem();
                    CanvasDungeonItems.dungeonItems.Add(d.Id, dungeonDrawingItem);

                    Image BodyImage = null;


               


                    BitmapImage img = null;



                    if (nameDungeon.Contains("corrupt"))
                    {

                        img = Load.imageResources["corrupt"];

                   //     img = new BitmapImage(new Uri(currentDirectory + "/Images//dungeon/corrupt.png"));


                    }
                    else if(nameDungeon.Contains("hellgate"))
                    {

                        img = Load.imageResources["hellgate"];
                   //     img = new BitmapImage(new Uri(currentDirectory + "/Images//dungeon/hellgate.png"));
                    }
                    else
                    {
                        img = Load.imageResources["dungeon_" + d.Enchant];
                //        img = new BitmapImage(new Uri(currentDirectory + "/Images//dungeon/dungeon_" + d.Enchant + ".png"));
                    }
         
                    BodyImage = new Image
                    {
                        Width = iconWidthChest,
                        Height = iconWidthChest,
                        Source = img
                    };
                    
                    Canvas.SetLeft(BodyImage, dungeonPoint.X - iconWidthChest / 2);
                    Canvas.SetTop(BodyImage, dungeonPoint.Y - iconWidthChest / 2);
                    canva.Children.Add(BodyImage);
                    CanvasDungeonItems.dungeonItems[d.Id].dungeon = BodyImage;
                }
            }

        }

        public void invalidateHellGate()
        {



            if (!Properties.Settings.Default.hellgateSetting)
            {


                dungoenHandler.dungeonList.ForEach(x =>
                {
                    if (x.Name.ToLower().Contains("hellgate"))
                    {
                        if (CanvasDungeonItems.dungeonItems.ContainsKey(x.Id))
                        {
                            canva.Children.Remove(CanvasDungeonItems.dungeonItems[x.Id].dungeon);
                            CanvasDungeonItems.dungeonItems.Remove(x.Id);
                        }
                    }
                });
            }

        }


        public void invalidateCorrupt()
        {

            if(!Properties.Settings.Default.corruptSetting)
            {



                        dungoenHandler.dungeonList.ForEach(x =>
                        {
                            if (x.Name.ToLower().Contains("corrupt"))
                            {
                                if (CanvasDungeonItems.dungeonItems.ContainsKey(x.Id))
                                {
                                    canva.Children.Remove(CanvasDungeonItems.dungeonItems[x.Id].dungeon);
                                    CanvasDungeonItems.dungeonItems.Remove(x.Id);
                                }
                            }
                        });
                    
                

            }

        }
        public void invalidateEnchant()
        {



            foreach (KeyValuePair<int, bool> entry in RadarSettings.dungeonEnchant)
            {

    

                if (!entry.Value)
                {
                    dungoenHandler.dungeonList.ForEach(x =>
                    {
                        if (entry.Key == x.Enchant)
                        {
                            if (CanvasDungeonItems.dungeonItems.ContainsKey(x.Id))
                            {
                                canva.Children.Remove(CanvasDungeonItems.dungeonItems[x.Id].dungeon);
                                CanvasDungeonItems.dungeonItems.Remove(x.Id);
                            }
                        }
                    });
                }
            }
        }


        public void invalidateType()
        {



            foreach (KeyValuePair<int, bool> entry in RadarSettings.dungeonType)
            {

                if (!entry.Value)
                {


                    dungoenHandler.dungeonList.ForEach(x =>
                    {

                        if (entry.Key == x.Type)
                        {

                            if (CanvasDungeonItems.dungeonItems.ContainsKey(x.Id))
                            {

                                canva.Children.Remove(CanvasDungeonItems.dungeonItems[x.Id].dungeon);
                                CanvasDungeonItems.dungeonItems.Remove(x.Id);


                            }
                        }
                    });

                }
            }


        }

    }
}
