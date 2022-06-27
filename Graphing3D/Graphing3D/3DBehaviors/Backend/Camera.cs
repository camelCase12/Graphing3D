using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing3D._3DBehaviors.Backend
{
    public class Camera // defines the FOV, position, and direction with which to perform a linear transformation.
    {
        public Vector3D position;
        public double phi; // as defined in spherical coordinates, the direction of the camera (rads)
        public double theta; // as defined in spherical coordinates, the direction of the camera (rads)
        public double FOV; // (field of vision in rads, probably about pi/2 works best)
        //Linear transform refactored to its own area
        public Camera(double x, double y, double z, double theta, double phi, double FOV)
        {
            position = new Vector3D(x, y, z);
            this.theta = theta;
            this.phi = phi;
            this.FOV = FOV;
        }
        public Camera(double x, double y, double z, double theta, double phi) // defaults the FOV to pi/2
        {
            position = new Vector3D(x, y, z);
            this.theta = theta;
            this.phi = phi;
        }
    }
}
