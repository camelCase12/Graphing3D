using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing3D._3DBehaviors.Backend
{
    public class Vector2D
    {
        public double x, y;
        public double Magnitude { get { return Math.Sqrt(x * x + y * y); } } // seems like a more neat version of a method for this purpose
        public double dotProduct(Vector2D otherVector)
        {
            return x * otherVector.x + y * otherVector.y;
        }
        public Vector2D scalarMultiply(double scalar)
        {
            return new Vector2D(x * scalar, y * scalar);
        }
        public Vector2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
