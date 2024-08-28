using LogicLyric;
using LogicLyric.Interfaces;
using LogicLyric.CanvasItems;
using LogicLyric.MVM.View;
using LogicLyric.Settings;
using LogicLyric.Utils;
using LogicLyrico;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Vector;
using Image = System.Windows.Controls.Image;
using Point = System.Windows.Point;

namespace LogicLyric.CanvasDrawings
{
    class DrawHarvestables
    {

       

        HarvestableHandler harvestableHandler;

        Canvas canva;
        public DrawHarvestables() { }
        public DrawHarvestables(HarvestableHandler harvestableHandler, Canvas canva)
        {

            this.harvestableHandler = harvestableHandler;
            this.canva = canva;


        }
        public void clearAll()
        {

            foreach (KeyValuePair<int, HarvestableDrawingItem> entry in CanvasHarvestableItem.harvestableItems)
            {



                canva.Children.Remove(entry.Value.ImageView);
                canva.Children.Remove(entry.Value.TextBlock);
                CanvasHarvestableItem.harvestableItems.Remove(entry.Key);




            }

        }

        public void invalidate(Single lpX, Single lpY, Matrix transformationMatrix)
        {



      

            
            
            
             foreach (KeyValuePair<int, HarvestableDrawingItem> entry in CanvasHarvestableItem.harvestableItems)
             {

                double distance = Math.Sqrt(Math.Pow(entry.Value.posX - lpX, 2) + Math.Pow(entry.Value.posY - lpY, 2));
                if(distance>100)
                {
                    harvestableHandler.RemoveHarvestable(entry.Key);
                    canva.Children.Remove(entry.Value.ImageView);
                    canva.Children.Remove(entry.Value.TextBlock);
                    CanvasHarvestableItem.harvestableItems.Remove(entry.Key);
                    continue;
                }
               if (!harvestableHandler.harvestableList.ToList().Any(x => (x.id == entry.Key)))
               {
               
                   canva.Children.Remove(entry.Value.ImageView);
                   canva.Children.Remove(entry.Value.TextBlock);
                   CanvasHarvestableItem.harvestableItems.Remove(entry.Key);
               }
                


            }

            








       //     var currentDirectory = System.IO.Directory.GetCurrentDirectory();

            float iconWidth = Properties.Settings.Default.sizeHarvestingSetting;




            foreach (Harvestable h in harvestableHandler.harvestableList)
            {





                if (h.size == 0)
                {

                    continue;
                }


                if (!RadarSettings.isInEnchants(h.charges))
                {
                    continue;
                }


                if (!RadarSettings.isInTiers(h.tier))
                {
                    continue;
                }

                if (!RadarSettings.isInHarvestable((HarvestableType)h.type))
                {
                    continue;
                }
        

                

    
          
                Single hX = -1 * h.posX + lpX;
                Single hY = h.posY - lpY;
                Point harvestablePoint = transformationMatrix.Transform(new Point(hX, hY));


               

                if (!CanvasHarvestableItem.harvestableItems.ContainsKey(h.id))
                {


             
                    string name = Enum.GetName(typeof(HarvestableType), h.type);
                    name = name.ToLower();

             






                    HarvestableDrawingItem harvestableDrawingItem = new HarvestableDrawingItem();
                    BitmapImage img = null;


           






                    if (name.Contains("fiber"))
                    {

               
     

                        img = Load.imageResources["fiber_" + h.tier + "_" + h.charges];

                    }
                    else if (name.Contains("wood"))
                    {

                        img = Load.imageResources["Logs_" + h.tier + "_" + h.charges ];
      

                    }
                    else if (name.Contains("ore"))
                    {


                        img = Load.imageResources["ore_" + h.tier + "_" + h.charges ];
            
                    }
                    else if(name.Contains("hide"))
                    {


                        img = Load.imageResources["hide_" + h.tier + "_" + h.charges];
      
                    }

                    else 
                    {

          
                        img = Load.imageResources["rock_" + h.tier + "_" + h.charges ];
     
                    }




                    


                    Image BodyImage = new Image
                    {
                        Width = iconWidth,
                        Height = iconWidth,
                        Source = img,
                    };
                    Canvas.SetLeft(BodyImage, harvestablePoint.X - iconWidth/2);
                    Canvas.SetTop(BodyImage, harvestablePoint.Y - iconWidth/2);
                    canva.Children.Add(BodyImage);
                    harvestableDrawingItem.ImageView = BodyImage;
                    harvestableDrawingItem.posX = h.posX;
                    harvestableDrawingItem.posY = h.posY;
                    
                    
                    CanvasHarvestableItem.harvestableItems.Add(h.id, harvestableDrawingItem);


                }
                else
                {

                  //  Utils.MoveTo(CanvasHarvestableItem.harvestableItems[h.id].ImageView, harvestablePoint.X - iconWidth / 2, harvestablePoint.Y - iconWidth / 2, speed);
                    Canvas.SetLeft(CanvasHarvestableItem.harvestableItems[h.id].ImageView, harvestablePoint.X- iconWidth / 2);
                  Canvas.SetTop(CanvasHarvestableItem.harvestableItems[h.id].ImageView, harvestablePoint.Y - iconWidth/2);
                }




                if (Properties.Settings.Default.harvestingSizeSetting)
                {
                    if (!canva.Children.Contains( CanvasHarvestableItem.harvestableItems[h.id].TextBlock))
                    {

                        TextBlock textBlock = new TextBlock();

                        textBlock.Text = h.size.ToString();
                        textBlock.FontSize = 13;

                        textBlock.Foreground = StaticBrushes.white;
                        Canvas.SetLeft(textBlock, harvestablePoint.X -4);
                        Canvas.SetTop(textBlock, harvestablePoint.Y  +iconWidth - iconWidth / 2 - 4);
                        canva.Children.Add(textBlock);


                        CanvasHarvestableItem.harvestableItems[h.id].TextBlock = textBlock;



                    }
                    else
                    {
                        CanvasHarvestableItem.harvestableItems[h.id].TextBlock.Text = h.size.ToString();
                       Canvas.SetLeft(CanvasHarvestableItem.harvestableItems[h.id].TextBlock, harvestablePoint.X -4);
                        Canvas.SetTop(CanvasHarvestableItem.harvestableItems[h.id].TextBlock, harvestablePoint.Y + iconWidth - iconWidth / 2 - 4);

          

                    }
                }
            }
        }



