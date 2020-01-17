using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManorGen.Class.Enum;

namespace ManorGen.Class
{
    class Manor
    {
        private List<Room> _rooms = new List<Room>();
        private Size _size;

        public List<Room> Rooms { get => _rooms; set => _rooms = value; }
        public Size Size { get => _size; set => _size = value; }

        public Manor(int seed = -1)
        {
            Random r;
            if (seed == -1)
                r = new Random();
            else
                r = new Random(seed);

            this.Size = new Size((Global.Conf.Width / Global.Conf.Size) - 1, (Global.Conf.Height / Global.Conf.Size) - 1);

            StartGenManor(r);
        }

        private void StartGenManor(Random r)
        {
            Size s = new Size(r.Next(3, 7), r.Next(3, 7));
            Point o = new Point(r.Next(this.Size.Width - s.Width), this.Size.Height - s.Height);
            Room tmp = new Room(o, s)
            {
                Neighbors = new Dictionary<Direction, Room>() { [Direction.South] = null}
            };

            GenManor(tmp, r);
        }
        private void GenManor(Room room, Random r)
        {
            this.Rooms.Add(room);
            foreach (Direction d in Global.Randomize())
            {
                if (!room.Neighbors.ContainsKey(d))
                {
                    switch (d)
                    {
                        case Direction.North:
                            if (room.Origin.Y >= 3)
                            {
                                Size s = new Size(room.Size.Width, r.Next(3, 7));
                                if (room.Origin.Y + s.Height < 0)
                                    s.Height = s.Height - (room.Origin.Y - s.Height);
                                Point o = new Point(room.Origin.X, room.Origin.Y - s.Height);
                                if(!this.Collision(o))
                                {
                                    Room neighbour = new Room(o, s);

                                    int door = r.Next(room.Size.Width);
                                    room.Tiles[new Point(door, 0)].Door = Direction.North;
                                    neighbour.Tiles[new Point(door, neighbour.Size.Height - 1)].Door = Direction.South;

                                    neighbour.Neighbors = new Dictionary<Direction, Room>() { [Direction.South] = room, };
                                    room.Neighbors.Add(Direction.North, neighbour);

                                    GenManor(neighbour, r);
                                }
                            }
                            break;
                        /*case Direction.East:
                            if (room.Origin.X + room.Size.Width < this.Size.Width - 3)
                            {
                                Size s = new Size(r.Next(3, 7), room.Size.Height);
                                if ((room.Origin.X + room.Size.Width) + s.Width > this.Size.Width)
                                    s.Width = s.Width - ((room.Origin.X + room.Size.Width) + s.Width - this.Size.Width);
                                Point o = new Point(room.Origin.X + s.Width, room.Origin.Y);
                                if (!this.Collision(o))
                                {
                                    Room neighbour = new Room(o, s);

                                    int door = r.Next(room.Size.Height);
                                    room.Tiles[new Point(0, door)].Door = Direction.East;
                                    neighbour.Tiles[new Point(neighbour.Size.Width - 1, door)].Door = Direction.West;

                                    neighbour.Neighbors = new Dictionary<Direction, Room>() { [Direction.West] = room, };
                                    room.Neighbors.Add(Direction.East, neighbour);

                                    GenManor(neighbour, r);
                                }
                            }
                            break;
                        case Direction.South:
                            if (room.Origin.Y + room.Size.Height < this.Size.Height - 3)
                            {
                                Size s = new Size(room.Size.Width, r.Next(3, 7));
                                if ((room.Origin.Y + room.Size.Height) + s.Height > this.Size.Height)
                                    s.Height = s.Height - ((room.Origin.Y + room.Size.Height) + s.Height - this.Size.Height);
                                Point o = new Point(room.Origin.X, room.Origin.Y + s.Height);
                                if (!this.Collision(o))
                                {
                                    Room neighbour = new Room(o, s);

                                    int door = r.Next(room.Size.Width);
                                    room.Tiles[new Point(door, 0)].Door = Direction.South;
                                    neighbour.Tiles[new Point(door, neighbour.Size.Height - 1)].Door = Direction.North;

                                    neighbour.Neighbors = new Dictionary<Direction, Room>() { [Direction.North] = room, };
                                    room.Neighbors.Add(Direction.South, neighbour);

                                    GenManor(neighbour, r);
                                }
                            }
                            break;
                        case Direction.West:
                            if (room.Origin.X >= 3)
                            {
                                Size s = new Size(r.Next(3, 7), room.Size.Height);
                                if (room.Origin.X - s.Width < 0)
                                    s.Width = s.Width + (room.Origin.X - s.Width);
                                Point o = new Point(room.Origin.X - s.Width, room.Origin.Y);
                                if (!this.Collision(o))
                                {
                                    Room neighbour = new Room(o, s);

                                    int door = r.Next(room.Size.Height);
                                    room.Tiles[new Point(0, door)].Door = Direction.West;
                                    neighbour.Tiles[new Point(neighbour.Size.Width - 1, door)].Door = Direction.East;

                                    neighbour.Neighbors = new Dictionary<Direction, Room>() { [Direction.East] = room, };
                                    room.Neighbors.Add(Direction.West, neighbour);

                                    GenManor(neighbour, r);
                                }
                            }
                            break;*/
                    }
                }
            }

            /*Size s = new Size(room.Size.Width, r.Next(3, 7));
            Point o = new Point(room.Origin.X, room.Origin.Y - s.Height);
            Room neighbour = new Room(o, s);

            int door = r.Next(room.Size.Width);
            room.Tiles[new Point(door, 0)].Door = Direction.North;
            neighbour.Tiles[new Point(door, neighbour.Size.Height - 1)].Door = Direction.South;

            neighbour.Neighbors = new Dictionary<Direction, Room>() { [Direction.South] = room, };
            room.Neighbors.Add(Direction.North, neighbour);

            this.Rooms.Add(neighbour);*/
        }
        private void GenRooms()
        {
            foreach(Room r in this.Rooms)
            {
                r.GenRoom();
            }
        }
        public Bitmap GetImage()
        {
            Bitmap bmp = new Bitmap(this.Size.Width * Global.Conf.Size, this.Size.Height * Global.Conf.Size);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillRectangle(new SolidBrush(Color.DarkGreen), 0, 0, this.Size.Width * Global.Conf.Size, this.Size.Height * Global.Conf.Size);
                foreach(Room room in this.Rooms)
                {
                    g.DrawImage(room.GetImage(), new Point(room.Origin.X * Global.Conf.Size, room.Origin.Y * Global.Conf.Size));
                }
            }

            return bmp;
        }
    
        private bool Collision(Point point)
        {
            foreach(Room room in this.Rooms)
            {
                if (new Rectangle(room.Origin, room.Size).Contains(point))
                    return true;
            }

            return false;
        }
    }
}
