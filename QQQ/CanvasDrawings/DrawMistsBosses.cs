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



    class DrawMistsBosses
    {


        int iconWidthChest = 60;
        MistHandler mobsHandler;

        private Single hX;
        private Single hY;
        Canvas canva;
        public DrawMistsBosses() { }
        public DrawMistsBosses(MistHandler mobsHandler, Canvas canva)
        {

            this.mobsHandler = mobsHandler;
            this.canva = canva;


        }






        public void invalidate(Single lpX, Single lpY, Matrix transformationMatrix)
        {
            foreach (KeyValuePair<int, MistBossDrawingItem> entry in CanvasMistBossesItems.mistBossesItems)
            {
                if (!mobsHandler.mistList.Any(mistBossOne => (mistBossOne.id == entry.Key)))
                {
                    canva.Children.Remove(entry.Value.ImageView);
                    CanvasMistBossesItems.mistBossesItems.Remove(entry.Key);
                }
            }



            foreach (Mist mistBossOne in mobsHandler.mistList)
            {





                string nameDungeon = mistBossOne.name.ToLower();

                if (!RadarSettings.isInMistBossesType(mistBossOne.name))
                {
                    continue;

                }
       

                hX = -1 * mistBossOne.posX + lpX;
                hY = mistBossOne.posY - lpY;




                Point mistPoint = transformationMatrix.Transform(new Point(hX, hY));

                var currentDirectory = System.IO.Directory.GetCurrentDirectory();
                if (CanvasMistBossesItems.mistBossesItems.ContainsKey(mistBossOne.id))
                {
                    Canvas.SetLeft(CanvasMistBossesItems.mistBossesItems[mistBossOne.id].ImageView, mistPoint.X - iconWidthChest / 2);
                    Canvas.SetTop(CanvasMistBossesItems.mistBossesItems[mistBossOne.id].ImageView, mistPoint.Y - iconWidthChest / 2);

                }
                else
                {


                    MistBossDrawingItem mistDrawingItem = new MistBossDrawingItem();
                    CanvasMistBossesItems.mistBossesItems.Add(mistBossOne.id, mistDrawingItem);

                    Image BodyImage = null;
                    BitmapImage img = null;

                    if (mistBossOne.name.ToLower().Contains("griffin"))
                    {

                        img = Load.imageResources["GRIFFIN"];
               
                    }

                    else if (mistBossOne.name.ToLower().Contains("fairydragon"))
                    {
    
                        img = Load.imageResources["FAIRYDRAGON"];
                    }

                    else if (mistBossOne.name.ToLower().Contains("veilweaver"))
                    {
                       // img = new BitmapImage(new Uri(currentDirectory + "/Images//bosses/VEILWEAVER.png"));

                        img = Load.imageResources["VEILWEAVER"];
                    }
                    else if ((mistBossOne.name.ToLower().Contains("spider")))
                    {
                        img = Load.imageResources["CRYSTALSPIDER"];



                    }



                    if(img!=null)
                    {

      

                        BodyImage = new Image
                        {
                            Width = iconWidthChest,
                            Height = iconWidthChest,
  
                            Source = img
                        };


                        Canvas.SetLeft(BodyImage, mistPoint.X - iconWidthChest / 2);
                        Canvas.SetTop(BodyImage, mistPoint.Y - iconWidthChest / 2);
                        canva.Children.Add(BodyImage);
                        CanvasMistBossesItems.mistBossesItems[mistBossOne.id].ImageView = BodyImage;
                    }












                }





            }


        }

        internal void invalidateType()
        {


            foreach (KeyValuePair<string, bool> entry in RadarSettings.mistBossesType)
            {


                if (!entry.Value)
                {


                    mobsHandler.mistList.ForEach(x =>
                    {

                        if (x.name.ToLower().Contains(entry.Key.ToLower()))
                        {

                            if (CanvasMistBossesItems.mistBossesItems.ContainsKey(x.id))
                            {

                                canva.Children.Remove(CanvasMistBossesItems.mistBossesItems[x.id].ImageView);
                                CanvasMistBossesItems.mistBossesItems.Remove(x.id);


                            }
                        }
                    });

                }
            }

        }

    }
    

}
