using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManorGen.Class.Enum;

namespace ManorGen.Class
{
    class Room
    {
        private Point _origin;
        private Size _size;
        private Dictionary<Point, Tile> _tiles = new Dictionary<Point, Tile>();
        private Dictionary<Point, Monster> _monsters;
        private Dictionary<Direction, Room> _neighbors;

        public Point Origin { get => _origin; set => _origin = value; }
        public Size Size { get => _size; set => _size = value; }
        public Dictionary<Point, Tile> Tiles { get => _tiles; set => _tiles = value; }
        public Dictionary<Point, Monster> Monsters { get => _monsters; set => _monsters = value; }
        public Dictionary<Direction, Room> Neighbors { get => _neighbors; set => _neighbors = value; }
        public double Area => _size.Width * _size.Height;

        public Room() { }
        public Room(Point origin, Size size)
        {
            this.Origin = origin;
            this.Size = size;
            GenRoom();
        }
        public Room(int x, int y, int width, int height)
        {
            this.Origin = new Point(x, y);
            this.Size = new Size(width, height);
            GenRoom();
        }
    
        public void GenRoom()
        {
            this.Tiles.Add(new Point(0, 0), new Tile()
            {
                Door = Direction.None,
                Walls = new List<Direction>()
                {
                    Direction.North,
                    Direction.West
                }
            });
            this.Tiles.Add(new Point(this.Size.Width - 1, 0), new Tile()
            {
                Door = Direction.None,
                Walls = new List<Direction>()
                {
                    Direction.North,
                    Direction.East
                }
            });
            this.Tiles.Add(new Point(0, this.Size.Height - 1), new Tile()
            {
                Door = Direction.None,
                Walls = new List<Direction>()
                {
                    Direction.South,
                    Direction.West
                }
            });
            this.Tiles.Add(new Point(this.Size.Width - 1, this.Size.Height - 1), new Tile()
            {
                Door = Direction.None,
                Walls = new List<Direction>()
                {
                    Direction.South,
                    Direction.East
                }
            });
            
            for (int i = 1; i < this.Size.Width - 1; i++)
            {
                this.Tiles.Add(new Point(i, 0), new Tile()
                {
                    Door = Direction.None,
                    Walls = new List<Direction>() { Direction.North }
                });
                this.Tiles.Add(new Point(i, this.Size.Height - 1), new Tile()
                {
                    Door = Direction.None,
                    Walls = new List<Direction>() { Direction.South }
                });
            }
            for (int j = 1; j < this.Size.Height - 1; j++)
            {
                this.Tiles.Add(new Point(0, j), new Tile()
                {
                    Door = Direction.None,
                    Walls = new List<Direction>() { Direction.West }
                });
                this.Tiles.Add(new Point(this.Size.Width - 1, j), new Tile()
                {
                    Door = Direction.None,
                    Walls = new List<Direction>() { Direction.East }
                });
            }

            for(int i = 1; i < this.Size.Width - 1; i++)
            {
                for(int j = 1; j < this.Size.Height - 1; j++)
                {
                    this.Tiles.Add(new Point(i, j), new Tile()
                    {
                        Door = Direction.None,
                        Walls = new List<Direction>() { Direction.None }
                    });
                }
            }
        }
        public Bitmap GetImage()
        {
            Bitmap bmp = new Bitmap(this.Size.Width * Global.Conf.Size, this.Size.Height * Global.Conf.Size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.LightSlateGray), 0, 0, this.Size.Width * Global.Conf.Size, this.Size.Height * Global.Conf.Size);
                for (int i = 0; i < this.Size.Width; i++)
                {
                    g.DrawLine(new Pen(Color.LightGray), i * Global.Conf.Size, 0, i * Global.Conf.Size, this.Size.Height * Global.Conf.Size);
                }
                for (int j = 0; j < this.Size.Height; j++)
                {
                    g.DrawLine(new Pen(Color.LightGray), 0, j * Global.Conf.Size, this.Size.Width * Global.Conf.Size, j * Global.Conf.Size);
                }
                foreach (KeyValuePair<Point, Tile> kvp in this.Tiles)
                {
                    g.DrawImage(kvp.Value.GetImage(), new Point(kvp.Key.X * Global.Conf.Size, kvp.Key.Y * Global.Conf.Size));
                }
            }

            return bmp;
        }
    }
}
