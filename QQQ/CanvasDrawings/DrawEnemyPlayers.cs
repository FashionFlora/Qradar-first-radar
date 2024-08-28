using LogicLyric;
using LogicLyric.Interfaces;
using LogicLyric.CanvasItems;
using LogicLyric.MVM.View;
using LogicLyric.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Vector;
using Image = System.Windows.Controls.Image;
using Point = System.Windows.Point;
using Rectangle = System.Windows.Shapes.Rectangle;
using System.Threading.Tasks;

namespace LogicLyric.CanvasDrawings
{
    public class DrawEnemyPlayers : INewEnemyPlayer
    {


        PlayerHandler playerHandler;

        private Single hX;
        private Single hY;
        PlayerItemHandler playerItemHandler;
        EnemyPlayerDrawingItem enemyPlayerDrawingItem;
        Canvas canva;

        ItemsView itemsView = null;


        public ItemsView getItemView()
        {
            return this.itemsView;

        }

        public void setItemsWindoWidth()
        {

            if (itemsView != null)
            {
                itemsView.Width = Properties.Settings.Default.itemsWidthSetting;
            }


        }

        public void setItemsWindowHeight()
        {


            if (itemsView != null)
            {
                itemsView.Height = Properties.Settings.Default.itemsHeightSetting;
            }
        }

        public void setItemsWindowTranslationX()
        {

            if (itemsView != null)
            {
                itemsView.Left = Properties.Settings.Default.translationItemsXSetting;
            }
        }

        public void setItemsWindowTranslationY()
        {
            if (itemsView != null)
            {
                itemsView.Top = Properties.Settings.Default.translationItemsYSetting;
            }
        }

        public void closeItemsWindow()
        {

            itemsView.Close();
            itemsView = null;

        }

        public void initItems()
        {
            itemsView = new ItemsView();


            itemsView.ShowInTaskbar = false;



            itemsView.Left = Properties.Settings.Default.translationItemsXSetting;
            itemsView.Top = Properties.Settings.Default.translationItemsYSetting;

            if (Properties.Settings.Default.itemsWidthSetting != 0)
            {
                itemsView.Height = Properties.Settings.Default.itemsWidthSetting;
            }

            if (Properties.Settings.Default.itemsHeightSetting != 0)
            {
                itemsView.Height = Properties.Settings.Default.itemsHeightSetting;
            }




            itemsView.canvasItems.init(playerHandler, playerItemHandler);
            itemsView.initThread();
            itemsView.Show();

        }


        public DrawEnemyPlayers() { }
        public DrawEnemyPlayers(PlayerHandler playerHandler, Canvas canva, PlayerItemHandler playerItemHandler)
        {

            this.playerHandler = playerHandler;
            this.canva = canva;
            this.playerItemHandler = playerItemHandler;

            if (Properties.Settings.Default.showPlayerItemsSetting)
            {
                initItems();
            }














        }





        public void clearAll()
        {



            foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
            {



                canva.Children.Remove(entry.Value.Ellipse);

                canva.Children.Remove(entry.Value.TextBlock);

                canva.Children.Remove(entry.Value.healthRectangle);
                canva.Children.Remove(entry.Value.borderHealthRectangle);
                canva.Children.Remove(entry.Value.helathTextBlock);
                canva.Children.Remove(entry.Value.mounted);
                canva.Children.Remove(entry.Value.distance);
                canva.Children.Remove(entry.Value.guildTextBlock);






            }
            CanvasEnemyPlayerItems.enemyPlayers.Clear();


        }





        internal void invalidateDistance()
        {
            if (!Properties.Settings.Default.showPlayerDistanceSetting)
            {


                foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
                {
                    canva.Children.Remove(entry.Value.distance);

                }

            }
        }







