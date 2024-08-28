using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
namespace LogicLyric.CanvasItems
{
    public class HarvestableDrawingItem
    {



        public Image ImageView;


        public Single posX;
        public Single posY;



        public TextBlock TextBlock;


        public ImageSource ImageSourceView { get; internal set; }
    }
}