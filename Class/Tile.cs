using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManorGen.Class.Enum;

namespace ManorGen.Class
{
    class Tile
    {
        private Door _door;
        private List<Wall> _walls;

        public Door Door { get => _door; set => _door = value; }
        public List<Wall> Walls { get => _walls; set => _walls = value; }

        public Bitmap GetTileImage()
        {
            double doorSize = .75;
            var bmp = new Bitmap(Global.Conf.Size, Global.Conf.Size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.LightSlateGray), 0, 0, Global.Conf.Size, Global.Conf.Size);
                foreach (Wall w in this.Walls)
                {
                    switch (w)
                    {
                        case Wall.North:
                            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Global.Conf.Size, Global.Conf.Size / 8);
                            break;
                        case Wall.East:
                            g.FillRectangle(new SolidBrush(Color.Black), Global.Conf.Size - Global.Conf.Size / 8, 0, Global.Conf.Size / 8, Global.Conf.Size);
                            break;
                        case Wall.South:
                            g.FillRectangle(new SolidBrush(Color.Black), 0, Global.Conf.Size - Global.Conf.Size / 8, Global.Conf.Size, Global.Conf.Size / 8);
                            break;
                        case Wall.West:
                            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Global.Conf.Size / 8, Global.Conf.Size);
                            break;
                    }
                }
                switch (this.Door)
                {
                    case Door.North:
                        g.FillRectangle(new SolidBrush(Color.Brown), (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), 0, (int)(Global.Conf.Size * doorSize), Global.Conf.Size / 8);
                        break;
                    case Door.East:
                        g.FillRectangle(new SolidBrush(Color.Brown), Global.Conf.Size - Global.Conf.Size / 8, (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size / 8, (int)(Global.Conf.Size * doorSize));
                        break;
                    case Door.South:
                        g.FillRectangle(new SolidBrush(Color.Brown), (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size - Global.Conf.Size / 8, (int)(Global.Conf.Size * doorSize), Global.Conf.Size / 8);
                        break;
                    case Door.West:
                        g.FillRectangle(new SolidBrush(Color.Brown), 0, (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size / 8, (int)(Global.Conf.Size * doorSize));
                        break;
                }
            }

            return bmp;
        }
    }
}