        public void invalidate(Single lpX, Single lpY, Matrix transformationMatrix)
        {








            if (playerHandler.playersInRange.Count > 60)
            {
                if (itemsView != null)
                {
                    itemsView.show_items = false;
                }

                if (CanvasEnemyPlayerItems.enemyPlayers.Count() > 0)
                {



                    clearAll();


                }


                return;

            }
            else
            {
                if (itemsView != null)
                {
                    itemsView.show_items = true;
                }
            }










            if (Properties.Settings.Default.showPlayerSetting)
            {




                //  int itemSize = Properties.Settings.Default.itemsSize; 





                foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
                {

                    if (!playerHandler.playersInRange.Any(x => (x.id == entry.Key)))
                    {


                        //  playerItemsView.canva.Children.Remove(entry.Value.playerItemHealthTextBlock);
                        //  playerItemsView.canva.Children.Remove(entry.Value.playerItemTextBlock);


                        canva.Children.Remove(entry.Value.Ellipse);

                        canva.Children.Remove(entry.Value.TextBlock);

                        canva.Children.Remove(entry.Value.healthRectangle);
                        canva.Children.Remove(entry.Value.borderHealthRectangle);
                        canva.Children.Remove(entry.Value.helathTextBlock);
                        canva.Children.Remove(entry.Value.mounted);
                        canva.Children.Remove(entry.Value.distance);
                        canva.Children.Remove(entry.Value.guildTextBlock);

                        /*

                        foreach (Image img in entry.Value.itemsImages)
                        {
                            playerItemsView.canva.Children.Remove(img);

                        }
                        */



                        CanvasEnemyPlayerItems.enemyPlayers.Remove(entry.Key);

                    }


                }



                foreach (Player playerOne in playerHandler.playersInRange)
                {




                    hX = -1 * playerOne.posX + lpX;
                    hY = playerOne.posY - lpY;

                    //             Console.WriteLine(playerOne.guildName);



                    Point enemyPosPoint = transformationMatrix.Transform(new Point(hX, hY));


                    if (CanvasEnemyPlayerItems.enemyPlayers.ContainsKey(playerOne.id))
                    {



                        //Canvas.BeginAnimation(OpacityProperty, fadeInOutAnimation);
                        Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].Ellipse, enemyPosPoint.X);
                        Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].Ellipse, enemyPosPoint.Y);

                        //         Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].Ellipse, enemyPosPoint.X ,  enemyPosPoint.Y);

                    }
                    else
                    {


                        enemyPlayerDrawingItem = new EnemyPlayerDrawingItem();

                        Ellipse circleEnemyPlayer = new Ellipse()
                        {
                            Width = 16,
                            Height = 16,
                            Fill = StaticBrushes.radarColor,

                        };
                        //  circleEnemyPlayer.CacheMode = new BitmapCache();

                        if (Properties.Settings.Default.radarColorsSetting)
                        {
                            circleEnemyPlayer.Fill = StaticBrushes.radarGuiPlayers;

                        }

                        enemyPlayerDrawingItem.Ellipse = circleEnemyPlayer;
                        CanvasEnemyPlayerItems.enemyPlayers.Add(playerOne.id, enemyPlayerDrawingItem);
                        Canvas.SetLeft(circleEnemyPlayer, enemyPosPoint.X);
                        Canvas.SetTop(circleEnemyPlayer, enemyPosPoint.Y);
                        //  Utils.MoveTo(CanvasEnemyPlayerItems.enemyPlayers[p.id].Ellipse, enemyPosPoint.X, enemyPosPoint.Y);
                        canva.Children.Add(circleEnemyPlayer);


                    }

