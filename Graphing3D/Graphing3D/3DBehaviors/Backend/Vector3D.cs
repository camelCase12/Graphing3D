using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing3D._3DBehaviors.Backend
{
    public class Vector3D
    {
        public double x, y, z;
        public double Magnitude { get { return Math.Sqrt(x * x + y * y + z * z); } }
        public double dotProduct(Vector3D otherVector)
        {
            return x * otherVector.x + y * otherVector.y + z * otherVector.z;
        }
        public Vector3D scalarMultiply(double scalar)
        {
            return new Vector3D(x * scalar, y * scalar, z * scalar);
        }
        public Vector3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
