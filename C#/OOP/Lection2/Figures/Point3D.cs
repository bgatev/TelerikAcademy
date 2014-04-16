using System;
using System.Linq;
using System.Text;

namespace Figures
{
    public struct Point3D
    {
        private double x, y, z;
        private static readonly Point3D coordinateStart = new Point3D(0, 0, 0);

        public Point3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }


        public double X
        {
            get 
            { 
                return this.x;
            }
            set 
            { 
                this.x = value;
            }
        }

        public double Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        public double Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        public static Point3D CoordinateStart
        {
            get 
            {
                return coordinateStart; 
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.X + "," + this.Y + "," + this.Z);
            
            return sb.ToString();
        }
    }
}