        internal void invalidateIcons()
        {
            foreach (KeyValuePair<int, HarvestableDrawingItem> entry in CanvasHarvestableItem.harvestableItems)
            {



                double oldWidth = entry.Value.ImageView.Width;
                double newWidth = (Properties.Settings.Default.sizeHarvestingSetting - oldWidth) / 2;

                entry.Value.ImageView.Width = Properties.Settings.Default.sizeHarvestingSetting;
                entry.Value.ImageView.Height = Properties.Settings.Default.sizeHarvestingSetting;
       //         Canvas.SetLeft(entry.Value.ImageView, Canvas.GetLeft(entry.Value.ImageView) - 33 );

    //            Canvas.SetTop(entry.Value.ImageView, Canvas.GetTop(entry.Value.ImageView) - 33);
        

               

            }
        }

        public void invalidateTiers()
        {
            foreach (KeyValuePair<int, bool> entry in RadarSettings.harvestingTiers)
            {

                if (!entry.Value)
                {


                    harvestableHandler.harvestableList.ForEach(x =>
                    {

                        if (entry.Key == x.tier)
                        {


                            if (CanvasHarvestableItem.harvestableItems.ContainsKey(x.id))
                            {


                                canva.Children.Remove(CanvasHarvestableItem.harvestableItems[x.id].ImageView);
                                canva.Children.Remove(CanvasHarvestableItem.harvestableItems[x.id].TextBlock);
                                CanvasHarvestableItem.harvestableItems.Remove(x.id);


                            }
                        }
                    });

                }
            }
        }

        public void invalidateEnchants()
        {
            foreach (KeyValuePair<int, bool> entry in RadarSettings.harvestingEnchants)
            {

                if (!entry.Value)
                {


                    harvestableHandler.harvestableList.ForEach(x =>
                    {

                        if (entry.Key == x.charges)
                        {


                            if (CanvasHarvestableItem.harvestableItems.ContainsKey(x.id))
                            {


                                canva.Children.Remove(CanvasHarvestableItem.harvestableItems[x.id].ImageView);
                                canva.Children.Remove(CanvasHarvestableItem.harvestableItems[x.id].TextBlock);
                                CanvasHarvestableItem.harvestableItems.Remove(x.id);


                            }
                        }
                    });

                }
            }
        }


        public void invalidateSize()
        {

            if (!Properties.Settings.Default.harvestingSizeSetting)
            {

                foreach (KeyValuePair<int, HarvestableDrawingItem> entry in CanvasHarvestableItem.harvestableItems)
                {
                    canva.Children.Remove(CanvasHarvestableItem.harvestableItems[entry.Key].TextBlock);
                    CanvasHarvestableItem.harvestableItems[entry.Key].TextBlock = null;

                }
            }
        }

        public void invalidateTypes()
        {
            harvestableHandler.harvestableList.ForEach(x =>
            {
                if (!RadarSettings.isInHarvestable((HarvestableType)x.type))
                {

                    if (CanvasHarvestableItem.harvestableItems.ContainsKey(x.id))
                    {
                        canva.Children.Remove(CanvasHarvestableItem.harvestableItems[x.id].ImageView);
                        canva.Children.Remove(CanvasHarvestableItem.harvestableItems[x.id].TextBlock);
                        CanvasHarvestableItem.harvestableItems.Remove(x.id);
                    }
                }
            });
        }
    }
}
