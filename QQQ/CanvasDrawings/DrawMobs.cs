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

namespace LogicLyric.CanvasDrawings
{
    class DrawMobs
    {


        MobsHandler mobsHandler;

        private Single hX;
        private Single hY;
        Canvas canva;
        public DrawMobs() { }
        public DrawMobs(MobsHandler mobsHandler, Canvas canva)
        {

            this.mobsHandler = mobsHandler;
            this.canva = canva;


        }

    
        public void clearAll()
        {


            foreach (KeyValuePair<int, MobDrawingItem> entry in CanvasMobItems.mobs)
            {

                canva.Children.Remove(entry.Value.normal);
                canva.Children.Remove(entry.Value.enchantment);
                CanvasMobItems.mobs.Remove(entry.Key);

            }
        }

        public void invalidate(Single lpX, Single lpY, Matrix transformationMatrix)
        {





            foreach (KeyValuePair<int, MobDrawingItem> entry in CanvasMobItems.mobs)
            {

                if (!mobsHandler.mobsList.Any(x => (x.id == entry.Key)))
                {

                    canva.Children.Remove(entry.Value.normal);
                    canva.Children.Remove(entry.Value.enchantment);
                    canva.Children.Remove(entry.Value.hideImageView);
                    canva.Children.Remove(entry.Value.harvestImage);
                    canva.Children.Remove(entry.Value.TextBlock);
                    canva.Children.Remove(entry.Value.bossImage);
                    canva.Children.Remove(entry.Value.droneImage);

                    canva.Children.Remove(entry.Value.devModeTextBlock);
                    CanvasMobItems.mobs.Remove(entry.Key);
                    
                }
            }


            int sizeIcon = 40;


            foreach (Mob mobOne in mobsHandler.mobsList)
            {




                if (mobOne.type == 3 || mobOne.type == 4)
                {

                    if(mobOne.type ==3 && !Properties.Settings.Default.otherBossesSetting)
                    {
                        continue;

                    }
                    if (mobOne.type == 4 && !Properties.Settings.Default.avalonDronesSetting)
                    {
                        continue;

                    }

                }

                else
                {




                    if (!RadarSettings.isInMobEnchant(mobOne.enchantmentLevel))
                    {
                        continue;
                    }

                   

                    if (Properties.Settings.Default.mobOtherSetting == true && mobOne.type == 2)
                    {



                    }
                    else
                    {
                        if (!RadarSettings.isInMobsTiers(mobOne.tier))
                        {

                            continue;
                        }

               
                    }
                    if (!RadarSettings.isInMobTypes(mobOne.type))
                    {

                        continue;
                    }
              
                }
             
    
                
                var currentDirectory = System.IO.Directory.GetCurrentDirectory();
                hX = -1 * mobOne.posX + lpX;
                hY = mobOne.posY - lpY;

                Point mobPosPoint = transformationMatrix.Transform(new Point(hX, hY));


                if (CanvasMobItems.mobs.ContainsKey(mobOne.id))
                {
                    if(CanvasMobItems.mobs[mobOne.id].normal!=null)
                    {
                        Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].normal, mobPosPoint.X);
                        Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].normal, mobPosPoint.Y);
                        if (CanvasMobItems.mobs[mobOne.id].enchantment != null)
                        {
                            Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].enchantment, mobPosPoint.X - 2);
                            Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].enchantment, mobPosPoint.Y - 2);
                        }

                    }



                    else if(CanvasMobItems.mobs[mobOne.id].hideImageView!=null)
                    {
                        Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].hideImageView, mobPosPoint.X -sizeIcon/2);
                        Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].hideImageView, mobPosPoint.Y - sizeIcon/2);

                    }

                    else if (CanvasMobItems.mobs[mobOne.id].harvestImage != null)
                    {
                        Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].harvestImage, mobPosPoint.X - sizeIcon / 2);
                        Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].harvestImage, mobPosPoint.Y - sizeIcon / 2);

                    }
                    else if (CanvasMobItems.mobs[mobOne.id].bossImage != null)
                    {
                        Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].bossImage, mobPosPoint.X - sizeIcon / 2);
                        Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].bossImage, mobPosPoint.Y - sizeIcon / 2);

                    }
                    else if (CanvasMobItems.mobs[mobOne.id].droneImage != null)
                    {
                        Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].droneImage, mobPosPoint.X - sizeIcon / 2);
                        Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].droneImage, mobPosPoint.Y - sizeIcon / 2);

                    }

                }
                else
                {


                    MobDrawingItem mobDrawingItem = new MobDrawingItem();
                    CanvasMobItems.mobs.Add(mobOne.id, mobDrawingItem);
                    if(mobOne.type ==1)
                    {


                        BitmapImage img = img = Load.imageResources["hide_" + mobOne.tier + "_" + mobOne.enchantmentLevel];

                 
                        Image BodyImage = new Image
                        {
                            Width = 40,
                            Height = 40,
                            Source = img
                        };
                        Canvas.SetLeft(BodyImage, mobPosPoint.X - sizeIcon / 2);
                        Canvas.SetTop(BodyImage, mobPosPoint.Y - sizeIcon / 2);
                        canva.Children.Add(BodyImage);
                        mobDrawingItem.hideImageView = BodyImage;




                 
                    }

                    else  if (mobOne.type == 0)
                    {
                        string name = mobOne.name;

                        name = name.ToLower();


                 
                        BitmapImage img = null;
                        if (name.Contains("fiber"))
                        {

                            img = Load.imageResources["fiber_" + mobOne.tier + "_" + mobOne.enchantmentLevel];
                        }
                        else if (name.Contains("wood"))
                        {

                            img = Load.imageResources["Logs_" + mobOne.tier + "_" + mobOne.enchantmentLevel];
                

                        }
                        else if (name.Contains("ore"))
                        {

                            img = Load.imageResources["ore_" + mobOne.tier + "_" + mobOne.enchantmentLevel];

                        }
                        else
                        {

                            img = Load.imageResources["rock_" + mobOne.tier + "_" + mobOne.enchantmentLevel];

                        }
                        Image BodyImage = new Image
                        {
                            Width = sizeIcon,
                            Height = sizeIcon,
                            Source = img
                        };

                        mobDrawingItem.harvestImage = BodyImage;

                        Canvas.SetLeft(BodyImage, mobPosPoint.X - sizeIcon / 2);
                        Canvas.SetTop(BodyImage, mobPosPoint.Y - sizeIcon / 2);
                        canva.Children.Add(BodyImage);
   

                    }

                    else if(mobOne.type==3)
                    {
                        string name = mobOne.name;

                        name = name.ToLower();




                        BitmapImage img = null;
                        img = Load.imageResources[name];

                        Image BodyImage = new Image
                        {
                            Width = 65,
                            Height = 65,
                            Source = img
                        };

                        mobDrawingItem.bossImage = BodyImage;

                        Canvas.SetLeft(BodyImage, mobPosPoint.X - sizeIcon / 2);
                        Canvas.SetTop(BodyImage, mobPosPoint.Y - sizeIcon / 2);
                        canva.Children.Add(BodyImage);
                    }

                    else if(mobOne.type ==4)
                    {

                        string name = mobOne.name;

                        name = name.ToLower();




                        BitmapImage img = null;
                        img = Load.imageResources["droneicon"];

                        Image BodyImage = new Image
                        {
                            Width = 65,
                            Height = 65,
                            Source = img
                        };

                        mobDrawingItem.droneImage = BodyImage;

                        Canvas.SetLeft(BodyImage, mobPosPoint.X - sizeIcon / 2);
                        Canvas.SetTop(BodyImage, mobPosPoint.Y - sizeIcon / 2);
                        canva.Children.Add(BodyImage);

                    }
                    else 
                    {




                        Ellipse circleEnemyPlayer;
                        if (mobOne.enchantmentLevel > 0)
                        {

                            circleEnemyPlayer = new Ellipse()
                            {
                                Width = 20,
                                Height = 20,
                                Fill = StaticBrushes.mobEnchant[mobOne.enchantmentLevel],

                            };

                            Canvas.SetLeft(circleEnemyPlayer, mobPosPoint.X - 2);
                            Canvas.SetTop(circleEnemyPlayer, mobPosPoint.Y - 2);
                            canva.Children.Add(circleEnemyPlayer);

                            CanvasMobItems.mobs[mobOne.id].enchantment = circleEnemyPlayer;

                        }


                        circleEnemyPlayer = new Ellipse()
                        {
                            Width = 16,
                            Height = 16,
                            Fill = StaticBrushes.radarMob,

                        };
                        mobDrawingItem.normal = circleEnemyPlayer;
                        CanvasMobItems.mobs[mobOne.id].normal = circleEnemyPlayer;
                        Canvas.SetLeft(circleEnemyPlayer, mobPosPoint.X);
                        Canvas.SetTop(circleEnemyPlayer, mobPosPoint.Y);
                        canva.Children.Add(circleEnemyPlayer);

              
                    }

    




                }

                
                if(mobOne.exp==0)
                {
                    continue;
                }
                if(Properties.Settings.Default.devModeSetting)
                {


                    if (!canva.Children.Contains(CanvasMobItems.mobs[mobOne.id].devModeTextBlock))
                    {


                        TextBlock textBlock = new TextBlock();

                   
                        textBlock.Text = "(" + (mobOne.typeId) + ")" ;
                        textBlock.FontSize = 13;



                        textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                        textBlock.Arrange(new Rect(textBlock.DesiredSize));
                        textBlock.Foreground = StaticBrushes.white;

                        Canvas.SetLeft(textBlock, mobPosPoint.X - textBlock.ActualWidth / 2 + 8);
                        Canvas.SetTop(textBlock, mobPosPoint.Y - sizeIcon + sizeIcon / 2 - 4);
                        canva.Children.Add(textBlock);


                        CanvasMobItems.mobs[mobOne.id].devModeTextBlock = textBlock;



                    }
                    else
                    {
                        // CanvasHarvestableItemobOne.harvestableItems[mobOne.id].TextBlock.Text = mobOne.typeId.ToString();
                        Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].devModeTextBlock, mobPosPoint.X - CanvasMobItems.mobs[mobOne.id].devModeTextBlock.ActualWidth / 2 + 8);
                        Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].devModeTextBlock, mobPosPoint.Y - sizeIcon + sizeIcon / 2 - 4);



                    }
                }


                if (Properties.Settings.Default.showExpSetting)
                {


                    if (!canva.Children.Contains(CanvasMobItems.mobs[mobOne.id].TextBlock))
                    {


                        TextBlock textBlock = new TextBlock();

                        textBlock.Text = mobOne.exp.ToString();
                        textBlock.FontSize = 13;



                        textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                        textBlock.Arrange(new Rect(textBlock.DesiredSize));
                        textBlock.Foreground = StaticBrushes.yellow;

                        Canvas.SetLeft(textBlock, mobPosPoint.X - textBlock.ActualWidth / 2 + 8);
                        Canvas.SetTop(textBlock, mobPosPoint.Y + sizeIcon - sizeIcon / 2 - 4);
                        canva.Children.Add(textBlock);


                        CanvasMobItems.mobs[mobOne.id].TextBlock = textBlock;



                    }
                    else
                    {
                        // CanvasHarvestableItemobOne.harvestableItems[mobOne.id].TextBlock.Text = mobOne.typeId.ToString();
                        Canvas.SetLeft(CanvasMobItems.mobs[mobOne.id].TextBlock, mobPosPoint.X - CanvasMobItems.mobs[mobOne.id].TextBlock.ActualWidth / 2 + 8);
                        Canvas.SetTop(CanvasMobItems.mobs[mobOne.id].TextBlock, mobPosPoint.Y + sizeIcon - sizeIcon / 2 - 4);



                    }
                }
                
            }
        }

        internal void invalidateDevMode()
        {
            if (!Properties.Settings.Default.devModeSetting)
            {

                mobsHandler.mobsList.ForEach(x =>
                {



                    if (CanvasMobItems.mobs.ContainsKey(x.id))
                    {


                        canva.Children.Remove(CanvasMobItems.mobs[x.id].devModeTextBlock);



                    }

                });
            }
        }

        internal void invalidateExp()
        {
            if(!Properties.Settings.Default.showExpSetting)
            {

                    mobsHandler.mobsList.ForEach(x =>
                    {

                    

                            if (CanvasMobItems.mobs.ContainsKey(x.id))
                            {


                                canva.Children.Remove(CanvasMobItems.mobs[x.id].TextBlock);
        


                            }
                        
                    });
            }
        }

        public void invalidateEnchants()
        {

            foreach (KeyValuePair<int, bool> entry in RadarSettings.mobsEnchant)
            {

                if (!entry.Value)
                {


                    mobsHandler.mobsList.ForEach(x =>
                    {

                        if (entry.Key == x.enchantmentLevel)
                        {


                            if (CanvasMobItems.mobs.ContainsKey(x.id))
                            {



                                canva.Children.Remove(CanvasMobItems.mobs[x.id].normal);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].enchantment);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].hideImageView);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].harvestImage);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].devModeTextBlock);

                                canva.Children.Remove(CanvasMobItems.mobs[x.id].TextBlock);
                                CanvasMobItems.mobs.Remove(x.id);


                            }
                        }
                    });

                }
            }




        }

        internal void invalidateTiers()
        {
            foreach (KeyValuePair<int, bool> entry in RadarSettings.mobsTiers)
            {

                if (!entry.Value)
                {


                    mobsHandler.mobsList.ForEach(x =>
                    {

                        if (entry.Key == x.tier)
                        {


                            if (CanvasMobItems.mobs.ContainsKey(x.id))
                            {


                                canva.Children.Remove(CanvasMobItems.mobs[x.id].normal);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].enchantment);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].hideImageView);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].harvestImage);

                                canva.Children.Remove(CanvasMobItems.mobs[x.id].devModeTextBlock);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].TextBlock);
                                CanvasMobItems.mobs.Remove(x.id);


                            }
                        }
                    });

                }
            }
        }

        internal void invalidateDrones()
        {

            if (!Properties.Settings.Default.avalonDronesSetting)
            {


                mobsHandler.mobsList.ForEach(x =>
                {

                    if (x.type == 4)
                    {


                        if (CanvasMobItems.mobs.ContainsKey(x.id))
                        {



                            canva.Children.Remove(CanvasMobItems.mobs[x.id].normal);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].enchantment);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].hideImageView);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].harvestImage);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].TextBlock);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].bossImage);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].droneImage);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].devModeTextBlock);
                            CanvasMobItems.mobs.Remove(x.id);


                        }
                    }
                });

            }
        }

        internal void invalidateOtherBosses()
        {

            if (!Properties.Settings.Default.otherBossesSetting)
            {


                mobsHandler.mobsList.ForEach(x =>
                {

                    if ( x.type == 3)
                    {


                        if (CanvasMobItems.mobs.ContainsKey(x.id))
                        {



                            canva.Children.Remove(CanvasMobItems.mobs[x.id].normal);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].enchantment);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].hideImageView);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].harvestImage);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].TextBlock);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].bossImage);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].droneImage);
                            canva.Children.Remove(CanvasMobItems.mobs[x.id].devModeTextBlock);
                            CanvasMobItems.mobs.Remove(x.id);


                        }
                    }
                });

            }
        }

        internal void invalidateTypes()
        {
            foreach (KeyValuePair<int, bool> entry in RadarSettings.mobsType)
            {

                if (!entry.Value)
                {


                    mobsHandler.mobsList.ForEach(x =>
                    {

                        if (entry.Key == x.type)
                        {


                            if (CanvasMobItems.mobs.ContainsKey(x.id))
                            {



                                canva.Children.Remove(CanvasMobItems.mobs[x.id].normal);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].enchantment);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].hideImageView);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].harvestImage);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].TextBlock);

                                canva.Children.Remove(CanvasMobItems.mobs[x.id].devModeTextBlock);
                                canva.Children.Remove(CanvasMobItems.mobs[x.id].TextBlock);
                                CanvasMobItems.mobs.Remove(x.id);


                            }
                        }
                    });

                }
            }
        }
    }
}
