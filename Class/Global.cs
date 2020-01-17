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
        public static Conf Conf = new Conf();
        public static Manor Manor;
        public static int imgWidth;
        public static int imgHeight;
        public static List<Direction> AllDirections = new List<Direction>()
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West
        };

        public static ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            ImageSource newSource = Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return newSource;
        }

        public static List<Direction> Randomize()
        {
            List<Direction> list = new List<Direction>(AllDirections);
            Random r = new Random();
            for(int n = 0; n < list.Count; n++)
            {
                int i = r.Next(list.Count);

                Direction tmp = list[n];
                list[n] = list[i];
                list[i] = tmp;
            }

            return list;
        }
    }
}
