using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KalSharp
{
    public class Vector3
    {
        protected int x;
        protected int y;
        protected int z;

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

        public virtual int Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public Vector3(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Vector3() { }

        public double DistanceFrom(Vector3 Vector3)
        {
            //delta
            double distX = (double)(this.X - Vector3.X);
            double distY = (double)(this.Y - Vector3.Y);
            double distZ = (double)(this.Z - Vector3.Z);

            //square it
            distX *= distX;
            distY *= distY;
            distZ *= distZ;

            //sqrt it
            return Math.Sqrt(distX + distY + distZ);

        }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
        }
    }
}
