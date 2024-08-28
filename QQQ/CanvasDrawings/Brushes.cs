using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Media;

namespace LogicLyric.CanvasItems
{
    public static class StaticBrushes
    {
        public static SolidColorBrush radarColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#318CE7"));
        public static SolidColorBrush grayColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#808080"));
        public static LinearGradientBrush radarColorGradient;


        public static SolidColorBrush radarMob = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DC143C"));
        public static SolidColorBrush radarGuiPlayers  = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6D2FFF"));
        public static SolidColorBrush radarMobHarvest = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FAD02C"));
        public static SolidColorBrush[] mobEnchant = new SolidColorBrush[5] { new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C0C0C0")), new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00FF00")), new SolidColorBrush((Color)ColorConverter.ConvertFromString("#318CE7")), new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00FF")) , new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD700"))};
        public static SolidColorBrush smallerPlayerBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#034694"));
        public static SolidColorBrush yellow = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF00"));

        public static SolidColorBrush healthColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0000"));
        public static SolidColorBrush white = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
    }
}

