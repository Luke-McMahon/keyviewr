using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardViewer
{
    struct Texture2D
    {
        private int _id;
        private int _width;
        private int _height;

        public Texture2D(int id, int width, int height)
        {
            _id = id;
            _width = width;
            _height = height;
        }

        public int ID { get { return _id; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
    } 
}
