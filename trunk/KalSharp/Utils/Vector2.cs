using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp
{
    public class Vector2
    {
        protected int x;
        protected int y;

        public virtual int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public virtual int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Vector2(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double DistanceFrom(Vector3 Vector3)
        {
            //delta
            double distX = (double)(this.X - Vector3.X);
            double distY = (double)(this.Y - Vector3.Y);

            //square it
            distX *= distX;
            distY *= distY;

            //sqrt it
            return Math.Sqrt(distX + distY);

        }
    }
}