                    if (Properties.Settings.Default.showPlayerDistanceSetting)
                    {



                        double distance = Math.Round((double)Math.Sqrt(Math.Pow(playerOne.posX - lpX, 2) + Math.Pow(playerOne.posY - lpY, 2)), 1);

                        if (!canva.Children.Contains(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].distance))
                        {

                            TextBlock textBlock = new TextBlock();



                            Math.Round(distance, 1);

                            textBlock.Text = distance.ToString() + "m";



                            textBlock.FontSize = 13;

                            textBlock.Foreground = StaticBrushes.white;

                            textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                            textBlock.Arrange(new Rect(textBlock.DesiredSize));
                            Canvas.SetLeft(textBlock, enemyPosPoint.X - textBlock.ActualWidth / 2 + 8);
                            Canvas.SetTop(textBlock, enemyPosPoint.Y - 19);
                            canva.Children.Add(textBlock);
                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].distance = textBlock;



                        }
                        else
                        {

                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].distance.Text = distance.ToString() + "m";


                            //   Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].Ellipse, enemyPosPoint.X, enemyPosPoint.Y);
                            Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].distance, enemyPosPoint.X - CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].distance.ActualWidth / 2 + 8);
                            Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].distance, enemyPosPoint.Y - 19);

                        }



                    }



                    if (Properties.Settings.Default.showNicknameSetting)
                    {



                        if (CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].TextBlock != null)
                        {
                            Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].TextBlock, enemyPosPoint.X - CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].TextBlock.ActualWidth / 2 + 8);
                            Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].TextBlock, enemyPosPoint.Y + 15);

                            //  Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].TextBlock, enemyPosPoint.X - CanvasEnemyPlayerItems.enemyPlayers[p.id].TextBlock.ActualWidth / 2 + 8, enemyPosPoint.Y + 15);
                        }
                        else
                        {

                            TextBlock textBlock = new TextBlock();
                            textBlock.Text = playerOne.nickname;
                            textBlock.FontSize = 13;

                            textBlock.Foreground = StaticBrushes.white;


                            textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                            textBlock.Arrange(new Rect(textBlock.DesiredSize));
                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].TextBlock = textBlock;
                            Canvas.SetLeft(textBlock, enemyPosPoint.X - textBlock.ActualWidth / 2 + 8);
                            Canvas.SetTop(textBlock, enemyPosPoint.Y + 15);
                            canva.Children.Add(textBlock);


                        }
                    }

                    if (Properties.Settings.Default.mountedSetting)
                    {


                        if (!canva.Children.Contains(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].mounted))
                        {

                            TextBlock textBlock = new TextBlock();
                            if (playerOne.mounted)
                            {
                                textBlock.Text = "M";
                            }
                            else
                            {
                                textBlock.Text = "";
                            }

                            textBlock.FontSize = 13;

                            textBlock.Foreground = StaticBrushes.white;

                            textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                            textBlock.Arrange(new Rect(textBlock.DesiredSize));
                            Canvas.SetLeft(textBlock, enemyPosPoint.X + 2);
                            Canvas.SetTop(textBlock, enemyPosPoint.Y - 2);
                            canva.Children.Add(textBlock);
                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].mounted = textBlock;



                        }
                        else
                        {

                            if (playerOne.mounted)
                            {
                                CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].mounted.Text = "M";
                            }
                            else
                            {
                                CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].mounted.Text = "";
                            }

                            Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].mounted, enemyPosPoint.X + 2);
                            Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].mounted, enemyPosPoint.Y - 2);
                            // Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].mounted, enemyPosPoint.X + 2, enemyPosPoint.Y - 2);
                        }

                    }



                    if (Properties.Settings.Default.showPlayerHealthSetting)
                    {
                        int width = 50;


                        if (!Properties.Settings.Default.showNicknameSetting)
                        {
                            enemyPosPoint.Y += 17;
                        }
                        else
                        {
                            enemyPosPoint.Y += 32;
                        }

                        float input_end = playerOne.initialHealth;
                        float input_start = 0;



                        float output_end = width;
                        float output_start = 0;
                        float input_range = input_end - input_start;
                        float output_range = output_end - output_start;


                        if (canva.Children.Contains(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].healthRectangle))
                        {




                            float output = (playerOne.currentHealth - input_start) * output_range / input_range + output_start;
                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].healthRectangle.Width = output;

                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].helathTextBlock.Text = playerOne.currentHealth.ToString();

                            Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].healthRectangle, enemyPosPoint.X - width / 2 + 8);
                            Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].healthRectangle, enemyPosPoint.Y);

                            //   Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].healthRectangle, enemyPosPoint.X - width / 2 + 8, enemyPosPoint.Y);

                            Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].borderHealthRectangle, enemyPosPoint.X - width / 2 + 8);
                            Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].borderHealthRectangle, enemyPosPoint.Y);

                            //  Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].borderHealthRectangle, enemyPosPoint.X - width / 2 + 8, enemyPosPoint.Y);


                            Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].helathTextBlock, enemyPosPoint.X - CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].helathTextBlock.ActualWidth / 2 + 8);
                            Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].helathTextBlock, enemyPosPoint.Y - 2);


                            //  Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].helathTextBlock, enemyPosPoint.X - CanvasEnemyPlayerItems.enemyPlayers[p.id].helathTextBlock.ActualWidth / 2 + 8, enemyPosPoint.Y - 2);

                        }
                        else
                        {


                            enemyPlayerDrawingItem = new EnemyPlayerDrawingItem();
                            Rectangle healthBorderRectangle = new Rectangle()
                            {
                                Width = 50,
                                Height = 17,
                                Stroke = StaticBrushes.radarMob,
                                StrokeThickness = 2

                            };
                            Rectangle healthRectangle = new Rectangle()
                            {
                                Width = 50,
                                Height = 17,
                                Fill = StaticBrushes.radarMob,

                            };



                            float output = (playerOne.currentHealth - input_start) * output_range / input_range + output_start;

                            healthRectangle.Width = output;


                            TextBlock textBlock = new TextBlock();
                            textBlock.Text = playerOne.currentHealth.ToString();
                            textBlock.FontSize = 13;
                            textBlock.Foreground = StaticBrushes.white;
                            textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                            textBlock.Arrange(new Rect(textBlock.DesiredSize));

                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].healthRectangle = healthRectangle;
                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].borderHealthRectangle = healthBorderRectangle;
                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].helathTextBlock = textBlock;


                            Canvas.SetLeft(healthBorderRectangle, enemyPosPoint.X - width / 2 + 8);
                            Canvas.SetTop(healthBorderRectangle, enemyPosPoint.Y);
                            canva.Children.Add(healthBorderRectangle);


                            Canvas.SetLeft(healthRectangle, enemyPosPoint.X - width / 2 + 8);
                            Canvas.SetTop(healthRectangle, enemyPosPoint.Y);
                            canva.Children.Add(healthRectangle);

                            Canvas.SetLeft(textBlock, enemyPosPoint.X - textBlock.ActualWidth / 2 + 8);
                            Canvas.SetTop(textBlock, enemyPosPoint.Y - 2);
                            canva.Children.Add(textBlock);


                        }








                    }


                    if (Properties.Settings.Default.showNicknameSetting && !Properties.Settings.Default.showPlayerHealthSetting)
                    {
                        enemyPosPoint.Y += 17;
                    }

                    if (Properties.Settings.Default.showGuildSetting)
                    {



                        if (CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].guildTextBlock != null)
                        {
                            Canvas.SetLeft(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].guildTextBlock, enemyPosPoint.X - CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].guildTextBlock.ActualWidth / 2 + 8);
                            Canvas.SetTop(CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].guildTextBlock, enemyPosPoint.Y + 15);

                            //  Utils.MoveToPlayers(CanvasEnemyPlayerItems.enemyPlayers[p.id].TextBlock, enemyPosPoint.X - CanvasEnemyPlayerItems.enemyPlayers[p.id].TextBlock.ActualWidth / 2 + 8, enemyPosPoint.Y + 15);
                        }
                        else
                        {

                            TextBlock textBlock = new TextBlock();
                            textBlock.Text = playerOne.guildName;
                            textBlock.FontSize = 13;

                            textBlock.Foreground = StaticBrushes.white;


                            textBlock.Measure(new System.Windows.Size(Double.PositiveInfinity, Double.PositiveInfinity));
                            textBlock.Arrange(new Rect(textBlock.DesiredSize));
                            CanvasEnemyPlayerItems.enemyPlayers[playerOne.id].guildTextBlock = textBlock;
                            Canvas.SetLeft(textBlock, enemyPosPoint.X - textBlock.ActualWidth / 2 + 8);
                            Canvas.SetTop(textBlock, enemyPosPoint.Y + 15);
                            canva.Children.Add(textBlock);


                        }
                    }




















                }






            }

        }

        internal void invalidateGuild()
        {
            if (!Properties.Settings.Default.showGuildSetting)
            {
                foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
                {



                    canva.Children.Remove(entry.Value.guildTextBlock);




                    entry.Value.guildTextBlock = null;

                }


            }
        }

        internal void invalidateCircles()
        {
            foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
            {


                if (Properties.Settings.Default.radarColorsSetting)
                {
                    entry.Value.Ellipse.Fill = StaticBrushes.radarColorGradient;
                }
                else
                {
                    entry.Value.Ellipse.Fill = StaticBrushes.radarColor;
                }


            }
        }



        public void invalidateItems()
        {





            if (Properties.Settings.Default.showPlayerItemsSetting)
            {


                initItems();




            }
            else

            {

                closeItemsWindow();

            }

        }

        public void invalidateMounted(bool value)
        {

            if (value == false)
            {




                foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
                {



                    canva.Children.Remove(entry.Value.mounted);




                    entry.Value.mounted = null;

                }

            }


        }

        public void invalidatePlayersNicknames()
        {

            if (!Properties.Settings.Default.showNicknameSetting)
            {




                foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
                {



                    canva.Children.Remove(entry.Value.TextBlock);

                    entry.Value.TextBlock = null;





                }

            }





        }


        public void invalidatePlayersHealth()
        {

            if (!Properties.Settings.Default.showPlayerHealthSetting)
            {





                foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
                {



                    canva.Children.Remove(entry.Value.helathTextBlock);

                    canva.Children.Remove(entry.Value.healthRectangle);
                    canva.Children.Remove(entry.Value.borderHealthRectangle);




                }

            }




        }

        public void invalidatePlayers()
        {

            if (!Properties.Settings.Default.showPlayersSetting)
            {

                clearAll();

            }

        }




        internal void invalidateHealth()
        {





            if (!Properties.Settings.Default.showPlayerHealthSetting)
            {

                foreach (KeyValuePair<int, EnemyPlayerDrawingItem> entry in CanvasEnemyPlayerItems.enemyPlayers)
                {
                    canva.Children.Remove(entry.Value.healthRectangle);
                    canva.Children.Remove(entry.Value.borderHealthRectangle);
                    canva.Children.Remove(entry.Value.helathTextBlock);
                }
            }



        }

        public void notify()
        {


            Task.Run(() => BeepOnSeparateThread()); ;
        }
        private void BeepOnSeparateThread()
        {
            Console.Beep();
        }
    }
}
