using LogicLyric;
using LogicLyric.Chests;
using LogicLyric.Interfaces;
using LogicLyric.CanvasItems;
using LogicLyric.MVM.View;
using LogicLyric.Settings;
using LogicLyric.Utils;
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

namespace LogicLyric.CanvasDrawings
{
    class DrawChests
    {


        ChestHandler chestHandler;

        private Single hX;
        private Single hY;
        Canvas canva;
        public DrawChests() { }
        public DrawChests(ChestHandler chestHandler, Canvas canva)
        {

            this.chestHandler = chestHandler;
            this.canva = canva;


        }



        int iconWidthChest = 50;

        public void clearAll()
        {



            foreach (KeyValuePair<int, ChestDrawingItem> entry in CanvasChestItems.chests)
            {


                canva.Children.Remove(entry.Value.ImageView);
                CanvasChestItems.chests.Remove(entry.Key);

            }
        }


        public void invalidate(Single lpX, Single lpY, Matrix transformationMatrix)
        {



            foreach (KeyValuePair<int, ChestDrawingItem> entry in CanvasChestItems.chests)
            {

                if (!chestHandler.chestsList.Any(x => (x.Id == entry.Key)))
                {

                    canva.Children.Remove(entry.Value.ImageView);
                    CanvasChestItems.chests.Remove(entry.Key);
                }
            }



            foreach (Chest ch in chestHandler.chestsList)
            {


                string nameChest = ch.Name.ToLower();

                if (!RadarSettings.isInChestsEnchant(nameChest))
                {
                    continue;

                }
            
                hX = -1 * ch.PosX + lpX;
                hY = ch.PosY - lpY;

                Point chestPosPoint = transformationMatrix.Transform(new Point(hX, hY));

                var currentDirectory = System.IO.Directory.GetCurrentDirectory();
                if (CanvasChestItems.chests.ContainsKey(ch.Id))
                {
                    Canvas.SetLeft(CanvasChestItems.chests[ch.Id].ImageView, chestPosPoint.X - iconWidthChest / 2);
                    Canvas.SetTop(CanvasChestItems.chests[ch.Id].ImageView, chestPosPoint.Y - iconWidthChest / 2);

                }
                else
                {


                    ChestDrawingItem chestDrawingItem = new ChestDrawingItem();
                    CanvasChestItems.chests.Add(ch.Id, chestDrawingItem);

                    Image BodyImage = null;





                    if (nameChest.Contains("standard") || nameChest.Contains("green"))
                    {


                        BitmapImage img = Load.imageResources["green"];

                        BodyImage = new Image
                        {
                            Width = iconWidthChest,
                            Height = iconWidthChest,
                   
                            Source = img
                        };


                        Canvas.SetLeft(BodyImage, chestPosPoint.X - iconWidthChest / 2);
                        Canvas.SetTop(BodyImage, chestPosPoint.Y - iconWidthChest / 2);
                        canva.Children.Add(BodyImage);
                        CanvasChestItems.chests[ch.Id].ImageView = BodyImage;


                    }
                    else if (nameChest.Contains("uncommon") || nameChest.Contains("blue"))
                    {



                        BitmapImage img = Load.imageResources["blue"];

                        BodyImage = new Image
                        {
                            Width = iconWidthChest,
                            Height = iconWidthChest,
           
                            Source = img
                        };

                        Canvas.SetLeft(BodyImage, chestPosPoint.X - iconWidthChest / 2);
                        Canvas.SetTop(BodyImage, chestPosPoint.Y - iconWidthChest / 2);
                        canva.Children.Add(BodyImage);
                        CanvasChestItems.chests[ch.Id].ImageView = BodyImage;




                    }
                    else if (nameChest.Contains("rare") || nameChest.Contains("purple"))
                    {


                        BitmapImage img = Load.imageResources["rare"];

                        BodyImage = new Image
                        {
                            Width = iconWidthChest,
                            Height = iconWidthChest,

                            Source = img
                        };
                        Canvas.SetLeft(BodyImage, chestPosPoint.X - iconWidthChest / 2);
                        Canvas.SetTop(BodyImage, chestPosPoint.Y - iconWidthChest / 2);
                        canva.Children.Add(BodyImage);
                        CanvasChestItems.chests[ch.Id].ImageView = BodyImage;




                    }
                    else if (nameChest.Contains("legendary") || nameChest.Contains("yellow"))
                    {

                        BitmapImage img  = Load.imageResources["legendary"];
                        BodyImage = new Image
                        {
                            Width = iconWidthChest,
                            Height = iconWidthChest,
                            Source = img
                        };
                        Canvas.SetLeft(BodyImage, chestPosPoint.X - iconWidthChest / 2);
                        Canvas.SetTop(BodyImage, chestPosPoint.Y - iconWidthChest / 2);
                        canva.Children.Add(BodyImage);
                        CanvasChestItems.chests[ch.Id].ImageView = BodyImage;
                    }












                }




            }


        }


        public void invalidateEnchant()
        {




            foreach (KeyValuePair<string, bool> entry in RadarSettings.chestEnchants)
            {



                if (!entry.Value)
                {

                    chestHandler.chestsList.ForEach(x =>
                    {

                        if (x.Name.ToLower().Contains(entry.Key))
                        {

                            if (CanvasChestItems.chests.ContainsKey(x.Id))
                            {


                                canva.Children.Remove(CanvasChestItems.chests[x.Id].ImageView);

                                CanvasChestItems.chests.Remove(x.Id);


                            }



                        }



                    });


                }



            }




        }


    }
}
