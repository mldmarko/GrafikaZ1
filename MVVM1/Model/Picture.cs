using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVVM1.Model
{
    public class Picture
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }


        public static BitmapImage ConvertPathToImage(string imagePath)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(imagePath, UriKind.Absolute);
            image.EndInit();
            return image;
        }
    }
}
