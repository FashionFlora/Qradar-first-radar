using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace LogicLyric.CanvasDrawings
{
    public class EnemyPlayerDrawingItem
    {


        public int health;

        public TextBlock TextBlock;
        public Ellipse Ellipse;

        public TextBlock mounted;

        public Rectangle borderHealthRectangle;
        public Rectangle healthRectangle;
        public TextBlock helathTextBlock;
        public TextBlock guildTextBlock;
        public int id;

        public TextBlock playerItemTextBlock;

        public TextBlock distance;


        public TextBlock playerItemHealthTextBlock;
        public int[] itemsImagesIds = new int[10];
        public Image[] itemsImages= new Image[] {new Image(), new Image() , new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image() };
 
    }
}
