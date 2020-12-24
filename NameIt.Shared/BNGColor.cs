using System;
using System.Drawing;

namespace NameIt
{
    public class BNGColor
    {
        private float R;
        private float G;
        private float B;
        private float Chrome;

        public BNGColor(int r, int g, int b, int chrome)
        {
            R = r;
            G = g;
            B = b;
            Chrome = chrome;
        }
    }
}