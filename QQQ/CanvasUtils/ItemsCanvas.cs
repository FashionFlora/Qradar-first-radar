using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows;



using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Vector;
using Image = System.Windows.Controls.Image;
using Point = System.Windows.Point;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Globalization;
using Brushes = System.Windows.Media.Brushes;
using LogicLyric;
using LogicLyric.Utils;

namespace LogicLyric.CanvasUtils
{
    class ItemCanvas : Canvas
    {



        PlayerHandler playerHandler;


    
        public float maxHeight = 0;

        PlayerItemHandler itemHandler;



        public void init( PlayerHandler playerHandler , PlayerItemHandler itemHandler)
        {
            this.playerHandler = playerHandler;
            this.itemHandler = itemHandler;
        }


        double lpX;
        double lpY;
        string currentDirectory = System.IO.Directory.GetCurrentDirectory();

        int topTextX = 0;

        protected override void OnRender(DrawingContext dc)
        {

            float posY = 0;

            int size = Properties.Settings.Default.itemsSizeSetting;


            List<Player> players = null;
 


            lock (playerHandler.playersInRange)
            {
               players = playerHandler.playersInRange.ToList();
                lpX = playerHandler.localPlayerPosX();
                lpY = playerHandler.localPlayerPosY();
            }


               foreach (Player p in players)
                {



                double distance = Math.Round((double)Math.Sqrt(Math.Pow(p.posX - lpX, 2) + Math.Pow(p.posY - lpY, 2)), 1);



                
                if(distance >90)
                {
                    continue;

                }
                



           


                int total = (int)(posY + 20 + size);
                    if (total > this.Height)
                    {
                        break;
                    }




                    FormattedText formattedText = new FormattedText(
                        p.nickname,
                        CultureInfo.GetCultureInfo("en-us"),
                        FlowDirection.LeftToRight,
                        new Typeface("Verdana"),
                        32,
                        Brushes.White);





                    FormattedText formattedTextHealth = new FormattedText(
                     p.currentHealth.ToString() + "/" + p.initialHealth.ToString(),
                     CultureInfo.GetCultureInfo("en-us"),
                     FlowDirection.LeftToRight,
                     new Typeface("Verdana"),
                     32,
                     Brushes.Red);


                    formattedText.SetFontSize(15);
                    formattedTextHealth.SetFontSize(15);
                    dc.DrawText(formattedText, new Point(0, posY));
                    dc.DrawText(formattedTextHealth, new Point(formattedText.Width + 10, posY));


                topTextX += (int)formattedText.Width + 10  + (int)formattedTextHealth.Width + 15;

                    posY += 20;




                    if (p.items == null)
                    {

                        continue;
                    }

                    float posX = 0;

                     string devModeString = "";
                    foreach (int item in p.items.ToArray())
                    {
                 

                        string itemName = null;
                        if (itemHandler.Items.ContainsKey(item))
                        {
                            itemName = itemHandler.Items[item];
                        }
                        if (itemName == null)
                        {
                            continue;
                        }



                    if (Properties.Settings.Default.showPlayerItemsDevModeSetting)
                    {

                        devModeString += item + " ";
                    }

                    //    BitmapImage  bmp = new BitmapImage(new Uri(currentDirectory + "/Items/" + itemName + ".png"));
                    try
                    {

                        ImageSource image = new BitmapImage(new Uri(currentDirectory + "/Items/" + itemName + ".png"));
                        Rect rect = new Rect(posX, posY, size, size);
                        dc.DrawImage(image, rect);
                        posX += size;
                    }
                    catch(Exception e)
                    {
                        continue;
                    }
            
                    }

                    if(devModeString.Length>0)
                {


                    FormattedText formattedTextA = new FormattedText(
devModeString,
CultureInfo.GetCultureInfo("en-us"),
FlowDirection.LeftToRight,
new Typeface("Verdana"),
32,
Brushes.White);

                    formattedTextA.SetFontSize(15);
                    dc.DrawText(formattedTextA, new Point(topTextX, posY-20));
                }

                topTextX = 0;





            posY += size;













                }
            
            

            





        }
    }
}
