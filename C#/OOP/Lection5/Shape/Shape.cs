using System;
using System.Linq;

namespace Shapes
{
    public abstract class Shape
    {
        private int width, height;

        public Shape(int shapeWidth, int shapeHeight)
        {
            this.width = shapeWidth;
            this.height = shapeHeight;
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        public abstract double CalculateSurface();

    }
}
