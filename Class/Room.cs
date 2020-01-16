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
        private Point _size;
        private Dictionary<Point, Tile> _tiles;
        private List<Monster> _monsters;
        private Dictionary<Direction, Room> _neighbors;
    }
}
