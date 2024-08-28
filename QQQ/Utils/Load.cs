using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
namespace LogicLyric.Utils
{
    class Load
    {



        public static Dictionary<string, BitmapImage> imageResources = new Dictionary<string, BitmapImage>();
        public Load()
        {


            

            var resourceSet = Properties.Resource1.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);

            foreach (System.Collections.DictionaryEntry entry in resourceSet)
            {
                if (entry.Value is System.Drawing.Bitmap)
                {
                    var bitmap = (System.Drawing.Bitmap)entry.Value;



                    using (MemoryStream memory = new MemoryStream())
                    {
                        bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                        memory.Position = 0;
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memory;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.EndInit();

                        imageResources.Add(entry.Key.ToString(), bitmapImage);
                    }
                }
            }

        }







    }
}
