using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManorGen.Class
{
    class Conf
    {
        private int _width;
        private int _height;
        private int _size;

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int Size { get => _size; set => _size = value; }

        public Conf()
        {
            this.Width = 1344;
            this.Height = 736;
            this.Size = 32;
        }
        public Conf(Conf conf)
        {
            this.Width = conf.Width;
            this.Height = conf.Height;
            this.Size = conf.Size;
        }
        public Conf(int width, int height,int size)
        {
            this.Width = width;
            this.Height = height;
            this.Size = size;
        }
    }
}
