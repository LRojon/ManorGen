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
        private Direction _door;
        private List<Direction> _walls;
        private Trap _trap;

        public Direction Door { get => _door; set => _door = value; }
        public List<Direction> Walls { get => _walls; set => _walls = value; }
        internal Trap Trap { get => _trap; set => _trap = value; }

        public Bitmap GetImage()
        {
            double doorSize = .75;
            var bmp = new Bitmap(Global.Conf.Size, Global.Conf.Size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (Direction w in this.Walls)
                {
                    switch (w)
                    {
                        case Direction.North:
                            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Global.Conf.Size, Global.Conf.Size / 8);
                            break;
                        case Direction.East:
                            g.FillRectangle(new SolidBrush(Color.Black), Global.Conf.Size - Global.Conf.Size / 8, 0, Global.Conf.Size / 8, Global.Conf.Size);
                            break;
                        case Direction.South:
                            g.FillRectangle(new SolidBrush(Color.Black), 0, Global.Conf.Size - Global.Conf.Size / 8, Global.Conf.Size, Global.Conf.Size / 8);
                            break;
                        case Direction.West:
                            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Global.Conf.Size / 8, Global.Conf.Size);
                            break;
                    }
                }
                switch (this.Door)
                {
                    case Direction.North:
                        g.FillRectangle(new SolidBrush(Color.Brown), (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), 0, (int)(Global.Conf.Size * doorSize), Global.Conf.Size / 16);
                        g.FillRectangle(new SolidBrush(Color.LightSlateGray), (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size/16, (int)(Global.Conf.Size * doorSize), Global.Conf.Size / 16);
                        break;
                    case Direction.East:
                        g.FillRectangle(new SolidBrush(Color.Brown), Global.Conf.Size - Global.Conf.Size / 16, (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size / 16, (int)(Global.Conf.Size * doorSize));
                        g.FillRectangle(new SolidBrush(Color.LightSlateGray), Global.Conf.Size - Global.Conf.Size / 8, (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size / 16, (int)(Global.Conf.Size * doorSize));
                        break;
                    case Direction.South:
                        g.FillRectangle(new SolidBrush(Color.Brown), (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size - Global.Conf.Size / 16, (int)(Global.Conf.Size * doorSize), Global.Conf.Size / 16);
                        g.FillRectangle(new SolidBrush(Color.LightSlateGray), (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size - Global.Conf.Size / 8, (int)(Global.Conf.Size * doorSize), Global.Conf.Size / 16);
                        break;
                    case Direction.West:
                        g.FillRectangle(new SolidBrush(Color.Brown), 0, (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size / 16, (int)(Global.Conf.Size * doorSize));
                        g.FillRectangle(new SolidBrush(Color.LightSlateGray), Global.Conf.Size / 16, (int)(Global.Conf.Size / 2 - Global.Conf.Size * doorSize / 2), Global.Conf.Size / 16, (int)(Global.Conf.Size * doorSize));
                        break;
                }
            }

            return bmp;
        }
    }
}
