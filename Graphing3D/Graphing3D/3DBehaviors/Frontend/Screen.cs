using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphing3D._3DBehaviors.Backend;
using Graphing3D._3DBehaviors.Graphing;

namespace Graphing3D._3DBehaviors.Frontend
{
    public static class Screen
    {
        public static Camera cam = new Camera(0, 0, 0, Math.PI / 2.0, Math.PI / 2.0);
        public static GraphHandler gh = new GraphHandler(20, 20, -5, -5, .5, .5);
        public static Vector3D[] graphPoints = gh.getShapePoints();
        public static Vector3D[] graphPointsConnections = gh.getConnections();
        public static CShape graph = new CShape(graphPoints, graphPointsConnections, new byte[] { 0, 200, 200 });
        public static void recalculatePoints()
        {
            graphPoints = gh.getShapePoints();
            graphPointsConnections = gh.getConnections();
            graph = new CShape(graphPoints, graphPointsConnections, new byte[] { 30, 100, 100 });
        }
    }
}
