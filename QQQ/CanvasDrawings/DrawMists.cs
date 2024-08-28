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
using LogicLyric.Mists;

namespace LogicLyric.CanvasDrawings
{



    class DrawMists
    {


        int iconWidthChest = 30;
        MistHandler mobsHandler;

        private Single hX;
        private Single hY;
        Canvas canva;
        public DrawMists() { }
        public DrawMists(MistHandler mobsHandler, Canvas canva)
        {

            this.mobsHandler = mobsHandler;
            this.canva = canva;


        }




        public void clearAll()
        {


            foreach (KeyValuePair<int, MistDrawingItem> entry in CanvasMistItems.mistItems)
            {

                canva.Children.Remove(entry.Value.ImageView);
     
                CanvasMobItems.mobs.Remove(entry.Key);

            }
        }


        public void invalidate(Single lpX, Single lpY, Matrix transformationMatrix)
        {
            foreach (KeyValuePair<int, MistDrawingItem> entry in CanvasMistItems.mistItems)
            {
                if (!mobsHandler.mistList.Any(x => (x.id == entry.Key)))
                {
                    canva.Children.Remove(entry.Value.ImageView);
                    CanvasMistItems.mistItems.Remove(entry.Key);
                }
            }



            foreach (Mist m in mobsHandler.mistList)
            {





                string nameDungeon = m.name.ToLower();


                if (!RadarSettings.isInMistEnchant(m.enchant))
                {
                    continue;

                }
           
                if (!RadarSettings.isInMistType(m.type))
                {
                    continue;

                }
           
      
                hX = -1 * m.posX + lpX;
                hY = m.posY - lpY;






                Point mistPoint = transformationMatrix.Transform(new Point(hX, hY));

                var currentDirectory = System.IO.Directory.GetCurrentDirectory();
                if (CanvasMistItems.mistItems.ContainsKey(m.id))
                {
                    Canvas.SetLeft(CanvasMistItems.mistItems[m.id].ImageView, mistPoint.X - iconWidthChest / 2);
                    Canvas.SetTop(CanvasMistItems.mistItems[m.id].ImageView, mistPoint.Y - iconWidthChest / 2);

                }
                else
                {



                    if (m.name.ToLower().Contains("solo") || m.name.ToLower().Contains("duo"))
                    {



                        MistDrawingItem mistDrawingItem = new MistDrawingItem();
                        CanvasMistItems.mistItems.Add(m.id, mistDrawingItem);

                        Image BodyImage = null;

                        BitmapImage img = Load.imageResources["mist_" + m.enchant ];

                    //    BitmapImage img = new BitmapImage(new Uri(currentDirectory + "/Images//mist/mist_" + m.Enchant + ".png"));

                        BodyImage = new Image
                        {
                            Width = iconWidthChest,
                            Height = iconWidthChest,
                  
                            Source = img
                        };


                        Canvas.SetLeft(BodyImage, mistPoint.X - iconWidthChest / 2);
                        Canvas.SetTop(BodyImage, mistPoint.Y - iconWidthChest / 2);
                        canva.Children.Add(BodyImage);
                        CanvasMistItems.mistItems[m.id].ImageView = BodyImage;
                    }




                }





            }


        }

        internal void invalidateType()
        {

         
            foreach (KeyValuePair<int, bool> entry in RadarSettings.mistType)
            {


         

                if (!entry.Value)
                {


                    mobsHandler.mistList.ForEach(x =>
                    {

                        if (entry.Key == x.type)
                        {

                            if (CanvasMistItems.mistItems.ContainsKey(x.id))
                            {

                                canva.Children.Remove(CanvasMistItems.mistItems[x.id].ImageView);
                                CanvasMistItems.mistItems.Remove(x.id);


                            }
                        }
                    });

                }
            }

        }

        internal void invalidateEnchant()
        {



      
     
            foreach (KeyValuePair<int, bool> entry in RadarSettings.mistEnchant)
            {

        
                if (!entry.Value)
                {

                   
                    mobsHandler.mistList.ForEach(x =>
                    {
                        if (entry.Key == x.enchant)
                        {
                            if (CanvasMistItems.mistItems.ContainsKey(x.id))
                            {
                                canva.Children.Remove(CanvasMistItems.mistItems[x.id].ImageView);
                                CanvasMistItems.mistItems.Remove(x.id);
                            }
                        }
                    });

                }
            }
        }
    }

}
