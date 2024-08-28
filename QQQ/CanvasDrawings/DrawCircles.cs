using LogicLyric.CanvasItems;
using LogicLyric.MVM.View;
using System;
using System.Collections.Generic;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LogicLyric.CanvasDrawings
{
    class DrawCircles
    {

        Ellipse circleBig = new Ellipse()
        {
            Width = 500,
            Height = 500,
            Stroke = StaticBrushes.radarColor,
            StrokeThickness = 3
        };

        Rectangle rectangleBig = new Rectangle()
        {
            Width = 500,
            Height = 500,
            Stroke = StaticBrushes.radarColor,
            StrokeThickness = 3
        };
        Rectangle rectangleMiddle = new Rectangle()
        {
            Width = 340,
            Height = 340,
            Stroke = StaticBrushes.radarColor,
            StrokeThickness = 3
        };
        Rectangle squareSmaller = new Rectangle()
        {
            Width = 160,
            Height = 160,
            Stroke = StaticBrushes.radarColor,
            StrokeThickness = 3
        };
        Ellipse circleMid = new Ellipse()
        {
            Width = 340,
            Height = 340,
            Stroke = StaticBrushes.radarColor,
            StrokeThickness = 3
        };

        Ellipse circleSmaller = new Ellipse()
        {
            Width = 160,
            Height = 160,
            Stroke = StaticBrushes.radarColor,
            StrokeThickness = 3
        };
        Ellipse circlePlayer = new Ellipse()
        {
            Width = 20,
            Height = 20,
            Fill = StaticBrushes.grayColor

        };

        Ellipse circleSmallerPlayer = new Ellipse()
        {
            Width = 16,
            Height = 16,
            Fill = StaticBrushes.smallerPlayerBrush

        };

        Canvas canva;

        public DrawCircles(Canvas canva)
        {

            this.canva = canva;

        }


        public void invalidate( double width, double height)
        {


            LinearGradientBrush radarColor = new LinearGradientBrush();
            radarColor.StartPoint = new Point(0, 0);
            radarColor.EndPoint = new Point(1, 1);

            SolidColorBrush colorFirst = new SolidColorBrush((Color)ColorConverter.ConvertFromString(("#6D2FFF")));

            this.circleBig.Width = width;
            this.circleBig.Height = height;

            this.rectangleBig.Width = width;
            this.rectangleBig.Height = height;

            this.circleMid.Width = width * 0.65;
            this.circleMid.Height = width * 0.65;


            this.rectangleMiddle.Width = width * 0.65;
            this.rectangleMiddle.Height = width * 0.65;

            this.circleSmaller.Width = width * 0.15;
            this.circleSmaller.Height = width * 0.15;

            this.squareSmaller.Width = width * 0.15;
            this.squareSmaller.Height = width * 0.15;


            GradientStop stop = new GradientStop();
            stop.Color = (Color)ColorConverter.ConvertFromString("#6D2FFF");
            stop.Offset = 0.0;
            radarColor.GradientStops.Add(stop);

            GradientStop stop1 = new GradientStop();
            stop1.Color = (Color)ColorConverter.ConvertFromString("#FB539B");
            stop1.Offset = 0.5;
            radarColor.GradientStops.Add(stop1);


            GradientStop stop2 = new GradientStop();
            stop2.Color = (Color)ColorConverter.ConvertFromString("#836EFB");
            stop2.Offset = 1f;
            radarColor.GradientStops.Add(stop2);



            StaticBrushes.radarColorGradient = radarColor;


            if(Properties.Settings.Default.radarColorsSetting)
            {

                circleBig.Stroke = radarColor;
                circleMid.Stroke = radarColor;
                circleSmaller.Stroke = radarColor;


                rectangleBig.Stroke = radarColor;
                rectangleMiddle.Stroke = radarColor;
                squareSmaller.Stroke = radarColor;

                circlePlayer.Fill = radarColor;
                circleSmallerPlayer.Fill = colorFirst;

            }
            else
            {


                circleBig.Stroke = StaticBrushes.radarColor;
                circleMid.Stroke = StaticBrushes.radarColor;
                circleSmaller.Stroke = StaticBrushes.radarColor;


                rectangleBig.Stroke =  StaticBrushes.radarColor;
                rectangleMiddle.Stroke =  StaticBrushes.radarColor;
                squareSmaller.Stroke  = StaticBrushes.radarColor;

                circlePlayer.Fill = StaticBrushes.radarColor;
                circleSmallerPlayer.Fill = StaticBrushes.smallerPlayerBrush;
            }



            if (!canva.Children.Contains(circleSmaller) && !canva.Children.Contains(circlePlayer))
            {

                canva.Children.Add(circlePlayer);

                Canvas.SetLeft(circlePlayer, width / 2 - 10);
                Canvas.SetTop(circlePlayer, width / 2 - 10);

         


                canva.Children.Add(circleSmallerPlayer);

                Canvas.SetLeft(circleSmallerPlayer, width / 2 - 8);
                Canvas.SetTop(circleSmallerPlayer, width / 2 - 8);
            }
            else
            {
                Canvas.SetLeft(circlePlayer, width / 2 - 10);
                Canvas.SetTop(circlePlayer, width / 2 - 10);

                Canvas.SetLeft(circleSmallerPlayer, width / 2 - 8);
                Canvas.SetTop(circleSmallerPlayer, width / 2 - 8);
            }

            if (Properties.Settings.Default.drawBigCircleSetting)
            {

        
                if (!canva.Children.Contains(circleBig))
                {

                    canva.Children.Add(circleBig);


                }
  
            }
            else
            {

                


                if (canva.Children.Contains(circleBig))
                {
                    canva.Children.Remove(circleBig);
                }

            }




            if (Properties.Settings.Default.drawMiddleCircleSetting)
            {

      
                if (!canva.Children.Contains(circleMid))
                {

                    Canvas.SetLeft(circleMid, width / 2 - circleMid.Width / 2);
                    Canvas.SetTop(circleMid, height / 2 - circleMid.Height / 2);
                    canva.Children.Add(circleMid);


                }
                else
                {
                    Canvas.SetLeft(circleMid, width / 2 - circleMid.Width / 2);
                    Canvas.SetTop(circleMid, height / 2 - circleMid.Height / 2);
                }

            }
            else
            {

                if (canva.Children.Contains(circleMid))
                {
                    canva.Children.Remove(circleMid);
                }

            }

            if (Properties.Settings.Default.drawSmallerCircleSetting)
            {


                if (!canva.Children.Contains(circleSmaller))
                {


                    Canvas.SetLeft(circleSmaller, width / 2 - circleSmaller.Width / 2);
                    Canvas.SetTop(circleSmaller, height / 2 - circleSmaller.Height / 2);
                    canva.Children.Add(circleSmaller);


                }
                else
                {
                    Canvas.SetLeft(circleSmaller, width / 2 - circleSmaller.Width /2);
                    Canvas.SetTop(circleSmaller, height / 2 - circleSmaller.Height / 2);
                }

            }
            else
            {

                if (canva.Children.Contains(circleSmaller))
                {
                    canva.Children.Remove(circleSmaller);
                }

            }



            if (Properties.Settings.Default.drawBigSquareSetting)
            {


                if (!canva.Children.Contains(rectangleBig))
                {

                    canva.Children.Add(rectangleBig);


                }

            }
            else
            {

                if (canva.Children.Contains(rectangleBig))
                {
                    canva.Children.Remove(rectangleBig);
                }

            }



            if (Properties.Settings.Default.drawMiddleSquareSetting)
            {


                if (!canva.Children.Contains(rectangleMiddle))
                {


                    Canvas.SetLeft(rectangleMiddle, width / 2 - rectangleMiddle.Height/2) ;
                    Canvas.SetTop(rectangleMiddle, height / 2 - rectangleMiddle.Height/2);

                    canva.Children.Add(rectangleMiddle);


                }
                else
                {
                    Canvas.SetLeft(rectangleMiddle, width / 2 - rectangleMiddle.Height / 2);
                    Canvas.SetTop(rectangleMiddle, height / 2 - rectangleMiddle.Height / 2);
                }

            }
            else
            {

                if (canva.Children.Contains(rectangleMiddle))
                {
                    canva.Children.Remove(rectangleMiddle);
                }

            }




            if (Properties.Settings.Default.drawSmallerSquareSetting)
            {


                if (!canva.Children.Contains(squareSmaller))
                {


                    Canvas.SetLeft(squareSmaller, width / 2 - squareSmaller.Height / 2);
                    Canvas.SetTop(squareSmaller, height / 2 - squareSmaller.Height / 2);
                    canva.Children.Add(squareSmaller);


                }
                else
                {
                    Canvas.SetLeft(squareSmaller, width / 2 - squareSmaller.Height / 2);
                    Canvas.SetTop(squareSmaller, height / 2 - squareSmaller.Height / 2);
                }

            }
            else
            {

                if (canva.Children.Contains(squareSmaller))
                {
                    canva.Children.Remove(squareSmaller);
                }

            }









        }
    }
}
