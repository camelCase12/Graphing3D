using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphing3D._3DBehaviors.Backend
{
    public static class visualTransform
    {
        public static Vector3D relativize(Vector3D zero, Vector3D relative) // not the zero vector, but the new 'zero' to relate to
        {
            return new Vector3D(relative.x - zero.x, relative.y - zero.y, relative.z - zero.z);
        }
        public static Vector2D orthographicTransform(Camera c, Vector3D point)
        {
            // the point and camera have individual positions. the point's position must be made relative
            Vector3D relativePoint = relativize(c.position, point);
            // explanation on ortho-transf: a point (x1, y1, z1) around an origin-positioned camera with direcitonal angles phi, theta
            // will have an orthographic projection (x2, y2) as follows:
            // x2 = x1*sin(theta) - y*cos(theta)
            // y2 = z1*sin(phi) - y1*cos(phi)*sin(theta) - x1*cos(phi)*cos(theta);
            double x2 = relativePoint.x * Math.Sin(c.theta) - relativePoint.y * Math.Cos(c.theta);
            double y2 = relativePoint.z * Math.Sin(c.phi) - relativePoint.y * Math.Cos(c.phi) * Math.Sin(c.theta) - relativePoint.x * Math.Cos(c.phi) * Math.Cos(c.theta);
            return new Vector2D(x2, y2);
        }
        public static Vector3D getDirectionVector(double theta, double phi)
        { // gets a unit vector in the direction of (theta, phi)
            double x = Math.Sin(phi) * Math.Cos(theta);
            double y = Math.Sin(phi) * Math.Sin(theta);
            double z = Math.Cos(phi);
            return new Vector3D(x, y, z);
        }
        public static Vector3D projectVector(Vector3D a, Vector3D b)
        {// proj a onto b (the thing from the line math class)
            double numeratorScalar = a.dotProduct(b);
            double denominatorScalar = b.dotProduct(b);
            double fullScalar = numeratorScalar / denominatorScalar;
            return b.scalarMultiply(fullScalar);
        }
        public static Vector2D perspectiveStretch(Vector2D ortho, Vector3D vectorProjection)
        {
            return ortho.scalarMultiply(1.0 / vectorProjection.Magnitude);
        }
        public static Vector2D transformPoint(Vector3D pointIn, Camera cam)
        {
            Vector3D relativePointIn = relativize(cam.position, pointIn);
            Vector2D transformedPoint;
            Vector2D ortho = orthographicTransform(cam, pointIn);
            Vector2D perspective = perspectiveStretch(ortho, projectVector(relativePointIn, getDirectionVector(cam.theta, cam.phi)));
            transformedPoint = perspective;
            return transformedPoint;
        }
    }
}
