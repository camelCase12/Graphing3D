using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphing3D._3DBehaviors.Backend;

namespace Graphing3D._3DBehaviors.Graphing
{
    public class GraphHandler
    {
        public Vector3D[,] points;
        private int width, height; // 1 being 1 wide
        private double incrementX, incrementY;
        private double startX, startY;
        Stopwatch sw = Stopwatch.StartNew();
        public Vector3D[] getConnections()
        {
            Vector3D[] connections = new Vector3D[(points.GetLength(0) - 1) * (points.GetLength(1) - 1) * 2];//times 2 is important
            int count = 0;
            for(int i = 0; i < points.GetLength(0)-1; i++)
            {
                for(int j = 0; j < points.GetLength(1)-1; j++)
                {
                    connections[count] = new Vector3D(width*j+i, width*j+i + 1, width*(j+1) + i + 1);
                    count++;
                    connections[count] = new Vector3D(width*j+i, width*(j+1) + i + 1, width*(j+1) + i);
                    count++;
                }
            }
            return connections;
        }
        public Vector3D[] getShapePoints()
        {
            populatePoints();
            Vector3D[] shapePoints = new Vector3D[points.GetLength(0) * points.GetLength(1)];
            int count = 0;
            for(int i = 0; i < points.GetLength(0); i++)
            {
                for(int j = 0; j < points.GetLength(1); j++)
                {
                    shapePoints[count] = points[i, j];
                    count++;
                }
            }
            return shapePoints;
        }
        private void populatePoints()
        {
            points = new Vector3D[width, height];
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    double currentX = startX + i*incrementX;
                    double currentY = startY + j*incrementY;
                    double currentZ = function(currentX, currentY);
                    points[i, j] = new Vector3D(currentX, currentY, currentZ);
                }
            }
        }
        private double function(double x, double y) // returns the z value of a function f(x, y)
        {
            double timeElapsed = sw.ElapsedMilliseconds/1000.0; // ticks up at a rate of 1/s (continuously)
            return Math.Sin(timeElapsed + x) + Math.Sin(timeElapsed + y);
            //return Math.Cos(x+timeElapsed) + Math.Sin(y+timeElapsed); // parabolic function
        }
        public GraphHandler(int width, int height, double startX, double startY, double incrementX, double incrementY)
        {
            this.width = width;
            this.height = height;
            this.startX = startX;
            this.startY = startY;
            this.incrementX = incrementX;
            this.incrementY = incrementY;
        }
    }
}
