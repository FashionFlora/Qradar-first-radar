using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace LogicLyric.CanvasDrawings
{
    public class PlayerDrawingItem
    {


  

        public TextBlock playerTextBlock = null;
        public TextBlock healthTextBlock = null;
        public int[] itemsImagesIds = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Image[] itemsImages = new Image[10] { new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image() };

    }
}
