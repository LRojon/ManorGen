using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ManorGen.Class.Enum;
using Color = System.Drawing.Color;

namespace ManorGen.Class
{
    class Global
    {
        public static Manor Manor = new Manor();
        public static Conf Conf = new Conf();
        public static int imgWidth;
        public static int imgHeight;

        public static ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            ImageSource newSource = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return newSource;
        }
    }
}
